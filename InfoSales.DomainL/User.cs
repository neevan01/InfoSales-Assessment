using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSales.DomainL
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public string Phone { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
        public DateTime JoinDate { get; set; } = DateTime.Now;
        [NotMapped]
        public string Result { get; set; } = string.Empty;
    }
}
