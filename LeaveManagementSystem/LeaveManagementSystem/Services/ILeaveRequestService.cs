using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Services
{
    public interface ILeaveRequestService
    {
        Task<IEnumerable<LeaveRequest>> GetAllLeaveRequests();
        Task<int> AddLeaveRequest(LeaveRequest leaveRequest);
        Task<LeaveRequest> GetLeaveRequestById(int requestId);
        Task<IEnumerable<LeaveRequest>> GetLeaveRequestsByUserId(string userId);
        Task<int> DeleteLeaveRequest(int requestId);
    }
}