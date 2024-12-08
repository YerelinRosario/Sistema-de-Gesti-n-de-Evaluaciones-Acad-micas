using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Respuestas
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public List<RespuestaDto> Respuestas { get; set; }

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            Respuestas = await _apiService.GetAsync<List<RespuestaDto>>("Respuestas");
        }
    }
}
