using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    public class LeaveApproval
    {
        [Key]
        public int Id { get; set; } // primary key        
        public string ApprovalStatus { get; set; }
        public DateTime ReviewedDate { get; set; }
        public string Comments { get; set; }

        public int LeaveRequestId { get; set; }

        // Navigation Properties 
        //[ForeignKey("LeaveRequestId")]
        public LeaveRequest LeaveRequest { get; set; }//foreign key

        public string ManagerId { get; set; }//foreign key

        [ForeignKey("ManagerId")]
        public User Manager { get; set; }//foreign key
    }
}