using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class TicketService(DataContext context)
    {


        private readonly DataContext _context = context;

        public async Task<TicketEntity> Create(TicketEntity ticket)
        {
            ticket.Ticketsleft = ticket.TicketAmount;
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }



        public async Task<List<TicketEntity>> GetTickets()
        {
         
            var ticket = await _context.Tickets.ToListAsync();

            return ticket;
        }




        public async Task<TicketEntity> Update(TicketEntity ticket)
        {
          
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }


        public async Task<TicketEntity> GetByEventId(string id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.EventId == id);
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }
            return ticket;
        }


    }
}
