using LeaveManagementSystem.Models;
using LeaveManagementSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    public class LeaveRequestController : Controller
    {

        readonly ILeaveRequestService _leaveRequestService;
        readonly UserManager<User> _userManager;

        public LeaveRequestController(ILeaveRequestService leaveRequestService, UserManager<User> userManager)
        {
            _leaveRequestService = leaveRequestService;
            _userManager = userManager;
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
            ModelState.Remove("User");
            //ModelState.Remove("Approval");
            var user = await _userManager.GetUserAsync(User);
            if (!ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserId");
                var leaveRequests = new LeaveRequest
                {
                    LeaveType = leaveRequest.LeaveType,
                    StartDate = DateTime.Now,
                    EndDate = leaveRequest.EndDate,
                    Status = leaveRequest.Status,
                    Reason = leaveRequest.Reason,
                    AppliedDate = leaveRequest.AppliedDate,
                    UserId= user.Id

                };
               
                int result = await _leaveRequestService.AddLeaveRequest(leaveRequests);
                if (result > 0)
                {
                    TempData["Message"] = "Leave Added successfully";
                    return RedirectToAction("GetAllLeaveRequests");
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

        [HttpGet("{requestId}")]
        public async Task<IActionResult> GetLeaveRequestById(int requestId)
        {
            var request = await _leaveRequestService.GetLeaveRequestById(requestId);
            

            return View(request);
        }




        //GetLeaveRequestByUserId
        [HttpGet("{requestId}")]
        public async Task<IActionResult> GetLeaveRequestByUserId(int requestId)
        {
            var leaverequest = await _leaveRequestService.GetLeaveRequestById(requestId);
            var request = await _leaveRequestService.GetLeaveRequestsByUserId(leaverequest.UserId);
            return View(request);
        }


        //DeleteLeaveRequest 

        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteLeaveRequest(int id)
        {
            var lr = await _leaveRequestService.GetLeaveRequestById(id);
            return View(lr);
        }


        [HttpPost()]
        public async Task<IActionResult> DeleteLeaveRequest(LeaveRequest leaveRequest)
        {
            var del = await _leaveRequestService.DeleteLeaveRequest(leaveRequest.Id);
            return RedirectToAction("AddLeaveRequest");

        }



    }
}