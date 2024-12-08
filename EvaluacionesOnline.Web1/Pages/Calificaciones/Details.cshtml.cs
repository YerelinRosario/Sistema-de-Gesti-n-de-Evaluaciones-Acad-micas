using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Calificaciones
{
    public class DetailsModel : PageModel
    {
        private readonly ApiService _apiService;

        public CalificacionDto Calificacion { get; set; }

        public DetailsModel(ApiService apiService)
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

            return Page();
        }
    }
}

