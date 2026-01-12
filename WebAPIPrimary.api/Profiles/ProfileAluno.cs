using AutoMapper;
using WebAPIPrimary.api.Entites;
using WebAPIPrimary.api.Models;

namespace WebAPIPrimary.api.Profiles;

public class ProfileAluno : Profile

{
    public ProfileAluno()
    {
        CreateMap<Alunos, AlunoDTO>().ReverseMap();
        CreateMap<Cursos, CursoDTO>()
            .ForMember(
                dest => dest.AlunoId,
                opt => opt.MapFrom(src => src.Alunos.First().Id)
            );
    }
}

