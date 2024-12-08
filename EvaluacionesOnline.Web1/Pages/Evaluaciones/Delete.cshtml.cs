using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Evaluaciones
{
    public class DeleteModel : PageModel
    {
        private readonly ApiService _apiService;

        public EvaluacionDto Evaluacion { get; set; }

        public DeleteModel(ApiService apiService)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _apiService.DeleteAsync($"Evaluaciones/{id}");
            return RedirectToPage("Index");
        }
    }
}
