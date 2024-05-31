using SoundVillage.Application.Admin.Dto;
using SoundVillage.Application.Conta.Dto;
using SoundVillage.Domain.Admin.Aggregates;
using SoundVillage.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Admin.Profile
{
    public class UsuarioAdminProfile: AutoMapper.Profile
    {
        public UsuarioAdminProfile() {
            CreateMap<UsuarioAdminDto, UsuarioAdmin>()
                .ForMember(x => x.Perfil, m => m.MapFrom(f => (Perfil)f.Perfil))
                .ReverseMap();
        }
    }
}
