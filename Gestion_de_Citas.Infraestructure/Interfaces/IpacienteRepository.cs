using Gestion_de_Citas.domain;

namespace Gestion_de_Citas.Infrastructure.Interfaces

{

    public interface IpacienteRepository
    {

        Task<IEnumerable<ModeloPaciente>> GetAllAsync();

        Task<ModeloPaciente?> GetByIdAsync(int id);

        Task<ModeloPaciente> AddAsync(ModeloPaciente paciente);

        Task UpdateAsync(ModeloPaciente paciente);

        Task DeleteAsync(int id);

    }

}