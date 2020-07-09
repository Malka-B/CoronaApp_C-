using System;
using System.Data.SqlClient;
using NServiceBus;

namespace ResearchInstitute
{
    class Program
    {
        static async System.Threading.Tasks.Task Main()
        {
            Console.Title = "ResearchInstitute";

            //var endpointConfiguration = new EndpointConfiguration("ResearchInstitute");

            //endpointConfiguration.EnableOutbox();

            //var connection = "Server = C1; Database = ResearchInstitute ;Trusted_Connection=True;";

            //var persistance = endpointConfiguration.UsePersistence<SqlPersistence>();

            //persistance.SqlDialect<SqlDialect.MsSqlServer>();

            //persistance.ConnectionBuilder(
            //    connectionBuilder: () =>
            //    {
            //        return new SqlConnection(connection);
            //    });

            //var subscription = persistance.SubscriptionSettings();

            //subscription.CacheFor(TimeSpan.FromMinutes(1));

            //endpointConfiguration.SendFailedMessagesTo("error");

            //var endpointInstance = await Endpoint.Start(endpointConfiguration)
            //    .ConfigureAwait(false);

            //Console.WriteLine("Press Enter to exit.");
            //Console.ReadLine();

            //await endpointInstance.Stop()
            //    .ConfigureAwait(false);

        }
    }
}
