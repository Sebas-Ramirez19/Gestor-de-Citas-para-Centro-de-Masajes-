using Gestion_De_Citas.Application.Dtos.EspecialIdad;
using Gestion_De_Citas.Application.Dtos.Pacientes;

namespace Gestion_de_Citas.Application.Contract
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDto>> GetAllAsync();
        Task<PacienteDto> GetByIdAsync(int Id);
        Task<PacienteDto> AddAsync(CreatePacienteDto dto);
        Task<PacienteDto> UpdateAsync(UpdatePacienteDto dto);
        Task DeleteAsync(int Id);
    }
}