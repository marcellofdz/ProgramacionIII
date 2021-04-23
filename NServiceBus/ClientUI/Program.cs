using System;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace ClientUI
{
    class Program
    {
        static async Task Main()
        {
            Console.Title = "ClientUI";

            var endpointConfiguration = new EndpointConfiguration("ClientUI");

            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.LicensePath(@"E:\repos\ProgramacionIII\NServiceBus\License.yml");
            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            await RunLoop(endpointInstance)
                .ConfigureAwait(false);

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }

        static ILog log = LogManager.GetLogger<Program>();

        static async Task RunLoop(IEndpointInstance endpointInstance)
        {
            while (true)
            {
                log.Info("Press 'P' to place an order, or 'Q' to quit.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.P:

                        var command = new PlaceOrder
                        {
                            OrderId = Guid.NewGuid().ToString(),
                            FechaIngreso = DateTime.Now,
                            Amount = Guid.NewGuid().ToString(),
                            CustomerID =Guid.NewGuid().ToString(),
                            CustomerName = Guid.NewGuid().ToString(),
                            Description = Guid.NewGuid().ToString()
                        };


                        log.Info($"Sending PlaceOrder command, OrderId = {command.OrderId}, {command.FechaIngreso}, {command.Description}, {command.Amount}, {command.CustomerID}, {command.CustomerName}");
                        await endpointInstance.Send(command)
                            .ConfigureAwait(false);

                        break;

                    case ConsoleKey.Q:
                        return;

                    default:
                        log.Info("Input desconocido. Por favor trate de nuevo.");
                        break;
                }
            }
        }
    }
}