using Gestion_de_Citas.Application.Contract;
using Gestion_de_Citas.Infrastructure.Interfaces;
using Gestion_De_Citas.Application.Dtos.EspecialIdad;

namespace Gestion_de_Citas.Application.Services
{
    public class EspecialIdadService : IEspecialIdadService
    {
        private readonly IEspecialIdadRepository _repository;

        public EspecialIdadService(IEspecialIdadRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EspecialIdadDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();
            return lista.Select(ToDto);
        }

        public async Task<EspecialIdadDto> GetByIdAsync(int Id)
        {
            ValIdarId(Id);
            var model = await _repository.GetByIdAsync(Id)
                ?? throw new KeyNotFoundException("La especialIdad no existe.");
            return ToDto(model);
        }

        public async Task<EspecialIdadDto> AddAsync(CreateEspecialIdadDto dto)
        {
            ValIdarNombre(dto.Nombre);

            var model = new ModeloEspecialIdad { Nombre = dto.Nombre.Trim() };
            var creado = await _repository.AddAsync(model);
            return ToDto(creado);
        }

        public async Task<EspecialIdadDto> UpdateAsync(UpdateEspecialIdadDto dto)
        {
            ValIdarId(dto.Id);
            ValIdarNombre(dto.Nombre);

            var model = await _repository.GetByIdAsync(dto.Id)
                ?? throw new KeyNotFoundException("La especialIdad no existe.");

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
        private static EspecialIdadDto ToDto(ModeloEspecialIdad m) => new()
        {
            Id = m.Id,
            Nombre = m.Nombre
        };
    }
}