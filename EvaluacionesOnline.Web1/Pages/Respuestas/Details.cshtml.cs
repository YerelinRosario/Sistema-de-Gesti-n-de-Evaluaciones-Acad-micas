using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Respuestas
{
    public class DetailsModel : PageModel
    {
        private readonly ApiService _apiService;

        public RespuestaDto Respuesta { get; set; }

        public DetailsModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Respuesta = await _apiService.GetAsync<RespuestaDto>($"Respuestas/{id}");
            if (Respuesta == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
