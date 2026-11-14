using Gestion_de_Citas.domain;

namespace Gestion_de_Citas.Infrastructure.Interfaces

{

    public interface IEspecialidadRepository
    {

        Task<IEnumerable<ModeloEspecialidad>> GetAllAsync();

        Task<ModeloEspecialidad ?> GetByIdAsync(int id);

        Task<ModeloEspecialidad> AddAsync(ModeloEspecialidad especialidad);

        Task UpdateAsync(ModeloEspecialidad especialidad);

        Task DeleteAsync(int id);

    }

}