using EvaluacionesOnline.Domain.Entities; 
using EvaluacionesOnline.API1.Models; // ViewModels
using AutoMapper;


namespace EvaluacionesOnline.API1.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Profesor, ProfesorViewModel>().ReverseMap();
            CreateMap<Estudiante, EstudianteViewModel>().ReverseMap();
            CreateMap<Evaluacion, EvaluacionViewModel>().ReverseMap();
            CreateMap<Respuesta, RespuestaViewModel>().ReverseMap();
            CreateMap<Calificacion, CalificacionViewModel>().ReverseMap();
        }
    }
}
