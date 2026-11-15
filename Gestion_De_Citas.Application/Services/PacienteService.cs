using Gestion_de_Citas.Application.Contract;
using Gestion_de_Citas.Infrastructure.Interfaces;
using Gestion_De_Citas.Application.Dtos.Pacientes;

namespace Gestion_de_Citas.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IpacienteRepository _repository;

        public PacienteService(IpacienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PacienteDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();
            return lista.Select(ToDto);
        }

        public async Task<PacienteDto> GetByIdAsync(int Id)
        {
            ValIdarId(Id);
            var model = await _repository.GetByIdAsync(Id)
                ?? throw new KeyNotFoundException("El paciente no existe.");
            return ToDto(model);
        }

        public async Task<PacienteDto> AddAsync(CreatePacienteDto dto)
        {
            ValIdarNombre(dto.Nombre);

            var model = new ModeloPaciente { Nombre = dto.Nombre.Trim() };
            var creado = await _repository.AddAsync(model);
            return ToDto(creado);
        }

        public async Task<PacienteDto> UpdateAsync(UpdatePacienteDto dto)
        {
            ValIdarId(dto.Id);
            ValIdarNombre(dto.Nombre);

            var model = await _repository.GetByIdAsync(dto.Id)
                ?? throw new KeyNotFoundException("El paciente no existe.");

            model.Nombre = dto.Nombre.Trim();
            await _repository.UpdateAsync(model);
            return ToDto(model);
        }

        public async Task DeleteAsync(int Id)
        {
            ValIdarId(Id);
            _ = await _repository.GetByIdAsync(Id)
                ?? throw new KeyNotFoundException("La especialIdad no existe.");

            await _repository.DeleteAsync(Id);
        }

        // ---------- ValIdacione ----------
        private static void ValIdarId(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("El Id debe ser mayor que cero.");
        }

        private static void ValIdarNombre(string? nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.");
            if (nombre.Trim().Length < 3)
                throw new ArgumentException("El nombre debe tener al menos 3 caracteres.");
            if (nombre.Trim().Length > 100)
                throw new ArgumentException("El nombre no puede superar los 100 caracteres.");
        }

        // ---------- Mapeo Modelo -> Dto ----------
        private static PacienteDto ToDto(ModeloPaciente m) => new()
        {
            Id = m.Id,
            Nombre = m.Nombre
        };
    }
}