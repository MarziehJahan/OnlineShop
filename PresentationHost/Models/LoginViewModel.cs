﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationHost.Models
{
    public class LoginViewModel
    {
        public bool RememberMe { get; set; }
        public string Email { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public string returnUrl { get; set; }
    }
}
