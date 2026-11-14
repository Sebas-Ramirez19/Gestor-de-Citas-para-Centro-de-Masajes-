using Gestion_de_Citas.domain;

namespace Gestion_de_Citas.Infrastructure.Interfaces

{

    public interface ICitaRepository
    {

        Task<IEnumerable<ModeloCita>> GetAllAsync();

        Task<ModeloCita?> GetByIdAsync(int id);

        Task<ModeloCita> AddAsync(ModeloCita cita);

        Task UpdateAsync(ModeloCita cita);

        Task DeleteAsync(int id);

    }

}