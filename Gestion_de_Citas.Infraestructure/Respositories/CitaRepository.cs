using Gestion_de_Citas.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Gestion_de_Citas.domain;
using Gestion_de_Citas.Infrastructure.Interfaces;

namespace Gestion_de_Citas.Infraestructure.Repositories

{

    public class CitaRepository : ICitaRepository
    {

        private readonly ApplicationDbContext _context;


        public CitaRepository(ApplicationDbContext context)

        {

            _context = context;

        }


        public async Task<IEnumerable<ModeloCita>> GetAllAsync()

        {

            return await _context.Cita

                .Include(c => c.Pacientes)

                .ToListAsync();

        }


        public async Task<ModeloCita> GetByIdAsync(int Id)

        {

            return await _context.Cita

                .Include(c => c.Pacientes)

                .FirstOrDefaultAsync(c => c.Id == Id);
            
        }


        public async Task<ModeloCita> AddAsync(ModeloCita cita)

        {

            _context.Cita.Add(cita);

            await _context.SaveChangesAsync();

            return cita;

        }


        public async Task UpdateAsync(ModeloCita cita)

        {

            _context.Cita.Update(cita);

            await _context.SaveChangesAsync();

        }


        public async Task DeleteAsync(int Id)

        {

            var cita = await _context.Cita.FindAsync(Id);


            if (cita != null)
            {

                _context.Cita.Remove(cita);

                await _context.SaveChangesAsync();

            }

        }

    }

}