﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Core.Models
{
    public class UserRegistration:BaseEntity
    {

        [Required(ErrorMessage = "First Name is requierd")]
        public string FirstName { get; set; }

        [Required( ErrorMessage = "Last Name is requierd")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID is requierd")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is requierd")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Need min 6 character")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is requierd")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password should match with Password")]
        public string ConfirmPassword { get; set; }

        public bool EmailVerfication { get; set; }

        public string ActivationCode { get; set; }

        public string OTP { get; set; }

        public string Roles { get; set; }

    }
}
