using Message;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthMinistry
{
    public class PatientRegisteredHandler : IHandleMessages<People>
    {
        static ILog log = LogManager.GetLogger<PatientRegisteredHandler>();

        public Task Handle(People message, IMessageHandlerContext context)
        {
            log.Info($"Patient Registered, his Id = {message.PeopleId}");
            //context.Publish(message)
            //    .ConfigureAwait(false);
            return Task.CompletedTask;
        }
    }
    
}
