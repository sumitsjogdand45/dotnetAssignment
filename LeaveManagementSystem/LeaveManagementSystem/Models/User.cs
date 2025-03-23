 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models
{
    public class User
    {
        internal string FirstName;

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<LeaveRequest> LeaveRequests { get; set; }
        public ICollection<LeaveApproval> Approvals { get; set; }
        public string LastName { get; internal set; }
        public string UserName { get; internal set; }
        public bool EmailConfirmed { get; internal set; }
    }
}
