using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.RespuestaR;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionesOnline.API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestasController : ControllerBase
    {
        private readonly IRespuestaRepository _respuestaRepository;

        public RespuestasController(IRespuestaRepository respuestaRepository)
        {
            _respuestaRepository = respuestaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var respuestas = await _respuestaRepository.GetAllAsync();
            return Ok(respuestas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var respuesta = await _respuestaRepository.GetByIdAsync(id);
            if (respuesta == null) return NotFound();
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Respuesta respuesta)
        {
            await _respuestaRepository.AddAsync(respuesta);
            return CreatedAtAction(nameof(GetById), new { id = respuesta.Id }, respuesta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Respuesta respuesta)
        {
            if (id != respuesta.Id) return BadRequest();
            await _respuestaRepository.UpdateAsync(respuesta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _respuestaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
