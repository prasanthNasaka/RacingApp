using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infinitemoto.DTOs;
using infinitemoto.Models;
using infinitemoto.LookUps;

namespace infinitemoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCategoryController : ControllerBase
    {
        private readonly DummyProjectSqlContext _context;

        public EventCategoryController(DummyProjectSqlContext context)
        {
            _context = context;
        }

        // GET: api/EventCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eventcategory>>> GetEventCategories([FromQuery] CategoryEnum? category)
        {
            IQueryable<Eventcategory> query = _context.Eventcategories;

            // Apply filter if category is provided
            if (category.HasValue)
            {
                string categoryString = category switch
                {
                    CategoryEnum.CC1600 => "1600cc",
                    CategoryEnum.CC1800 => "1800cc",
                    _ => throw new ArgumentOutOfRangeException()
                };

                query = query.Where(e => e.Category == categoryString);
            }

            var result = await query.ToListAsync();
            return Ok(result);
        }

        // GET: api/EventCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eventcategory>> GetEventCategory(int id)
        {
            var eventCategory = await _context.Eventcategories.FindAsync(id);

            if (eventCategory == null)
            {
                return NotFound();
            }

            return Ok(eventCategory);
        }

        // POST: api/EventCategory
        [HttpPost]
        public async Task<ActionResult<Eventcategory>> PostEventCategory(Eventcategory eventCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Eventcategories.Add(eventCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEventCategory), new { id = eventCategory.Eventid }, eventCategory);
        }

        // PUT: api/EventCategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventCategory(int id, Eventcategory eventCategory)
        {
            if (id != eventCategory.Eventid)
            {
                return BadRequest("ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(eventCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/EventCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventCategory(int id)
        {
            var eventCategory = await _context.Eventcategories.FindAsync(id);
            if (eventCategory == null)
            {
                return NotFound();
            }

            _context.Eventcategories.Remove(eventCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventCategoryExists(int id)
        {
            return _context.Eventcategories.Any(e => e.Eventid == id);
        }
    }
}
