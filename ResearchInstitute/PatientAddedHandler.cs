using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Message;
using NServiceBus;
using NServiceBus.Logging;

namespace ResearchInstitute
{
    public class PatientAddedHandler : IHandleMessages<People>
    {
        static ILog log = LogManager.GetLogger<PatientAddedHandler>();

        public Task Handle(People message, IMessageHandlerContext context)
        {
            log.Info("One Corona patient added!");

            return Task.CompletedTask;
        }
    }
}
