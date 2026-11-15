using Gestion_De_Citas.Application.Dtos.EspecialIdad;

namespace Gestion_de_Citas.Application.Contract
{
    public interface IEspecialIdadService
    {
        Task<IEnumerable<EspecialIdadDto>> GetAllAsync();
        Task<EspecialIdadDto> GetByIdAsync(int Id);
        Task<EspecialIdadDto> AddAsync(CreateEspecialIdadDto dto);
        Task<EspecialIdadDto> UpdateAsync(UpdateEspecialIdadDto dto);
        Task DeleteAsync(int Id);
    }
}