﻿using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SoundVillage.Application.Conta.Request;
using SoundVillage.Domain.Conta;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Domain.Transacao.Aggregates;
using SoundVillage.Repository.Repository;
using SoundVillage.Domain.Core.Extension;

namespace SoundVillage.Application.Conta
{
    public class ContaStreamingService
    {
        private IMapper Mapper { get; set; }
        private ContaStreamingRepository ContaStreamingRepository { get; set; }
        private PlanoRepository PlanoRepository { get; set; }
        private CartaoRepository CartaoRepository { get; set; }
      
        public ContaStreamingService(IMapper mapper, ContaStreamingRepository contaStreamingRepository, 
            PlanoRepository planoRepository, CartaoRepository cartaoRepository)
        {
            Mapper = mapper;
            ContaStreamingRepository = contaStreamingRepository;
            PlanoRepository = planoRepository;
            CartaoRepository = cartaoRepository;
        }

        public ContaStreamingDto Criar(ContaStreamingDto dto)
        {
            return null;
            //if (this.ContaStreamingRepository.Exists(x => x.Email == dto.Email))
            //    throw new Exception("Usuario já existente na base");


            //Plano plano = this.PlanoRepository.GetById(Guid.Parse(dto.PlanoId));

            //if (plano == null)
            //    throw new Exception("Plano não existente ou não encontrado");

            //try
            //{
            //    Cartao? cartao = this.CartaoRepository.GetByNumero(dto.NumeroCartao);

            //    if (cartao == null)
            //        throw new Exception("Cartão não existente ou não encontrado");

            //    ContaStreaming conta = new ContaStreaming();
            //    conta.CriarConta(dto.Nome, dto.Email, dto.Senha, dto.DataNascimento, plano, cartao);

            //    this.ContaStreamingRepository.Save(conta);
            //    var result = this.Mapper.Map<ContaStreamingDto>(conta);

            //    return result;
            //} catch (SqlException ex) {
            //    throw ex;
            //} catch (DbUpdateConcurrencyException ex)
            //{
            //    throw ex;
            //}
        }

        public ContaStreamingDto Obter(Guid id)
        {
            var contaStreaming = this.ContaStreamingRepository.GetById(id);
            var result = this.Mapper.Map<ContaStreamingDto>(contaStreaming);
            return result;
        }

        public ContaStreamingDto Autenticar(String email, String senha)
        {
            var usuario = this.ContaStreamingRepository.Find(x => x.Email == email && x.Senha == senha.HashSHA256()).FirstOrDefault();
            var result = this.Mapper.Map<ContaStreamingDto>(usuario);
            return result;
        }
    }
}
