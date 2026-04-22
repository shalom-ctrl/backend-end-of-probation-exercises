using customer_support_api.Enums;

namespace customer_support_api.Models
{
    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Status status { get; set; }
        public TicketType type { get; set; }

        public virtual void TicketType()
        {
            Console.WriteLine("Creating a Ticket");
        }
    }
}
