using Message;
using NServiceBus;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HealthMinistry
{
    class Program
    {
        static async Task Main()
        {
            Console.Title = "HealthMinistry";

            //var endpointConfiguration = new EndpointConfiguration("HealthMinistry");

            //endpointConfiguration.EnableOutbox();

            //var connection = "Server = C1; Database = HealthMinistry ;Trusted_Connection=True; ";//Configuration.GetConnectionString("PersistanceDBConnectionString");

            //var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();

            //persistence.SqlDialect<SqlDialect.MsSqlServer>();
            //persistence.ConnectionBuilder(
            //    connectionBuilder: () =>
            //    {
            //        return new SqlConnection(connection);
            //    });

            //var subscription = persistence.SubscriptionSettings();
            //subscription.CacheFor(TimeSpan.FromMinutes(1));

            //var transport = endpointConfiguration.UseTransport<LearningTransport>();

            //var routing = transport.Routing();

            //routing.RouteToEndpoint(
            //    messageType: typeof(People),
            //    destination: "ResearchInstitute");

            //routing.RegisterPublisher(
            //    eventType: typeof(People),
            //    publisherEndpoint: "Sending");

            //endpointConfiguration.SendFailedMessagesTo("error");
            //endpointConfiguration.AuditProcessedMessagesTo("audit");
            //endpointConfiguration.SendHeartbeatTo("Particular.ServiceControl");

            //var metrics = endpointConfiguration.EnableMetrics();
            //metrics.SendMetricDataToServiceControl("Particular.Monitoring", TimeSpan.FromMilliseconds(500));

            //var endpointInstance = await Endpoint.Start(endpointConfiguration)
            //    .ConfigureAwait(false);

            //Console.WriteLine("Press Enter to exit.");
            //Console.ReadLine();

            //await endpointInstance.Stop()
            //    .ConfigureAwait(false);
        }

    }
}
