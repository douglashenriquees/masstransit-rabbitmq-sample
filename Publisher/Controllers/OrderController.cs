using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

namespace Publisher.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IBus _bus;

    public OrderController(IBus bus)
    {
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket(Ticket ticket)
    {
        if (ticket != null)
        {
            ticket.Booked = DateTime.Now;

            var uri = new Uri("rabbitmq://localhost/orderTicketQueue"); // nome da fila

            var endPoint = await _bus.GetSendEndpoint(uri);

            await endPoint.Send(ticket);

            return Ok();
        }

        return BadRequest();
    }
}