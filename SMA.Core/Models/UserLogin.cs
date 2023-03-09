using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SMA.Core.Models
{
    public class UserLogin
    {

        [Display(Name = "User Email ID")]
        [Required(ErrorMessage = "User Email Id Required")]
        public string EmailId { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }


        [Display(Name = "Remember Me")]
        public bool Rememberme { get; set; }

    }
}
