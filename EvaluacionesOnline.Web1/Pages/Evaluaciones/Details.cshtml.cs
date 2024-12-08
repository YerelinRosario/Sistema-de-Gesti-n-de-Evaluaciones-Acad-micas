using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Evaluaciones
{
    public class DetailsModel : PageModel
    {
        private readonly ApiService _apiService;

        public EvaluacionDto Evaluacion { get; set; }

        public DetailsModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Evaluacion = await _apiService.GetAsync<EvaluacionDto>($"Evaluaciones/{id}");
            if (Evaluacion == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
