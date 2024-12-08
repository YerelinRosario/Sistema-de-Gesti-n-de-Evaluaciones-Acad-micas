using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Calificaciones
{
    public class CreateModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public CalificacionDto Calificacion { get; set; }

        public CreateModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<EstudianteDto> Estudiantes { get; set; }
        public List<EvaluacionDto> Evaluaciones { get; set; }

        public async Task OnGetAsync()
        {
            Estudiantes = await _apiService.GetAsync<List<EstudianteDto>>("Estudiantes");
            Evaluaciones = await _apiService.GetAsync<List<EvaluacionDto>>("Evaluaciones");
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiService.PostAsync<CalificacionDto>("Calificaciones", Calificacion);
            return RedirectToPage("Index");
        }
    }
}
