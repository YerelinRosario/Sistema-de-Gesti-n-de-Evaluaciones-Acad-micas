using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Application.Dtos;
using EvaluacionesOnline.Application.Contract;

namespace EvaluacionesOnline.Web.Pages.Estudiantes
{
    public class DetailsModel : PageModel
    {
        private readonly IEstudianteService _estudianteService;

        public EstudianteDto Estudiante { get; set; }

        public DetailsModel(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Estudiante = await _estudianteService.GetByIdAsync(id);
            if (Estudiante == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
