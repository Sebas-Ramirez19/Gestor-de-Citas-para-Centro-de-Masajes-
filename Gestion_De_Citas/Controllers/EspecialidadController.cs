using Gestion_de_Citas.Application.Contract;
using Gestion_De_Citas.Application.Dtos;
using Gestion_De_Citas.Application.Dtos.EspecialIdad;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_De_Citas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialIdadController : ControllerBase
    {
        private readonly IEspecialIdadService _service;

        public EspecialIdadController(IEspecialIdadService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try { return Ok(await _service.GetByIdAsync(Id)); }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateEspecialIdadDto dto)
        {
            try { return Ok(await _service.AddAsync(dto)); }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateEspecialIdadDto dto)
        {
            try { return Ok(await _service.UpdateAsync(dto)); }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try { await _service.DeleteAsync(Id); return NoContent(); }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
        }
    }
}