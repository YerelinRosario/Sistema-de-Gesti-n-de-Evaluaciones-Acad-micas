using EvaluacionesOnline.Application.Contract;
using EvaluacionesOnline.Application.Core;
using EvaluacionesOnline.Application.Dtos;
using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.CalificacionR;

public class CalificacionService : BaseService, ICalificacionService
{
    private readonly ICalificacionRepository _repository;

    public CalificacionService(ICalificacionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CalificacionDto>> GetAllAsync()
    {
        var calificaciones = await _repository.GetAllAsync();

        return calificaciones.Select(c => new CalificacionDto
        {
            Id = c.Id,
            Nota = (int)c.Nota, // Conversión explícita si Nota es decimal
            EstudianteId = c.EstudianteId,
            EstudianteNombre = c.Estudiante?.Nombre ?? "Sin nombre", // Manejo de nulos
            EvaluacionId = c.EvaluacionId,
            EvaluacionTitulo = c.Evaluacion?.Titulo ?? "Sin título", // Manejo de nulos
            FechaCalificacion = DateTime.Now // Cambiar a c.FechaCalificacion si existe en la entidad
        });
    }

    public async Task<CalificacionDto?> GetByIdAsync(int id)
    {
        var calificacion = await _repository.GetByIdAsync(id);

        if (calificacion == null)
            return null;

        return new CalificacionDto
        {
            Id = calificacion.Id,
            Nota = (int)calificacion.Nota, // Conversión explícita
            EstudianteId = calificacion.EstudianteId,
            EstudianteNombre = calificacion.Estudiante?.Nombre ?? "Sin nombre",
            EvaluacionId = calificacion.EvaluacionId,
            EvaluacionTitulo = calificacion.Evaluacion?.Titulo ?? "Sin título",
            FechaCalificacion = DateTime.Now
        };
    }

    public async Task<ServiceResult> CreateAsync(CalificacionDto calificacionDto)
    {
        try
        {
            var calificacion = new Calificacion
            {
                Nota = (int)calificacionDto.Nota, // Conversión explícita
                EstudianteId = calificacionDto.EstudianteId,
                EvaluacionId = calificacionDto.EvaluacionId
            };

            await _repository.AddAsync(calificacion);

            return ServiceResult.Success("Calificación creada exitosamente.");
        }
        catch (Exception ex)
        {
            return ServiceResult.Failure($"Error al crear la calificación: {ex.Message}");
        }
    }

    public async Task<ServiceResult> UpdateAsync(int id, CalificacionDto calificacionDto)
    {
        try
        {
            var existingCalificacion = await _repository.GetByIdAsync(id);

            if (existingCalificacion == null)
                return ServiceResult.Failure($"Calificación con ID {id} no encontrada.");

            existingCalificacion.Nota = (int)calificacionDto.Nota; // Conversión explícita
            existingCalificacion.EstudianteId = calificacionDto.EstudianteId;
            existingCalificacion.EvaluacionId = calificacionDto.EvaluacionId;

            await _repository.UpdateAsync(existingCalificacion);

            return ServiceResult.Success("Calificación actualizada exitosamente.");
        }
        catch (Exception ex)
        {
            return ServiceResult.Failure($"Error al actualizar la calificación: {ex.Message}");
        }
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        try
        {
            var calificacion = await _repository.GetByIdAsync(id);

            if (calificacion == null)
                return ServiceResult.Failure($"Calificación con ID {id} no encontrada.");

            await _repository.DeleteAsync(id);

            return ServiceResult.Success("Calificación eliminada exitosamente.");
        }
        catch (Exception ex)
        {
            return ServiceResult.Failure($"Error al eliminar la calificación: {ex.Message}");
        }
    }
}

