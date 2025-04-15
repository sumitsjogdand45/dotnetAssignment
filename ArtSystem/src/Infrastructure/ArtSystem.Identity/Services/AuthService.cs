
using ArtExhibitionSystem.Application.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using ArtSystem.Application.Contracts.Models.Identity;
using ArtSystem.Application.Contracts.Persistance.Identity;
using ArtSystem.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.SecurityTokenService;
using ArtSystem.Application.Contracts.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ArtSystem.Identity.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly SignInManager<ApplicationUser> _signInManger;
        readonly JwtSettings _jwtSettings;
        readonly ArtIdentityDbContext _context;


        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManger, IOptions<JwtSettings> jwtsettings, ArtIdentityDbContext context)
        {
            _userManager=userManager;
            _signInManger=signInManger;
            _jwtSettings = jwtsettings.Value;
            _context=context;

        }

        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            var user = await _userManager.FindByEmailAsync(authRequest.Email);

            AuthResponse response1=new AuthResponse();
            if (user == null)
            {
                throw new NotFoundException($"user with email {authRequest.Email} not exist");
            }
            var userPassword = await _signInManger.CheckPasswordSignInAsync(user, authRequest.Password, false);
            if (userPassword.Succeeded)
            {
                JwtSecurityToken jwtSecurityToken = await GenerateToken(user);


                //if (user.RefreshTokens.Any(a=>a.IsActive))
                //{
                //    var activeRefreshToken = user.RefreshTokens.Where(a => a.IsActive == true).FirstOrDefault();
                //    response1.RefreshToken = activeRefreshToken.Token;
                //    response1.RefreshTokenExpiration = activeRefreshToken.Expires;
                //}
                //else
                //{
                    var refreshToken = GenerateRefreshToken();
                    response1.RefreshToken = refreshToken.Token;
                    response1.RefreshTokenExpiration = refreshToken.Expires;
                    user.RefreshTokens.Add(refreshToken);
                    _context.Update(user);
                    _context.SaveChanges();
                //}

                var response = new AuthResponse
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    RefreshToken = refreshToken.Token,
                    RefreshTokenExpiration = refreshToken.Expires
                };
                return response;
            }
            return null;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var generator = new RNGCryptoServiceProvider())
            {
                generator.GetBytes(randomNumber);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomNumber),
                    Expires = DateTime.UtcNow.AddDays(10),
                    Created = DateTime.UtcNow
                };
            }
        }


        public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var response = new RefreshTokenResponse();
            var user = _context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == request.Token));
            if (user == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"Token did not match any users.";
                return response;
            }
            var refreshToken = user.RefreshTokens.Single(x => x.Token == request.Token);

            if (!refreshToken.IsActive)
            {
                response.IsAuthenticated = false;
                response.Message = $"Token Not Active.";
                return response;
            }

            //Revoke Current Refresh Token
            refreshToken.Revoked = DateTime.Now;

            //Generate new Refresh Token and save to Database
            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            _context.Update(user);
            await _context.SaveChangesAsync();

            //Generates new jwt
            response.IsAuthenticated = true;
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            response.RefreshToken = newRefreshToken.Token;
            response.RefreshTokenExpiration = newRefreshToken.Expires;
            return response;
        }



        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(roles => new Claim(ClaimTypes.Role, roles)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdfghdsdfgfdsdfggfghgfdsdfghgfdfghgfdfg"));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;

        }



        public async Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
        {
            var user = new ApplicationUser()
            {
                Email = registrationRequest.Email,
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                UserName=registrationRequest.Username,
                EmailConfirmed = true

            };
            var result=await _userManager.CreateAsync(user, registrationRequest.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
                var erorresult = result.Errors.Select(e => e.Description).ToList();
                throw new BadRequestException($"{erorresult}");
            }
        }

       
    }
}
