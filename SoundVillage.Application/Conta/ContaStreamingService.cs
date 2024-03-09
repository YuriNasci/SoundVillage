using AutoMapper;
using SoundVillage.Application.Conta.Request;
using SoundVillage.Domain.Conta;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Domain.Transacao.Aggregates;
using SoundVillage.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Conta
{
    public class ContaStreamingService
    {
        private IMapper Mapper { get; set; }
        private ContaStreamingRepository ContaStreamingRepository { get; set; }
        private PlanoRepository PlanoRepository { get; set; }

        public ContaStreamingService(IMapper mapper, ContaStreamingRepository contaStreamingRepository, PlanoRepository planoRepository)
        {
            Mapper = mapper;
            ContaStreamingRepository = contaStreamingRepository;
            PlanoRepository = planoRepository;
        }

        public ContaStreamingDto Criar(ContaStreamingDto dto)
        {
            if (this.ContaStreamingRepository.Exists(x => x.Email == dto.Email))
                throw new Exception("Usuario já existente na base");


            Plano plano = this.PlanoRepository.GetById(dto.PlanoId);

            if (plano == null)
                throw new Exception("Plano não existente ou não encontrado");

            Cartao cartao = this.Mapper.Map<Cartao>(dto.Cartao);

            ContaStreaming conta = new ContaStreaming();
            conta.CriarConta(dto.Nome, dto.Email, dto.Senha, dto.DataNascimento, plano, cartao);

            //TODO: GRAVAR MA BASE DE DADOS
            this.ContaStreamingRepository.Save(conta);
            var result = this.Mapper.Map<ContaStreamingDto>(conta);

            return result;
        } 
    }
}
