using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.CalificacionR;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionesOnline.API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionesController : ControllerBase
    {
        private readonly ICalificacionRepository _calificacionRepository;

        public CalificacionesController(ICalificacionRepository calificacionRepository)
        {
            _calificacionRepository = calificacionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var calificaciones = await _calificacionRepository.GetAllAsync();
            return Ok(calificaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var calificacion = await _calificacionRepository.GetByIdAsync(id);
            if (calificacion == null) return NotFound();
            return Ok(calificacion);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Calificacion calificacion)
        {
            await _calificacionRepository.AddAsync(calificacion);
            return CreatedAtAction(nameof(GetById), new { id = calificacion.Id }, calificacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Calificacion calificacion)
        {
            if (id != calificacion.Id) return BadRequest();
            await _calificacionRepository.UpdateAsync(calificacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _calificacionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

