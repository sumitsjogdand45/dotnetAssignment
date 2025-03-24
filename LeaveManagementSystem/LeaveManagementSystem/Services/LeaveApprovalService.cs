using LeaveManagementSystem.Models;
using LeaveManagementSystem.Repository;

namespace LeaveManagementSystem.Services
{
    public class LeaveApprovalService : ILeaveApprovalService
    {
        readonly ILeaveApprovalRepository _leaveApprovalRepository;

        public LeaveApprovalService(ILeaveApprovalRepository leaveApprovalRepository)
        {
            _leaveApprovalRepository = leaveApprovalRepository;
        }
        /*-----------------------getalleavesApproval------------------------------------------*/
        public async Task<IEnumerable<LeaveApproval>> GetAllLeaves()
        {
            return await _leaveApprovalRepository.GetAllLeaves();
        }
        /*--------------------------addleaves---------------------------------------*/

        public async Task<int> AddLeaveApproval(LeaveApproval approval)
        {
            return await _leaveApprovalRepository.AddLeaveApproval(approval);
        }

        /*--------------------------getleavebyid---------------------------------------*/


        public async Task<LeaveApproval> GetLeaveApprovalById(int approvalId)
        {

            return await _leaveApprovalRepository.GetLeaveApprovalById(approvalId);

        }

        /*---------------------------getleavebymgrid--------------------------------------*/

        public async Task<LeaveApproval> GetApprovalsByManagerId(string managerId)
        {
            return await _leaveApprovalRepository.GetApprovalsByManagerId(managerId);
        }



    }
}