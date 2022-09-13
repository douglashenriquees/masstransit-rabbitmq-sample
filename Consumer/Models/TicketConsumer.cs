using MassTransit;
using Shared.Model;

namespace Consumer.Models;

public class TicketConsumer : IConsumer<Ticket>
{
    private readonly ILogger<TicketConsumer> _logger;

    public TicketConsumer(ILogger<TicketConsumer> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Consume(ConsumeContext<Ticket> context)
    {
        await Console.Out.WriteLineAsync(context.Message.UserName);

        _logger.LogInformation($"Nova mensagem recebida: {context.Message.UserName} {context.Message.Location}");
    }
}