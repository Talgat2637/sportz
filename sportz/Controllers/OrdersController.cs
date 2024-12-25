using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportz.Models;

namespace sportz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly SportContext _context;

        public OrdersController(SportContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(_context.Orders.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var car = _context.Orders.Find(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(Order car)
        {
            _context.Orders.Add(car);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCar), new { id = car.OrderId }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, Order car)
        {
            if (id != car.OrderId) return BadRequest();

            _context.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Orders.FindAsync(id);
            if (car == null) return NotFound();

            _context.Orders.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
