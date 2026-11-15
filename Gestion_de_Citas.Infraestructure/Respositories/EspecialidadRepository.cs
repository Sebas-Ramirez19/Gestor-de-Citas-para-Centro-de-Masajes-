using Gestion_de_Citas.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Gestion_de_Citas.domain;
using Gestion_de_Citas.Infrastructure.Interfaces;



namespace Gestion_de_Citas.Infraestructure.Repositories

{

    public class EspecialIdadRepository : IEspecialIdadRepository
    {

        private readonly ApplicationDbContext _context;


        public EspecialIdadRepository(ApplicationDbContext context)

        {

            _context = context;

        }

        public async Task<IEnumerable<ModeloEspecialIdad>> GetAllAsync()
        {
            return await _context.EspecialIdad.ToListAsync();
        }

        public async Task<ModeloEspecialIdad?> GetByIdAsync(int Id)
        {
            return await _context.EspecialIdad.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<ModeloEspecialIdad> AddAsync(ModeloEspecialIdad especialIdad)
        {
            _context.EspecialIdad.Add(especialIdad);
            await _context.SaveChangesAsync();
            return especialIdad;
        }

        public async Task UpdateAsync(ModeloEspecialIdad especialIdad)
        {
            _context.EspecialIdad.Update(especialIdad);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var especialIdad = await _context.EspecialIdad.FindAsync(Id);
            if (especialIdad != null)
            {
                _context.EspecialIdad.Remove(especialIdad);
                await _context.SaveChangesAsync();
            }
        }
    }
}