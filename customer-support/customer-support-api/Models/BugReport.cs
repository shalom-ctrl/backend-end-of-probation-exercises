using customer_support_api.Enums;

namespace customer_support_api.Models
{
    public class BugReport : Ticket
    {
        public Priority priority { get; set; }
        public Guid BugId { get; set; } = Guid.NewGuid();
        public string BugDescription { get; set; }

        public override void TicketType()
        {
            Console.WriteLine("Creating a Feature Request Ticket");
            base.TicketType();
        }
    }
}
