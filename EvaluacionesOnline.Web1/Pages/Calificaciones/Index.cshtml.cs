using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Calificaciones
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public List<CalificacionDto> Calificaciones { get; set; } = new();

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            Calificaciones = await _apiService.GetAsync<List<CalificacionDto>>("Calificaciones");
        }
    }
}

