using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Repository
{
    public interface ILeaveRequestRepository
    {
        Task<IEnumerable<LeaveRequest>> GetAllLeaveRequests();

        Task<int> AddLeaveRequest(LeaveRequest leaveRequest);
        Task<LeaveRequest> GetLeaveRequestById(int requestId);

        Task<LeaveRequest> GetLeaveRequestsByUserId(string userId);

        Task<int> DeleteLeaveRequest(int requestId);
    }
}