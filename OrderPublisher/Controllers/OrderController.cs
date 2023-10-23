using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace OrderPublisher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;

        public OrderController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                ticket.Booked = DateTime.Now;
                await _bus.Publish(ticket);
                return Ok();
            }

            return BadRequest();
        }
    }
}