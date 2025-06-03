using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services;

namespace WebAPI.Controllers;


[Route("api/[Controller]")]
[ApiController]
public class TicketController(TicketService ticketService) : Controller
{

    private readonly TicketService _ticketService = ticketService;

    [HttpPost("createticket")]
    
    public async Task<IActionResult> CreateTicket(TicketEntity ticket)
    {
        if (ticket == null)
        {
            return BadRequest("Ticket cannot be null");
        }
        var createdTicket = await _ticketService.Create(ticket);
        return Ok(createdTicket);
    }

    [HttpGet("getticket")]
   
    public async Task<IActionResult> GetTicket()
    {
        var tickets = await _ticketService.GetTickets();

        return Ok(tickets);

    }



    [HttpPut("updateticket/{id}")]
    public async Task<IActionResult> UpdateTicket(string id,[FromBody] TicketUpdateDto ticket)
    {
        var existingTicket = await _ticketService.GetByEventId(id);

        existingTicket.Ticketsleft -= ticket.Quantity;

        var updatedTicket = await _ticketService.Update(existingTicket);
        return Ok(updatedTicket);
    }



}

