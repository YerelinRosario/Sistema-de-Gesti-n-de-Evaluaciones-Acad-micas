using EvaluacionesOnline.Application.Dtos;
using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.EstudianteR;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionesOnline.API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstudiantesController(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estudiantes = await _estudianteRepository.GetAllAsync();
            if (estudiantes == null || !estudiantes.Any())
                return NotFound("No se encontraron estudiantes.");

            return Ok(estudiantes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estudiante = await _estudianteRepository.GetByIdAsync(id);
            if (estudiante == null)
                return NotFound($"Estudiante con ID {id} no encontrado.");

            return Ok(estudiante);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstudianteDto estudianteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estudiante = new Estudiante
            {
                Nombre = estudianteDto.Nombre,
                Apellido = estudianteDto.Apellido,
                Email = estudianteDto.Email,
                Contraseña = estudianteDto.Contraseña
            };

            await _estudianteRepository.AddAsync(estudiante);
            return CreatedAtAction(nameof(GetById), new { id = estudiante.Id }, estudiante);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Estudiante estudiante)
        {
            if (id != estudiante.Id)
                return BadRequest("El ID en la ruta no coincide con el ID del modelo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingEstudiante = await _estudianteRepository.GetByIdAsync(id);
            if (existingEstudiante == null)
                return NotFound($"Estudiante con ID {id} no encontrado.");

            await _estudianteRepository.UpdateAsync(estudiante);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estudiante = await _estudianteRepository.GetByIdAsync(id);
            if (estudiante == null)
                return NotFound($"Estudiante con ID {id} no encontrado.");

            await _estudianteRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
