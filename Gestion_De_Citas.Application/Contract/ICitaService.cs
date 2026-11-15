using Gestion_De_Citas.Application.Dtos.Citas;

namespace Gestion_de_Citas.Application.Contract
{
    public interface ICitaService
    {
        Task<IEnumerable<CitaDto>> GetAllAsync();
        Task<CitaDto> GetByIdAsync(int Id);
        Task<CitaDto> AddAsync(CreateCitaDto dto);
        Task<CitaDto> UpdateAsync(UpdateCItaDto dto);
        Task DeleteAsync(int Id);
    }
}