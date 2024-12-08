using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Application.Dtos;
using EvaluacionesOnline.Web.Services;

namespace EvaluacionesOnline.Web.Pages.Evaluaciones
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public List<EvaluacionDto> Evaluaciones { get; set; }

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            Evaluaciones = await _apiService.GetAsync<List<EvaluacionDto>>("Evaluaciones");
        }
    }
}
