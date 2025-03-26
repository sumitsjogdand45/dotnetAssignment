using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Repository
{
    public interface ILeaveBalanceRepository
    {
        Task<LeaveBalance> GetLeaveBalanceByBalanceId(int balanceId);
        Task<LeaveBalance> GetLeaveBalanceByUserId(string userId);

        Task<int> UpdateLeaveBalance(LeaveBalance leaveBalance);
    }
}