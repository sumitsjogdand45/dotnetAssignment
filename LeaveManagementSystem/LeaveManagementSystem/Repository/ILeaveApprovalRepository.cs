using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Repository
{
    public interface ILeaveApprovalRepository
    {
        Task<IEnumerable<LeaveApproval>>GetAllLeaves();
        Task<int> AddLeaveApproval(LeaveApproval approval);

        Task<LeaveApproval> GetLeaveApprovalById(int approvalId);

        Task<LeaveApproval>GetApprovalsByManagerId(int managerId);

    }
}
