using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Domain.Entities
{
    public class Evaluacion
    {
        public int Id { get; set; }  // Llave primaria
        public string Titulo { get; set; }  // Título de la evaluación
        public string Descripcion { get; set; }  // Descripción de la evaluación
        public DateTime FechaCreacion { get; set; }  // Fecha de creación de la evaluación
        public int ProfesorId { get; set; }  // Llave foránea para el profesor que la creó

        // Relación con el profesor
        public Profesor Profesor { get; set; }

        // Relación con las preguntas/respuestas que los estudiantes enviaron
        public ICollection<Respuesta> Respuestas { get; set; }
    }
}
