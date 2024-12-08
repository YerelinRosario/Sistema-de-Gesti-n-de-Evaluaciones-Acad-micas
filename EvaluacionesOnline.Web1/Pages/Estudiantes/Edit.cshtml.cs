using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EvaluacionesOnline.Application.Dtos;
using EvaluacionesOnline.Application.Contract;

namespace EvaluacionesOnline.Web.Pages.Estudiantes
{
    public class EditModel : PageModel
    {
        private readonly IEstudianteService _estudianteService;

        [BindProperty]
        public EstudianteDto Estudiante { get; set; }

        public EditModel(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var estudiante = await _estudianteService.GetByIdAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            Estudiante = estudiante;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _estudianteService.UpdateAsync(Estudiante.Id, Estudiante);
            return RedirectToPage("Index");
        }
    }
}

