using LeaveManagementSystem.Context;
using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Repository
{
    public class LeaveBalanceRepository : ILeaveBalanceRepository
    {
        readonly LeaveDbcontext _leaveDbcontext;

        public LeaveBalanceRepository(LeaveDbcontext leaveDbcontext)
        {
            _leaveDbcontext = leaveDbcontext;
        }

        //GetLeaveBalanceByUserId
        public async Task<LeaveBalance> GetLeaveBalanceByUserId(string userId)
        {
            return await _leaveDbcontext.LeaveBalances.FirstOrDefaultAsync(s => s.UserId == userId);
        }


        //UpdateLeaveBalance

        public async Task<int> UpdateLeaveBalance(LeaveBalance leaveBalance)
        {
            var leaves = await GetLeaveBalanceByUserId(leaveBalance.UserId);
            if (leaves != null)
            {
                leaves.BalanceId = leaveBalance.BalanceId;
                leaves.UserId = leaveBalance.UserId;
                leaves.TotalLeaveDays = leaveBalance.TotalLeaveDays;
                leaves.RemainingLeaveDays = leaveBalance.RemainingLeaveDays;
                leaves.LastUpdated = leaveBalance.LastUpdated;
                leaves.Employee = leaveBalance.Employee;
                return await _leaveDbcontext.SaveChangesAsync();
            }
            return 0;
        }
    }
}