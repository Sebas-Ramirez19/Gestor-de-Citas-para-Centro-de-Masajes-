using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_De_Citas.Models;

namespace Gestion_De_Citas
{


    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DoctoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Doctores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctores()
        {
            return await _context.Doctores.ToListAsync();
        }

        // GET: api/Doctores/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int Id)
        {
            var doctor = await _context.Doctores.FindAsync(Id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }
        

        // PUT: api/Doctores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkId=2123754
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutDoctor(int Id, Doctor doctor)
        {
            if (Id != doctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(Id))
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
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            _context.Doctores.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { Id = doctor.Id }, doctor);
        }

        // DELETE: api/Doctores/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDoctor(int Id)
        {
            var doctor = await _context.Doctores.FindAsync(Id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctores.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(int Id)
        {
            return _context.Doctores.Any(e => e.Id == Id);
        }
    }
}