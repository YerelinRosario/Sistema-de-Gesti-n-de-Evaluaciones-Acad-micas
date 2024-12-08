using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Profesores
{
    public class CreateModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public ProfesorDto Profesor { get; set; }

        public CreateModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiService.PostAsync<ProfesorDto>("Profesores", Profesor);
            return RedirectToPage("Index");
        }
    }
}