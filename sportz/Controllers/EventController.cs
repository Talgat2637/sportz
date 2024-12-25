using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportz.Class;
using sportz.Models;

namespace sportz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
       
       
            private readonly SportContext _context;

            public EventController(SportContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult GetCars()
            {
                return Ok(_context.Events.ToList());
            }

            [HttpGet("{id}")]
            public IActionResult GetCar(int id)
            {
                var car = _context.Events.Find(id);
                if (car == null) return NotFound();
                return Ok(car);
            }

            [HttpPost]
            public async Task<ActionResult<Event>> CreateCar(EventClassRequest request)
            {
                Event @event = new Event();
                @event.EventName = request.EventName;
                @event.EventDate = @event.EventDate;
                @event.VenueId = request.VenueID;
                @event.SportType = request.SportType;
                @event.Description = request.Description;

                _context.Events.Add(@event);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCar), new { id = @event.EventId }, @event);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateCar(int id, Event car)
            {
                if (id != car.EventId) return BadRequest();

                _context.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCar(int id)
            {
                var car = await _context.Events.FindAsync(id);
                if (car == null) return NotFound();

                _context.Events.Remove(car);
                await _context.SaveChangesAsync();

                return NoContent();
            }
    }   
}
