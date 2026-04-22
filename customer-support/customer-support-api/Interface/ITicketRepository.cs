using customer_support_api.Dtos;
using customer_support_api.Enums;
using customer_support_api.Models;

namespace customer_support_api.Interface
{
    public interface ITicketRepository
    {
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(Guid id);
        List<Ticket> GetTicketByStatus(Status status);
        List<Ticket> GetTicketByDateRange(DateTime date);
        List<Ticket> GetTicketByType(string type);
        void AddTicket(TicketAddDto dto);
        void UpdateTicket(Guid id, TicketUpdateDto dto);
        bool DeleteTicket(Guid id);
    }
}
