using System;

namespace CoronaApp.Services.Models
{
    public class LocationSearch
    {
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Age { get; set; }
    }
}