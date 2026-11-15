using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_De_Citas.Models;

namespace Gestion_De_Citas
{


    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CitasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCita()
        {
            return await _context.Citas.ToListAsync();
        }

        // GET: api/Cita/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Cita>> GetCita(int Id)
        {
            var cita = await _context.Citas.FindAsync(Id);

            if (cita == null)
            {
                return NotFound();
            }

            return cita;
        }

        // PUT: api/Cita/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkId=2123754
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutCita(int Id, Cita cita)
        {
            if (Id != cita.Id)
            {
                return BadRequest();
            }

            _context.Entry(cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(Id))
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

        // POST: api/Cita
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkId=2123754
        [HttpPost]
        public async Task<ActionResult<Cita>> PostCita(Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCita", new { Id = cita.Id }, cita);
        }

        // DELETE: api/Cita/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCita(int Id)
        {
            var cita = await _context.Citas.FindAsync(Id);
            if (cita == null)
            {
                return NotFound();
            }

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitaExists(int Id)
        {
            return _context.Citas.Any(e => e.Id == Id);
        }
    }
}