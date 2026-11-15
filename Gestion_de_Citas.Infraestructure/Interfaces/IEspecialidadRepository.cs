using Gestion_de_Citas.domain;


namespace Gestion_de_Citas.Infrastructure.Interfaces

{

    public interface IEspecialIdadRepository
    {

        Task<IEnumerable<ModeloEspecialIdad>> GetAllAsync();

        Task<ModeloEspecialIdad ?> GetByIdAsync(int Id);

        Task<ModeloEspecialIdad> AddAsync(ModeloEspecialIdad especialIdad);

        Task UpdateAsync(ModeloEspecialIdad especialIdad);

        Task DeleteAsync(int Id);

    }

}