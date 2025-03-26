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

        [HttpGet("{balanceId}")]
        public async Task<IActionResult> GetLeaveBalanceByBalanceId(int balanceId)
        {
            var balanceUser = await _leaveBS.GetLeaveBalanceByBalanceId(balanceId);
            return View(balanceUser);
        }

        //GetLeaveBalanceByUserId

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetLeaveBalanceByUserId(int userId)
        {
            var balanceUser = await _leaveBS.GetLeaveBalanceByBalanceId(userId);
            var balance = await _leaveBS.GetLeaveBalanceByUserId(balanceUser.UserId);
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