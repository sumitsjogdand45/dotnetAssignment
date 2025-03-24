using LeaveManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LeaveManagementSystem.Context
{
    public class LeaveDbcontext:IdentityDbContext
    {
        public LeaveDbcontext(DbContextOptions<LeaveDbcontext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveApproval> LeaveApprovals { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    //        modelBuilder.Entity<LeaveApproval>()
    //.HasOne(la => la.LeaveRequest)
    //.WithMany()
    //.HasForeignKey(la => la.LeaveRequestId)
    //.OnDelete(DeleteBehavior.Restrict);  // or DeleteBehavior.SetNull


            base.OnModelCreating(modelBuilder);
        }

    }
}
