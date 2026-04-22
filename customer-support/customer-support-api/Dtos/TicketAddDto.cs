using customer_support_api.Enums;

namespace customer_support_api.Dtos
{
    public class TicketAddDto
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Status status { get; set; }
    }
}
