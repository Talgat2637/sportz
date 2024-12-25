using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportz.Models;

namespace sportz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTicketsController : ControllerBase
    {
        private readonly SportContext _context;

        public OrderTicketsController(SportContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(_context.OrderTickets.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var car = _context.OrderTickets.Find(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(OrderTicket car)
        {
            _context.OrderTickets.Add(car);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCar), new { id = car.OrderTicketId }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, OrderTicket car)
        {
            if (id != car.OrderTicketId) return BadRequest();

            _context.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.OrderTickets.FindAsync(id);
            if (car == null) return NotFound();

            _context.OrderTickets.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
