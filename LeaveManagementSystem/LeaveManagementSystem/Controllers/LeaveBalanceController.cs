using LeaveManagementSystem.Models;
using LeaveManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{

    public class LeaveBalanceController : Controller
    {
        readonly ILeaveBalanceService _leaveBS;

        public LeaveBalanceController(ILeaveBalanceService leaveBS)
        {
            _leaveBS = leaveBS;
        }


        //GetLeaveBalanceByUserId

        [HttpGet]
        public async Task<IActionResult> GetLeaveBalanceByUserId(string id)
        {
            var balance = await _leaveBS.GetLeaveBalanceByUserId(id);
            return View(balance);
        }


        //UpdateLeaveBalance

        [HttpGet]
        public async Task<IActionResult> UpdateLeaveBalance(string id)
        {
            var result = await _leaveBS.GetLeaveBalanceByUserId(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLeaveBalance(LeaveBalance leaveBalance)
        {
            await _leaveBS.UpdateLeaveBalance(leaveBalance);
            return RedirectToAction("GetLeaveBalanceByUserId");
        }






    }
}