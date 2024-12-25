using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportz.Models;

namespace sportz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly SportContext _context;

        public VenuesController(SportContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(_context.Venues.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var car = _context.Venues.Find(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(Venue car)
        {
            _context.Venues.Add(car);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCar), new { id = car.VenueId }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, Venue car)
        {
            if (id != car.VenueId) return BadRequest();

            _context.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Venues.FindAsync(id);
            if (car == null) return NotFound();

            _context.Venues.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
