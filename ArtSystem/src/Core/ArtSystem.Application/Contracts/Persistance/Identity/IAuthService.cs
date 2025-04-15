
using ArtSystem.Application.Contracts.Models.Identity;

namespace ArtSystem.Application.Contracts.Persistance.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest authrequest);
        Task<RegistrationResponse>Register(RegistrationRequest registrationrequest);
        Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
