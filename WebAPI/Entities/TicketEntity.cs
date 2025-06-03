using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities;

public class TicketEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string EventId { get; set; } = null!;

    public int TicketAmount { get; set; }
    public int Ticketsleft { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal TicketPrice { get; set; }
}
