using EvaluacionesOnline.Application.Contract;
using EvaluacionesOnline.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EvaluacionesOnline.Web.Pages.Estudiantes
{
    public class CreateModel : PageModel
    {
        private readonly IEstudianteService _estudianteService;

        [BindProperty]
        public EstudianteDto Estudiante { get; set; } = new();

        public CreateModel(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService ?? throw new ArgumentNullException(nameof(estudianteService));
        }

        public IActionResult OnGet()
        {
            // Carga inicial, aqu� puedes agregar l�gica si necesitas precargar datos
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _estudianteService.CreateAsync(Estudiante);
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurri� un error al crear el estudiante: {ex.Message}");
                return Page();
            }
        }
    }
}


