using LeaveManagementSystem.Context;
using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        readonly LeaveDbcontext _leaveDbcontext;

        public LeaveRequestRepository(LeaveDbcontext leaveDbcontext)
        {
            _leaveDbcontext = leaveDbcontext;
        }

        //GetAllLeaveRequests

        public async Task<IEnumerable<LeaveRequest>> GetAllLeaveRequests()
        {
            return await _leaveDbcontext.LeaveRequests.Include(l=>l.User).Include(e=>e.Approval).ToListAsync();
        }

        //------------addleaveRequest-----------------------------------------------------------------------------------


        public async Task<int> AddLeaveRequest(LeaveRequest leaveRequest)
        {
            await _leaveDbcontext.LeaveRequests.AddAsync(leaveRequest);
            return await _leaveDbcontext.SaveChangesAsync();
        }

        //-------------------------------getLeaveRequestbyId---------------------------------------------------------

        public async Task<LeaveRequest> GetLeaveRequestById(int requestId)
        {
            return await _leaveDbcontext.LeaveRequests.FirstOrDefaultAsync(c => c.Id == requestId);
        }

        //GetLeaveRequestsByUserId

        public async Task<LeaveRequest> GetLeaveRequestsByUserId(string userId)
        {
            return await _leaveDbcontext.LeaveRequests.FirstOrDefaultAsync(d => d.UserId == userId);
        }


        //DeleteLeaveRequest

        public async Task<int> DeleteLeaveRequest(int requestId)
        {
            var deleteleave = await GetLeaveRequestById(requestId);
            await _leaveDbcontext.LeaveRequests.Remove(deleteleave);
            return await _leaveDbcontext.SaveChangesAsync();
        }


    }
}