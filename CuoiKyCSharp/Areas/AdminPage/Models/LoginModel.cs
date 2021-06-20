﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CuoiKyCSharp.Areas.AdminPage.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        public string password { get; set; }
    }
}