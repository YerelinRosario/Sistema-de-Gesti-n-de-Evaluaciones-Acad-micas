using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Profesores
{
    public class DeleteModel : PageModel
    {
        private readonly ApiService _apiService;

        public ProfesorDto Profesor { get; set; }

        public DeleteModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Profesor = await _apiService.GetAsync<ProfesorDto>($"Profesores/{id}");
            if (Profesor == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _apiService.DeleteAsync($"Profesores/{id}");
            return RedirectToPage("Index");
        }
    }
}

