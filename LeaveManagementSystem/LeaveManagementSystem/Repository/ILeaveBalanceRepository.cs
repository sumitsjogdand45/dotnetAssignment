using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Repository
{
    public interface ILeaveBalanceRepository
    {
        Task<LeaveBalance> GetLeaveBalanceByUserId(int userId);

        Task<int> UpdateLeaveBalance(LeaveBalance leaveBalance);
    }
}
