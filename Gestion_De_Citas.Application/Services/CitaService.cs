using Gestion_de_Citas.Application.Contract;
using Gestion_de_Citas.Infrastructure.Interfaces;
using Gestion_De_Citas.Application.Dtos.Citas;

namespace Gestion_de_Citas.Application.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _repository;

        public CitaService(ICitaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CitaDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();
            return lista.Select(ToDto);
        }

        public async Task<CitaDto> GetByIdAsync(int Id)
        {
            ValIdarId(Id);
            var model = await _repository.GetByIdAsync(Id)
                ?? throw new KeyNotFoundException("La cita no existe.");
            return ToDto(model);
        }

        public async Task<CitaDto> AddAsync(CreateCitaDto dto)
        {
            ValidarNombre(dto.Nombre);

            var model = new ModeloCita { Nombre = dto.Nombre.Trim() };
            var creado = await _repository.AddAsync(model);
            return ToDto(creado);
        }

        public async Task<CitaDto> UpdateAsync(UpdateCItaDto dto)
        {
            ValIdarId(dto.Id);
            ValidarNombre(dto.Nombre);

            var model = await _repository.GetByIdAsync(dto.Id)
                ?? throw new KeyNotFoundException("La cita no existe.");

            model.Nombre = dto.Nombre.Trim();
            await _repository.UpdateAsync(model);
            return ToDto(model);
        }

        public async Task DeleteAsync(int Id)
        {
            ValIdarId(Id);
            _ = await _repository.GetByIdAsync(Id)
                ?? throw new KeyNotFoundException("El doctor no existe.");

            await _repository.DeleteAsync(Id);
        }

        // ---------- ValIdacione ----------
        private static void ValIdarId(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("El Id debe ser mayor que cero.");
        }

        
        // ---------- Mapeo Modelo -> Dto ----------
        private static CitaDto ToDto(ModeloCita m) => new()
        {
            Id = m.Id,

            Fecha=m.Fecha,
            Pacientes = m.Pacientes
        };
    }
}