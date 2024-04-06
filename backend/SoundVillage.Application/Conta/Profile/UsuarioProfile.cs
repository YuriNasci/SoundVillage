using SoundVillage.Application.Conta.Dto;
using SoundVillage.Domain.Conta.Agreggates;
using SoundVillage.Domain.Transacao.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundVillage.Application.Conta.Request;

namespace SoundVillage.Application.Conta.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<UsuarioDto, Usuario>();

            CreateMap<Usuario, UsuarioDto>()
            .AfterMap((s, d) =>
             {
                 var plano = s.Assinaturas?.FirstOrDefault(a => a.IsAtual)?.Plano;

                 if (plano != null)
                     d.PlanoId = plano.Id;

                 d.Senha = "xxxxxxxxx";
                 
             });

            CreateMap<CartaoDto, Cartao>()
                .ForPath(x => x.Limite.Valor, m => m.MapFrom(f => f.LimiteDisponivel))
                .ReverseMap();
        }
    }
}
