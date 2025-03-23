using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Services
{
    public interface ILeaveBalanceService
    {
        Task<LeaveBalance> GetLeaveBalanceByUserId(int userId);

        Task<int> UpdateLeaveBalance(LeaveBalance leaveBalance);

    }
}
