using System;

namespace EvaluacionesOnline.Application.Dtos
{
    public class EvaluacionDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ProfesorId { get; set; }
        public string ProfesorNombre { get; set; } // Este se obtiene a través de la relación
    }
}


