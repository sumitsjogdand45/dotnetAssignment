using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Services
{
    public interface ILeaveBalanceService
    {
        Task<LeaveBalance> GetLeaveBalanceByBalanceId(int balanceId);
        Task<LeaveBalance> GetLeaveBalanceByUserId(string userId);

        Task<int> UpdateLeaveBalance(LeaveBalance leaveBalance);

    }
}