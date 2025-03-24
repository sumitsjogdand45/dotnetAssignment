using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.ViewModels
{

        public class RegisterViewModel
        {
            
            [Required]
            public string Name
            {
                get; set;
            }

            [Required]
            [EmailAddress]
            public string Email
            {
                get; set;
            }

            [Required]
            [DataType(DataType.Password)]
            public string Password
            {
                get; set;
            }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords does not match.")]
            public string ConfirmPassword
            {
                get; set;
            }
        }
    

}
