using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Profesores
{
    public class EditModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public ProfesorDto Profesor { get; set; }

        public EditModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Profesor = await _apiService.GetAsync<ProfesorDto>($"Profesores/{id}");
                if (Profesor == null)
                {
                    return NotFound();
                }
                return Page();
            }
            catch (HttpRequestException ex)
            {
                // Log the error and return an error page or message
                ModelState.AddModelError(string.Empty, "Error al obtener los datos del profesor.");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _apiService.PutAsync<ProfesorDto>($"Profesores/{Profesor.Id}", Profesor);
                return RedirectToPage("Index");
            }
            catch (HttpRequestException ex)
            {
                // Log the error and return an error page or message
                ModelState.AddModelError(string.Empty, "Error al actualizar los datos del profesor.");
                return Page();
            }
        }
    }
}