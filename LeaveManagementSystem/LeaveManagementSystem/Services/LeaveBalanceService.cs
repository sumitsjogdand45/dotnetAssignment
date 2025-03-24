using LeaveManagementSystem.Context;
using LeaveManagementSystem.Models;
using LeaveManagementSystem.Repository;

namespace LeaveManagementSystem.Services
{
    public class LeaveBalanceService : ILeaveBalanceService
    {
        readonly ILeaveBalanceRepository _leaveBR;
        public LeaveBalanceService(ILeaveBalanceRepository leaveBR)
        {
            _leaveBR = leaveBR;
        }

        //GetLeaveBalanceByUserId
        public async Task<LeaveBalance> GetLeaveBalanceByUserId(string userId)
        {
            return await _leaveBR.GetLeaveBalanceByUserId(userId);
        }


        //UpdateLeaveBalance
        public async Task<int> UpdateLeaveBalance(LeaveBalance leaveBalance)
        {
            return await _leaveBR.UpdateLeaveBalance(leaveBalance);
        }
    }
}