using AutoMapper;
using PP.Usuario.API.Models;
using PP.Usuario.API.ViewModels;

namespace PP.Usuario.API.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile {
        public DomainToViewModelMappingProfile() {
            CreateMap<Models.Aluno, AlunoViewModel>();
            CreateMap<Professor, ProfessorViewModel>();
        }
    }
}