using Gestion_De_Citas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestion_De_Citas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
        public class PacienteController : ControllerBase
        {
            private readonly AppDbContext _context;
            public PacienteController(AppDbContext context)
            {
                _context = context;
            }

            // GET: api/Cita
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Paciente>>> GetCita()
            {
                return await _context.Pacientes.ToListAsync();
            }

            // GET: api/Cita/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Paciente>> GetCita(int id)
            {
                var paciente = await _context.Pacientes.FindAsync(id);

                if (paciente == null)
                {
                    return NotFound(); // devuelveme  un 404 si no existe la cita   
                }

                return paciente;
            }



            [HttpPut("{id}")]
            public async Task<IActionResult> PutCita(int id, Paciente paciente)
            {
                if (id != paciente.Id)
                {
                    return BadRequest();
                }

                _context.Entry(paciente).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(id))
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

        //[HttpPost]
        //public async Task<ActionResult<Paciente>> Postpaciente(Paciente paciente)
        //{
        //    _context.Citas.Add(paciente);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCita", new { id = paciente.Id }, paciente);
        //}

        // DELETE: api/Cita/5
        [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCita(int id)
            {
                var paciente = await _context.Citas.FindAsync(id);
                if (paciente == null)
                {
                    return NotFound();
                }

                _context.Citas.Remove(paciente);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool CitaExists(int id)
            {
                return _context.Citas.Any(e => e.Id == id);
            }
        }
    
}
