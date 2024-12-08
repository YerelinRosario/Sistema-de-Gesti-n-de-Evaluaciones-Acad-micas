using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;

namespace EvaluacionesOnline.Web.Pages.Respuestas
{
    public class DeleteModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public int Id { get; set; }

        public DeleteModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Id = id;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _apiService.DeleteAsync($"Respuestas/{Id}");
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al eliminar la respuesta: {ex.Message}");
                return Page();
            }
        }
    }
}

