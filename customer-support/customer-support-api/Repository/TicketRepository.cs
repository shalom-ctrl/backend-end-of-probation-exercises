using customer_support_api.Data;
using customer_support_api.Dtos;
using customer_support_api.Enums;
using customer_support_api.Interface;
using customer_support_api.Models;

namespace customer_support_api.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private bool HasConflict(Ticket ticket)
        {
            return _dbContext.Tickets.Any(t => t.Subject == ticket.Subject && t.Id != ticket.Id);
        }

        public void AddTicket(TicketAddDto dto)
        {
            var newTicket = new Ticket
            {
                Id = Guid.NewGuid(),
                Subject = dto.Subject,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt,
                status = dto.status
            };
            if(HasConflict(newTicket))
            {
                throw new InvalidOperationException("A ticket with the same subject and Id already exists.");
            }

            _dbContext.Tickets.Add(newTicket);
            _dbContext.SaveChanges();
        }

        public bool DeleteTicket(Guid id)
        {
            var existingTicket = _dbContext.Tickets.Find(id);
           if(existingTicket == null)       
            {
                return false;
            }
            _dbContext.Tickets.Remove(existingTicket);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Ticket> GetAllTickets()
        {
           var tickets = _dbContext.Tickets.ToList();
            return tickets;
        }

        public List<Ticket> GetTicketByDateRange(DateTime date)
        {
            var tickets = _dbContext.Tickets.Where(t => t.CreatedAt.Date == date.Date).ToList();
            return tickets;
        }

        public Ticket GetTicketById(Guid id)
        {
           var ticket = _dbContext.Tickets.FirstOrDefault(t => t.Id == id);
            return ticket;
        }

        public List<Ticket> GetTicketByStatus(Status status)
        {
           var tickets = _dbContext.Tickets.Where(t => t.status == status).ToList();
            return tickets;
        }

        public List<Ticket> GetTicketByType(TicketType type)
        {
            var tickets = _dbContext.Tickets.Where(t => t.type == type).ToList();
            return tickets;
        }

        public void UpdateTicket(Guid id, TicketUpdateDto dto)
        {
            var existingTicket = _dbContext.Tickets.Find(id);
            if(existingTicket == null)
            {
                return;
            }
            existingTicket.Subject = dto.Subject;
            existingTicket.Description = dto.Description;
            existingTicket.CreatedAt = dto.CreatedAt;
            existingTicket.status = dto.status;
            _dbContext.SaveChanges();
        }
    }
}
