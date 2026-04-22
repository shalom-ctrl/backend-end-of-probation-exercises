using customer_support_api.Enums;

namespace customer_support_api.Models
{
    public class BugReport : Ticket
    {
        public Priority priority { get; set; }
    }
}
