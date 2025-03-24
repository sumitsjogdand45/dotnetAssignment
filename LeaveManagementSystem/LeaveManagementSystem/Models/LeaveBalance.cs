using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    public class LeaveBalance
    {
        [Key]
        public int BalanceId { get; set; }
        public string UserId { get; set; }
        public double TotalLeaveDays { get; set; }
        public double RemainingLeaveDays { get; set; }
        public DateTime LastUpdated { get; set; }

        // Navigation Property
        [ForeignKey("UserId")]
        public User Employee { get; set; }
    }
}