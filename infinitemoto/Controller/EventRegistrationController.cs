using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using infinitemoto.Models;
using System.Threading.Tasks;

namespace infinitemoto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventregistrationController : ControllerBase
    {
        private readonly DummyProjectSqlContext _context;

        public EventregistrationController(DummyProjectSqlContext context)
        {
            _context = context;
        }

        // GET: api/Eventregistration
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _context.Eventregistrations.ToListAsync();
            if (events == null || events.Count == 0)
            {
                return NotFound(new { message = "No events found." });
            }
            return Ok(new { message = "Events retrieved successfully.", data = events });
        }

        // GET: api/Eventregistration/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var eventRegistration = await _context.Eventregistrations.FindAsync(id);
            if (eventRegistration == null)
            {
                return NotFound(new { message = $"Event with ID {id} not found." });
            }
            return Ok(new { message = "Event retrieved successfully.", data = eventRegistration });
        }

        // POST: api/Eventregistration
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Eventregistration eventRegistration)
        {
            


            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid data.", errors = ModelState });
            }

            try
            {
                _context.Eventregistrations.Add(eventRegistration);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = eventRegistration.Eventid }, new { message = "Event created successfully.", data = eventRegistration });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error occurred while creating the event.", error = ex.Message });
            }
        }

        // PUT: api/Eventregistration/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Eventregistration eventRegistration)
        {
            if (id != eventRegistration.Eventid)
            {
                return BadRequest(new { message = "ID mismatch. Ensure the ID in the URL matches the request body." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid data.", errors = ModelState });
            }

            _context.Entry(eventRegistration).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventRegistrationExists(id))
                {
                    return NotFound(new { message = $"Event with ID {id} not found for update." });
                }
                throw;
            }

            return Ok(new { message = "Event updated successfully.", data = eventRegistration });
        }

        // DELETE: api/Eventregistration/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eventRegistration = await _context.Eventregistrations.FindAsync(id);
            if (eventRegistration == null)
            {
                return NotFound(new { message = $"Event with ID {id} not found." });
            }

            _context.Eventregistrations.Remove(eventRegistration);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Event deleted successfully." });
        }

        private bool EventRegistrationExists(int id)
        {
            return _context.Eventregistrations.Any(e => e.Eventid == id);
        }
    }
}
