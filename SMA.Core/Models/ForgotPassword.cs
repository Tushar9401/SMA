using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SMA.Core.Models
{
    public class ForgotPassword
    {
        [Display(Name = "User Email ID")]
        [Required(ErrorMessage = "User Email Id Required")]
        public string EmailId { get; set; }
    }
}
