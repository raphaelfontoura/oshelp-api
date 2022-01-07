using AutoMapper;
using webapi.Data.Dtos;
using webapi.Models;

namespace webapi.Profiles
{
    public class ChamadoProfile : Profile
    {
        public ChamadoProfile()
        {
            CreateMap<CreateChamadoDto, Chamado>();
            CreateMap<UpdateChamadoDto, Chamado>();
        }
    }
}