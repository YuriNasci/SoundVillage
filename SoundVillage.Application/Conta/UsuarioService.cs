using AutoMapper;
using SoundVillage.Application.Conta.Dto;
using SoundVillage.Domain.Conta.Agreggates;
using SoundVillage.Domain.Core.Extension;
using SoundVillage.Domain.Streaming.Aggregates;
using SoundVillage.Domain.Transacao.Agreggates;
using SoundVillage.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundVillage.Domain.Streaming.Agreggates;
using SoundVillage.Repository.Interfaces;

namespace SoundVillage.Application.Conta
{
    public class UsuarioService
    {
        private IMapper Mapper { get; set; }
        private IUsuarioRepository UsuarioRepository { get; set; }
        private PlanoRepository PlanoRepository { get; set; }
        private CartaoRepository CartaoRepository { get; set; }
        private AzureServiceBusService AzureServiceBusService { get; set; }

        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository, PlanoRepository planoRepository,
            CartaoRepository cartaoRepository, AzureServiceBusService azureServiceBusService)
        {
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
            PlanoRepository = planoRepository;
            CartaoRepository = cartaoRepository;
            AzureServiceBusService = azureServiceBusService;
        }

        public UsuarioDto Obter(Guid id)
        {
            var usuario = this.UsuarioRepository.GetById(id);
            var result = this.Mapper.Map<UsuarioDto>(usuario);
            return result;
        }

        public UsuarioDto Autenticar(String email, String senha)
        {
            var usuario = this.UsuarioRepository.Find(x => x.Email == email && x.Senha == senha.HashSHA256()).FirstOrDefault();
            var result = this.Mapper.Map<UsuarioDto>(usuario);

            //Notificar o usuário
            Notificacao notificacao = new Notificacao()
            {
                Mensagem = $"Alerta: {usuario.Nome} acabou de fazer login as {DateTime.Now}",
                Nome = usuario.Nome,
                IdUsuario = usuario.Id
            };

            this.AzureServiceBusService.SendMessage(notificacao).Wait();

            return result;
        }

        public object Criar(UsuarioFormDto dto)
        {
            if (this.UsuarioRepository.Exists(x => x.Email == dto.Email))
                throw new Exception("Usuario já existente na base");


            Plano plano = this.PlanoRepository.GetById(Guid.Parse(dto.PlanoId));

            if (plano == null)
                throw new Exception("Plano não existente ou não encontrado");

            Cartao? cartao = CartaoRepository.GetByNumero(dto.NumeroCartao);
            if (cartao != null)
                throw new Exception("Cartão já existente e está em uso.");
            else
            {
                cartao = new Cartao()
                {
                    Numero = dto.NumeroCartao,
                    Ativo = true,
                    Limite = 1000
                };
            }

            Usuario usuario = new Usuario();
            usuario.CriarConta(dto.Nome, dto.Email, dto.Senha, dto.DataNascimento, plano, cartao);

            //TODO: GRAVAR MA BASE DE DADOS
            this.UsuarioRepository.Save(usuario);
            var result = this.Mapper.Map<UsuarioDto>(usuario);

            //Notificar o usuário
            Notificacao notificacao = new Notificacao()
            {
                Mensagem = $"Seja bem vindo ao Sound Village {usuario.Nome}",
                Nome = usuario.Nome,
                IdUsuario = usuario.Id
            };

            this.AzureServiceBusService.SendMessage(notificacao).Wait();

            return result;
        }
    }
}
