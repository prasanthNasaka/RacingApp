// using infinitemoto.BusinessServices;
// using infinitemoto.Models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace infinitemoto.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     [Authorize]
//     public class RegistrationController : ControllerBase
//     {
//         private readonly DummyProjectSqlContext _context;

//         public RegistrationController(DummyProjectSqlContext context)
//         {
//             _context = context;
//         }

//         // GET: api/Registration
//         [HttpGet]
//         public async Task<IActionResult> GetAll()
//         {
//             var registrations = await _context.Registrations.ToListAsync();
//             if (registrations == null || !registrations.Any())
//             {
//                 return NotFound(new { message = "No registrations found." });
//             }
//             return Ok(new { message = "Registrations retrieved successfully.", data = registrations });
//         }

//         // GET: api/Registration/{id}
//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetById(int id)
//         {
//             var registration = await _context.Registrations.FindAsync(id);

//             if (registration == null)
//             {
//                 return NotFound(new { message = $"Registration with ID {id} not found." });
//             }
//             return Ok(new { message = "Registration retrieved successfully.", data = registration });
//         }

//         // POST: api/Registration
//         [HttpPost]
//         public async Task<IActionResult> Create([FromBody] Registration registration)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(new { message = "Invalid data.", errors = ModelState });
//             }

//             _context.Registrations.Add(registration);
//             await _context.SaveChangesAsync();
//             return CreatedAtAction(nameof(GetById), new { id = registration.Id }, new { message = "Registration created successfully.", data = registration });
//         }

//         // PUT: api/Registration/{id}
//         [HttpPut("{id}")]
//         public async Task<IActionResult> Update(int id, [FromBody] Registration registration)
//         {
//             if (id != registration.Id)
//             {
//                 return BadRequest(new { message = "ID mismatch. Ensure the ID in the URL matches the request body." });
//             }

//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(new { message = "Invalid data.", errors = ModelState });
//             }

//             _context.Entry(registration).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!RegistrationExists(id))
//                 {
//                     return NotFound(new { message = $"Registration with ID {id} not found for update." });
//                 }
//                 throw;
//             }

//             return Ok(new { message = "Registration updated successfully.", data = registration });
//         }

//         // DELETE: api/Registration/{id}
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> Delete(int id)
//         {
//             var registration = await _context.Registrations.FindAsync(id);
//             if (registration == null)
//             {
//                 return NotFound(new { message = $"Registration with ID {id} not found." });
//             }

//             _context.Registrations.Remove(registration);
//             await _context.SaveChangesAsync();
//             return Ok(new { message = "Registration deleted successfully." });
//         }

//         private bool RegistrationExists(int id)
//         {
//             return _context.Registrations.Any(e => e.Id == id);
//         }
//     }
// }
