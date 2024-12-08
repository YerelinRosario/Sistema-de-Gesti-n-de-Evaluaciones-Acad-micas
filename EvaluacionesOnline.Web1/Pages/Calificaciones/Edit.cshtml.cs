using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Calificaciones
{
    public class EditModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public CalificacionDto Calificacion { get; set; }

        public List<EstudianteDto> Estudiantes { get; set; }
        public List<EvaluacionDto> Evaluaciones { get; set; }

        public EditModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Calificacion = await _apiService.GetAsync<CalificacionDto>($"Calificaciones/{id}");
            if (Calificacion == null)
            {
                return NotFound();
            }

            Estudiantes = await _apiService.GetAsync<List<EstudianteDto>>("Estudiantes");
            Evaluaciones = await _apiService.GetAsync<List<EvaluacionDto>>("Evaluaciones");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Estudiantes = await _apiService.GetAsync<List<EstudianteDto>>("Estudiantes");
                Evaluaciones = await _apiService.GetAsync<List<EvaluacionDto>>("Evaluaciones");
                return Page();
            }

            await _apiService.PutAsync<CalificacionDto>($"Calificaciones/{Calificacion.Id}", Calificacion);
            return RedirectToPage("Index");
        }
    }
}


