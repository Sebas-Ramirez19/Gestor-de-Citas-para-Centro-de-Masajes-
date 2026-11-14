using Gestion_de_Citas.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Gestion_de_Citas.domain;
using Gestion_de_Citas.Infrastructure.Interfaces;

namespace Gestion_de_Citas.Infraestructure.Repositories

{

    public class PacienteRepository : IpacienteRepository
    {

        private readonly ApplicationDbContext _context;


        public PacienteRepository(ApplicationDbContext context)

        {

            _context = context;

        }


        public async Task<IEnumerable<ModeloPaciente>> GetAllAsync()

        {

            return await _context.Pacientes

                .Include(p => p.Nombre)

                .ToListAsync();

        }


        public async Task<ModeloPaciente> GetByIdAsync(int id)

        {

            return await _context.Pacientes

                .Include(p => p.Nombre)

                .FirstOrDefaultAsync(p => p.id == id);

        }


        public async Task<ModeloPaciente> AddAsync(ModeloPaciente paciente)

        {

            _context.Pacientes.Add(paciente);

            await _context.SaveChangesAsync();

            return paciente;

        }


        public async Task UpdateAsync(ModeloPaciente paciente   )

        {

            _context.Pacientes.Update(paciente);

            await _context.SaveChangesAsync();

        }


        public async Task DeleteAsync(int id)

        {

            var doctor = await _context.Doctor.FindAsync(id);


            if (doctor != null)
            {

                _context.Doctor.Remove(doctor);

                await _context.SaveChangesAsync();

            }

        }

    }

}