using MassTransit;
using Shared.Models;

namespace OrderConsumer.Consumers
{
    public class TicketConsumer : IConsumer<Ticket>
    {
        private readonly ILogger<TicketConsumer> _logger;

        public TicketConsumer(ILogger<TicketConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Ticket> context)
        {
            await Console.Out.WriteLineAsync(context.Message.UserName);
            _logger.LogInformation($"Received message: {context.Message.UserName} {context.Message.Location} {context.Message.Booked}");
        }
    }
}
