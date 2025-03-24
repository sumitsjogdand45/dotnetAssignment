using LeaveManagementSystem.Models;
using LeaveManagementSystem.Repository;
using LeaveManagementSystem.Services;

namespace LeaveManagementSystem.Service
{
    public class LeaveRequestService : ILeaveRequestService
    {
        readonly ILeaveRequestRepository _leaveRequestRepository;
        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        //GetAllLeaveRequests
        public async Task<IEnumerable<LeaveRequest>> GetAllLeaveRequests()
        {
            return await _leaveRequestRepository.GetAllLeaveRequests();
        }


        //addLeaverequest
        public async Task<int> AddLeaveRequest(LeaveRequest leaveRequest)
        {
            return await _leaveRequestRepository.AddLeaveRequest(leaveRequest);

        }

        //GetLeaveRequestById
        public async Task<LeaveRequest> GetLeaveRequestById(int requestId)
        {
            return await _leaveRequestRepository.GetLeaveRequestById(requestId);
        }


        //GetLeaveRequestByUserId    

        public async Task<LeaveRequest> GetLeaveRequestsByUserId(string requestId)
        {
            return await _leaveRequestRepository.GetLeaveRequestsByUserId(requestId);
        }

        //DeleteLeaveRequest

        public async Task<int> DeleteLeaveRequest(int requestId)
        {
            return await _leaveRequestRepository.DeleteLeaveRequest(requestId);
        }

    }
}