using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Evaluaciones
{
    public class EditModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public EvaluacionDto Evaluacion { get; set; }

        public EditModel(ApiService apiService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiService.PutAsync<EvaluacionDto>($"Evaluaciones/{Evaluacion.Id}", Evaluacion);
            return RedirectToPage("Index");
        }
    }
}
