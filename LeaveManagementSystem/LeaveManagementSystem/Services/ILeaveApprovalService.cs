using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Services
{
    public interface ILeaveApprovalService
    {
        Task<IEnumerable<LeaveApproval>> GetAllLeaves();
        Task<int> AddLeaveApproval(LeaveApproval approval);
        Task<LeaveApproval> GetLeaveApprovalById(int approvalId);
        Task<LeaveApproval>GetApprovalsByManagerId(int managerId);

    }
}
