using LeaveManagementSystem.Context;
using LeaveManagementSystem.Repository;
using LeaveManagementSystem.Service;
using LeaveManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            string conn = builder.Configuration.GetConnectionString("LeaveManagementDB");
            builder.Services.AddDbContext<LeaveDbcontext>(options => options.UseSqlServer(conn));

            builder.Services.AddScoped<ILeaveApprovalRepository,LeaveApprovalRepository>();
            builder.Services.AddScoped<ILeaveApprovalService,LeaveApprovalService>();

            builder.Services.AddScoped<ILeaveRequestRepository,LeaveRequestRepository>();
            builder.Services.AddScoped<ILeaveRequestService,LeaveRequestService>();

            builder.Services.AddScoped<ILeaveBalanceRepository,LeaveBalanceRepository>();
            builder.Services.AddScoped<ILeaveBalanceService,LeaveBalanceService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");              
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}