using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.ProfesorR;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionesOnline.API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesorRepository _profesorRepository;

        public ProfesoresController(IProfesorRepository profesorRepository)
        {
            _profesorRepository = profesorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profesores = await _profesorRepository.GetAllAsync();
            return Ok(profesores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profesor = await _profesorRepository.GetByIdAsync(id);
            if (profesor == null) return NotFound();
            return Ok(profesor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Profesor profesor)
        {
            await _profesorRepository.AddAsync(profesor);
            return CreatedAtAction(nameof(GetById), new { id = profesor.Id }, profesor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Profesor profesor)
        {
            if (id != profesor.Id) return BadRequest();
            await _profesorRepository.UpdateAsync(profesor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _profesorRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

