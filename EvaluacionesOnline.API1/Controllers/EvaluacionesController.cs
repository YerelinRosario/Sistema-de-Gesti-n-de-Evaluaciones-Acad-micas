using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.EvaluacionR;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionesOnline.API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluacionesController : ControllerBase
    {
        private readonly IEvaluacionRepository _evaluacionRepository;

        public EvaluacionesController(IEvaluacionRepository evaluacionRepository)
        {
            _evaluacionRepository = evaluacionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var evaluaciones = await _evaluacionRepository.GetAllAsync();
            return Ok(evaluaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evaluacion = await _evaluacionRepository.GetByIdAsync(id);
            if (evaluacion == null) return NotFound();
            return Ok(evaluacion);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Evaluacion evaluacion)
        {
            await _evaluacionRepository.AddAsync(evaluacion);
            return CreatedAtAction(nameof(GetById), new { id = evaluacion.Id }, evaluacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Evaluacion evaluacion)
        {
            if (id != evaluacion.Id) return BadRequest();
            await _evaluacionRepository.UpdateAsync(evaluacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _evaluacionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
