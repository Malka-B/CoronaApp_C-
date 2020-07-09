using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaApp.Services.Models
{
    public class AuthenticateModel
    {
      
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
