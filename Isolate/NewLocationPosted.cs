using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Message;
using NServiceBus;
using NServiceBus.Logging;

namespace Isolate
{
    public class NewLocationPosted : IHandleMessages<LocationEvent>
    {
        

        ILog log = LogManager.GetLogger<NewLocationPosted>();

        public Task Handle(LocationEvent message, IMessageHandlerContext context)
        {
            log.Info($"Received Location. People who where in city: {message.City} in: {message.Adress} have to be isolate!");

            return Task.CompletedTask;
        }
    }
}
