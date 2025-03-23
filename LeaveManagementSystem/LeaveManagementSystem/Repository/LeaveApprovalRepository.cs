using LeaveManagementSystem.Context;
using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Repository
{
    public class LeaveApprovalRepository : ILeaveApprovalRepository
    {
        readonly LeaveDbcontext _leaveDbcontext;
        public LeaveApprovalRepository(LeaveDbcontext leaveDbcontext)
        {
            _leaveDbcontext = leaveDbcontext;
        }
        //getall
        public async Task<IEnumerable<LeaveApproval>> GetAllLeaves()
        {
            return await _leaveDbcontext.LeaveApprovals.ToListAsync();
        }

        //addleave
        public async Task<int> AddLeaveApproval(LeaveApproval approval)
        {
             await _leaveDbcontext.LeaveApprovals.AddAsync(approval);
            return await _leaveDbcontext.SaveChangesAsync();

        }
        //getapprovalbyid
        public async Task<LeaveApproval> GetLeaveApprovalById(int approvalId)
        {
            return await _leaveDbcontext.LeaveApprovals.FirstOrDefaultAsync(e=>e.ApprovalId==approvalId);
        }

        //getapprovalbymgrid
        public async Task<LeaveApproval> GetApprovalsByManagerId(int managerId)
        {
            return await _leaveDbcontext.LeaveApprovals.FirstOrDefaultAsync(c=> c.ManagerId == managerId);
        }

         

        //
    }
}
