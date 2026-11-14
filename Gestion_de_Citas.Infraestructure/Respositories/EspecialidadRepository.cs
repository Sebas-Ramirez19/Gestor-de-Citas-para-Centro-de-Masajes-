using Gestion_de_Citas.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Gestion_de_Citas.domain;
using Gestion_de_Citas.Infrastructure.Interfaces;

namespace Gestion_de_Citas.Infraestructure.Repositories

{

    public class EspecialidadRepository : IEspecialidadRepository
    {

        private readonly ApplicationDbContext _context;


        public EspecialidadRepository(ApplicationDbContext context)

        {

            _context = context;

        }

        public async Task AddAsync(ModeloEspecialidad especialidad)
        {
            await _context.Especialidad.AddAsync(especialidad);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ModeloEspecialidad especialidad)
        {
            _context.Especialidad.Update(especialidad);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<ModeloEspecialidad>> GetAllAsync()

        {

            return await _context.Especialidad

                .Include(a => a.Nombre)

                .ToListAsync();

        }


        public async Task<ModeloEspecialidad> GetByIdAsync(int id)

        {

            return await _context.Especialidad

                .Include(a => a.Nombre)


                .FirstOrDefaultAsync(a => a.id == id);

        }


        public async Task<ModeloDoctor> AddAsync(ModeloDoctor doctor)

        {

            _context.Doctor.Add(doctor);

            await _context.SaveChangesAsync();

            return doctor;

        }


        public async Task UpdateAsync(ModeloDoctor doctor)

        {

            _context.Doctor.Update(doctor);

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