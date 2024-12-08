using EvaluacionesOnline.Web.Services; // Asegúrate de tener este servicio registrado
using EvaluacionesOnline.Application.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionesOnline.Web.Pages.Estudiantes
{


    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public List<EstudianteDto> Estudiantes { get; set; } = new List<EstudianteDto>();

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }


        public async Task OnGetAsync()
        {
            var estudiantes = await _apiService.GetAsync<List<EstudianteDto>>("Estudiantes");
            if (estudiantes != null)
            {
                Estudiantes = estudiantes;
            }
        }
    }
}



