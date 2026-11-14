using Gestion_de_Citas.domain;

namespace Gestion_de_Citas.Infrastructure.Interfaces

{

    public interface IDoctorRepository
    {

        Task<IEnumerable<ModeloDoctor>> GetAllAsync();

        Task<ModeloDoctor?> GetByIdAsync(int id);

        Task<ModeloDoctor> AddAsync(ModeloDoctor doctor);

        Task UpdateAsync(ModeloDoctor doctor);

        Task DeleteAsync(int id);

    }

}