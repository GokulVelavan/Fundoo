using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class ResetPassword
    {
   
     
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20,MinimumLength =5)]
        public string newPassword { get; set; }

        [Required]
        [StringLength(20,MinimumLength =5)]
        public string ConfirmPassword { get; set; }
    }
}
