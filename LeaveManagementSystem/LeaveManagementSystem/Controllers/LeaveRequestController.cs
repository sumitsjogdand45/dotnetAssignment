using System.Threading.Tasks;
using LeaveManagementSystem.Models;
using LeaveManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    public class LeaveRequestController : Controller
    {

        readonly  ILeaveRequestService _leaveRequestService;

        public LeaveRequestController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }



        //getallLeave requests
        [HttpGet]
        public async Task<IActionResult> GetAllLeaveRequests()
        {
            return View(await _leaveRequestService.GetAllLeaveRequests());
        }

        //addleaverequest

        [HttpGet]
        public async Task<IActionResult> AddLeaveRequest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLeaveRequest(LeaveRequest leaveRequest)
        {
            if (ModelState.IsValid)
            {
                int result = await _leaveRequestService.AddLeaveRequest(leaveRequest);
                if (result > 0)
                {
                    TempData["Message"] = "Leave Added successfully";
                }
                else
                {
                    TempData["Message"] = "failed to Add";
                    return View(leaveRequest);
                }
            }
           
            return View(leaveRequest);
        }


        //GetLeaveRequestById

        [HttpGet("LeaveRequest/GetLeaveRequestById")]
        public async Task<IActionResult> GetLeaveRequestById(int requestId)
        {
            var request = await _leaveRequestService.GetLeaveRequestById(requestId);
            return View();
        }



        //GetLeaveRequestByUserId

        [HttpGet]
        public async Task<IActionResult> GetLeaveRequestByUserId(int requestId)
        {
            var request = await _leaveRequestService.GetLeaveRequestsByUserId(requestId);
            return View();
        }


        //DeleteLeaveRequest 

        [HttpGet]
        public async Task<IActionResult>DeleteLeaveRequest(int requestId)
        {
            var del = await  _leaveRequestService.GetLeaveRequestById(requestId);
            return View(del);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLeaveRequest(LeaveRequest leaverequest)
        {
            var del2 = await _leaveRequestService.DeleteLeaveRequest(leaverequest.LeaveRequestId);
            return RedirectToAction("AddLeaveRequest");
        }



    }
}
