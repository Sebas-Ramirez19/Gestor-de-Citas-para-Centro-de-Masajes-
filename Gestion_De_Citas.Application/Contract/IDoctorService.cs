using Gestion_De_Citas.Application.Dtos.Doctor;

namespace Gestion_de_Citas.Application.Contract
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllAsync();
        Task<DoctorDto> GetByIdAsync(int Id);
        Task<DoctorDto> AddAsync(CreateDoctorDto dto);
        Task<DoctorDto> UpdateAsync(UpdateDoctorDto dto);
        Task DeleteAsync(int Id);
    }
}