﻿using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Core.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Transacao.Aggregates
{
    public class Cartao: BaseEntity
    {
        private const int INTERVALO_TRANSACAO = -2;
        private const int REPETICAO_TRANSACAO_MERCHANT = 1;

        public bool Ativo {  get; set; }
        public Monetario LimiteDisponivel { get; set; }
        public string Numero { get; set; }
        public virtual List<Transacao> Transacoes { get; set; } = new List<Transacao>();
        public virtual ContaBancaria ContaBancaria { get; set; }

        public Cartao(decimal limiteAprovado, string numero, ContaBancaria conta)
        {
            LimiteDisponivel = limiteAprovado;
            Numero = numero;
            Ativo = false;
            ContaBancaria = conta;
        }

        public Cartao() {
        }

        public void AtivarCartao()
        {
            this.Ativo = true;
        }

        public void CriarTransacao(ContaBancaria contaDestino, Monetario valor, string Descricao = "")
        {
            //Verificar se o cartão está ativo
            this.IsCartaoAtivo();

            Transacao transacao = new Transacao();
            transacao.ContaOrigem = this.ContaBancaria;
            transacao.ContaDestino = contaDestino;
            transacao.Valor = valor;
            transacao.Descricao = Descricao;
            transacao.Horario = DateTime.Now;

            //Verifica limite disponivel
            this.VerificaLimite(transacao);

            //Verifica regras antifraude
            this.ValidarTransacao(transacao);

            //Cria numero de autorização
            transacao.Id = Guid.NewGuid();

            //Diminui o limite com o valor da transacao
            this.LimiteDisponivel = this.LimiteDisponivel - transacao.Valor;

            this.Transacoes.Add(transacao);

            //TO DO:
            //Notificar envolvidos
            //string tituloPagamento = "Pagamento Efetuado";
            //string mensagemPagamento = $"Pagamento de {valor} efetuado com sucesso.";
            //this.ContaBancaria.Notificacoes.Add(Notificacao.Notificacao.Criar(tituloPagamento, mensagemPagamento, this.ContaBancaria));

            //string tituloRecebimento = "Recebimento de Pagamento";
            //string mensagemRecebimento = $"Recebimento de {valor} efetuado com sucesso.";
            //contaDestino.Notificacoes.Add(Notificacao.Notificacao.Criar(tituloRecebimento, mensagemRecebimento, contaDestino));
        }

        private void IsCartaoAtivo()
        {
            if (this.Ativo == false)
                throw new Exception("Cartão não está ativo");
        }

        private void VerificaLimite(Transacao transacao)
        {
            if (this.LimiteDisponivel < transacao.Valor)
                throw new Exception("Cartão não possui limite para esta transacao");
        }

        private void ValidarTransacao(Transacao transacao)
        {
            var ultimasTransacoes = this.Transacoes.Where(x =>
                                                          x.Horario >= DateTime.Now.AddMinutes(INTERVALO_TRANSACAO));
            if (ultimasTransacoes?.Count() >= 3)
                throw new Exception("Cartão utilizado muitas vezes em um período curto");

            var transacaoRepetidaPorMerchant = ultimasTransacoes?
                                                .Where(x => x.ContaDestino.GetMerchant() == transacao.ContaDestino.GetMerchant()
                                                       && x.Valor.Valor == transacao.Valor.Valor)
                                                .Count() == REPETICAO_TRANSACAO_MERCHANT;

            if (transacaoRepetidaPorMerchant)
                throw new Exception("Transacao Duplicada para o mesmo cartão e o mesmo Comerciante");

        }

        public List<Transacao> GetTransacoes()
        {
            return this.Transacoes;
        }

        public Monetario GetLimiteDisponivel()
        {
            return this.LimiteDisponivel;
        }
    }
}
