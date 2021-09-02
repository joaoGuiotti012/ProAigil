
using System.Linq;
using AutoMapper;
using ProAgil.Domain;
using ProAgil.Domain.Identity;
using ProAgil.WebAPI.Dtos;

namespace ProAgil.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(dest => dest.palestrantes, opt =>
                {
                    opt.MapFrom(src => src.palestranteEventos.Select(x => x.palestrante).ToList());
                }).ReverseMap();

            CreateMap<Palestrante, PalestranteDto>()
                .ForMember(dest => dest.eventos, opt =>
                {
                    opt.MapFrom(src => src.palestranteEventos.Select(x => x.evento).ToList());
                }).ReverseMap();

            CreateMap<Lote, LoteDto>().ReverseMap();

            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<User, UserLoginDto>().ReverseMap();

        }
    }
}