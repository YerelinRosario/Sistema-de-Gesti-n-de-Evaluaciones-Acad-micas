using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Web.Services;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Web.Pages.Profesores
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public List<ProfesorDto> Profesores { get; set; }

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            Profesores = await _apiService.GetAsync<List<ProfesorDto>>("Profesores");
        }
    }
}
