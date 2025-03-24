using LeaveManagementSystem.Models;
using LeaveManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    public class LeaveApprovalController : Controller
    {
        readonly ILeaveApprovalService _leaveApprovalService;
        public LeaveApprovalController(ILeaveApprovalService leaveApprovalService)
        {
            _leaveApprovalService = leaveApprovalService;
        }


        //---------GETALLL----------------------------------------------------------

        public async Task<IActionResult> GetAllLeaves()
        {
            return View(await _leaveApprovalService.GetAllLeaves());
        }

        //---------ADDLEAVE----------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> AddLeaves()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLeaves(LeaveApproval approval)
        {
            if (ModelState.IsValid)
            {
                int result = await _leaveApprovalService.AddLeaveApproval(approval);
                if (result > 0)
                {
                    TempData["Message"] = "Leave Added successfully";
                }
                else
                {
                    TempData["Message"] = "failed to Add";
                    return View(approval);
                }
            }

            return View(approval);
        }

        //---------GetLEAVEbyid----------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> GetLeaveApprovalByID(int approvalId)
        {
            var Approval = await _leaveApprovalService.GetLeaveApprovalById(approvalId);
            return View(Approval);
        }

        //---------GetLEAVEbymanagerid----------------------------------------------------------


        public async Task<IActionResult> GetApprovalsByManagerId(string managerId)
        {
            var Approval = await _leaveApprovalService.GetApprovalsByManagerId(managerId);
            return View(Approval);
        }

    }
}