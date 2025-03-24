using LeaveManagementSystem.Context;
using LeaveManagementSystem.Models;
using LeaveManagementSystem.Repository;
using LeaveManagementSystem.Service;
using LeaveManagementSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            string conn = builder.Configuration.GetConnectionString("LeaveManagementDB");
            builder.Services.AddDbContext<LeaveDbcontext>(options => options.UseSqlServer(conn));

            builder.Services.AddScoped<ILeaveApprovalRepository, LeaveApprovalRepository>();
            builder.Services.AddScoped<ILeaveApprovalService, LeaveApprovalService>();

            builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();

            builder.Services.AddScoped<ILeaveBalanceRepository, LeaveBalanceRepository>();
            builder.Services.AddScoped<ILeaveBalanceService, LeaveBalanceService>();

            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<LeaveDbcontext>();
            builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(30); });
            builder.Services.Configure<IdentityOptions>(options => { options.SignIn.RequireConfirmedEmail = false; });



            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                await SeedRoleAndAdmin(service);
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
        //---------------------------------------
        private static async Task SeedRoleAndAdmin(IServiceProvider serviceProvider)

        {

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            string[] roleNames = { "Admin", "Manager", "User" };

            foreach (var roleName in roleNames)

            {

                if (!await roleManager.RoleExistsAsync(roleName))

                {

                    await roleManager.CreateAsync(new IdentityRole(roleName));

                }

            }

            //  Create Default Admin User

            string adminEmail = "admin@gmail.com";

            string adminPassword = "Admin@123";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)

            {

                var newAdmin = new User

                {

                    UserName = adminEmail,

                    Email = adminEmail,

                    Name = "Admin",

                    //LastName = "User",

                    EmailConfirmed = true

                };

                var result = await userManager.CreateAsync(newAdmin, adminPassword);

                if (result.Succeeded)

                {

                    await userManager.AddToRoleAsync(newAdmin, "Admin");

                }

            }

        }

    }
}