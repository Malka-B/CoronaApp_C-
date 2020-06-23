using System;
using NServiceBus;

namespace Message
{
    public class LocationEvent : IEvent
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }
    }
}
