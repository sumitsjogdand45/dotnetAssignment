using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LeaveManagementSystem.Constants;

namespace LeaveManagementSystem.Models
{
    public class LeaveRequest
    {
        [Key ,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public string LeaveType { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        [Required]
        public string Reason { get; set; }
        public DateTime AppliedDate { get; set; }

        // Navigation Properties

        public string UserId { get; set; }
        [ForeignKey("UserId")]

        public User User { get; set; }

        public LeaveApproval Approval { get; set; }
    }
}