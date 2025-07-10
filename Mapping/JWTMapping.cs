using AutoMapper;
using Cimo.Dtos;
using Cimo.Models;

namespace Cimo.Mapping
{
    public class JWTMapping : Profile
    {
        public JWTMapping()
        {
            CreateMap<User, JwtPayloadDto>()
            .ForMember(dest => dest.Sub, opt => opt.MapFrom(src => new Guid(src.Id).ToString()))
            .ForMember(dest => dest.Authorities, opt => opt.MapFrom(src =>
                src.UserRoles.Select(r => $"ROLE_{r.Role.Name.ToUpper()}").ToList()
            ));
        }

    }
}
