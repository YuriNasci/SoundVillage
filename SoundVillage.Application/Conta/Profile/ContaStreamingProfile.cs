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
            CreateMap<ContaStreaming, ContaStreamingDto>();

            CreateMap<CartaoDto, Cartao>()
                .ForMember(x => x.LimiteDisponivel.Valor, m => m.MapFrom(f => f.LimiteDisponivel));
            
            CreateMap<Cartao, CartaoDto>();
        }
    }
}
