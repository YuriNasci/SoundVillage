using SoundVillage.Application.Conta.Request;
using SoundVillage.Domain.Conta;
using SoundVillage.Domain.Transacao.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Conta.Profile
{
    public class ContaStreamingProfile: AutoMapper.Profile
    {
        public ContaStreamingProfile() {
            CreateMap<ContaStreamingDto, ContaStreaming>();

            CreateMap<ContaStreaming, ContaStreamingDto>()
            .AfterMap((s, d) =>
            {
                var plano = s.Assinaturas?.FirstOrDefault(a => a.IsAtual)?.Plano;

                if (plano != null)
                    d.PlanoId = plano.Id;

                d.Senha = "xxxxxxxxx";

            });

            CreateMap<CartaoDto, Cartao>()
                .ForPath(x => x.LimiteDisponivel.Valor, m => m.MapFrom(f => f.LimiteDisponivel))
                .ReverseMap();
        }
    }
}
