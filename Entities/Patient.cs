//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Patient
    {
        [Required]
        public int Id { get; set; }

        public int Age { get; set; }

        public List<Location> LocationsList { get; set; }
    }
}
