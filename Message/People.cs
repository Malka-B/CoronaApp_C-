using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Message
{
    public class People: IEvent
    {
        public int PeopleId;
    }
}
