using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportz.Models;

namespace sportz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SportContext _context;

        public UserController(SportContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var car = _context.Users.Find(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(User car)
        {
            _context.Users.Add(car);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCar), new { id = car.UserId }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, User car)
        {
            if (id != car.UserId) return BadRequest();

            _context.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Users.FindAsync(id);
            if (car == null) return NotFound();

            _context.Users.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
