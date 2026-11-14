using Gestion_de_Citas.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Gestion_de_Citas.domain;
using Gestion_de_Citas.Infrastructure.Interfaces;

namespace Gestion_de_Citas.Infraestructure.Repositories

{

    public class DoctorRepository : IDoctorRepository
    {

        private readonly ApplicationDbContext _context;


        public DoctorRepository(ApplicationDbContext context)

        {

            _context = context;

        }


        public async Task<IEnumerable<ModeloDoctor>> GetAllAsync()

        {

            return await _context.Doctor

                .Include(a => a.Nombre)

                .Include(a => a.Especialidad)

                .ToListAsync();

        }


        public async Task<ModeloDoctor> GetByIdAsync(int id)

        {

            return await _context.Doctor

                .Include(a => a.Nombre)

                .Include(a => a.Especialidad)

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
