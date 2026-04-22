using customer_support_api.Dtos;
using customer_support_api.Enums;
using customer_support_api.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace customer_support_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

            [HttpGet]
            public IActionResult GetAllTickets()
        {
            var tickets = _ticketRepository.GetAllTickets();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public IActionResult GetTicket(Guid id)
        {
            var ticket = _ticketRepository.GetTicketById(id);
            if(ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpGet("daterange")]
        public IActionResult GetTicketsByDateRange(DateTime date)
        {
            var tickets = _ticketRepository.GetTicketByDateRange(date).OrderBy(t => t.CreatedAt).ToList();
            return Ok(tickets);
        }

        [HttpGet("type")]
        public IActionResult GetTicketsByType(string type)
        {
            var tickets = _ticketRepository.GetTicketByType(type);
            return Ok(tickets);
        }

        [HttpPost]
        public IActionResult AddTicket(TicketAddDto dto)
        {
            try
            {
                _ticketRepository.AddTicket(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction(nameof(GetTicket), new { id = dto.CreatedAt}, dto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTicket(Guid id, TicketUpdateDto dto)
        {
            try
            {
                _ticketRepository.UpdateTicket(id, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(Guid id)
        {
            var result = _ticketRepository.DeleteTicket(id);
            if(!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
