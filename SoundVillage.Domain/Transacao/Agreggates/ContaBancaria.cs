﻿using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Core.ValueObjects;
using SoundVillage.Domain.Transacao.Agreggates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Transacao.Aggregates
{
    public class ContaBancaria: BaseEntity
    {
        private string Nome { get; set; }
        private string NumeroAgencia { get; set; }
        private string NumeroConta { get; set; }
        private string Digito { get; set; }
        public Monetario Saldo { get; set; }
        private string Cpf { get; set; }
        public virtual List<Notificacao.Notificacao> Notificacoes { get; set; } = new List<Domain.Notificacao.Notificacao>();

        public ContaBancaria(string Nome, string Cpf)
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.Saldo = 0;

            Random random = new Random();

            // Gerar número de conta bancária (assumindo 8 dígitos)
            this.NumeroConta = random.Next(10000000, 100000000).ToString();

            // Gerar número de agência bancária (assumindo 4 dígitos)
            this.NumeroAgencia = random.Next(1000, 10000).ToString();

            // Gerar dígito verificador (assumindo 1 dígito)
            this.Digito = random.Next(0, 10).ToString();
        }

        public Cartao? SolicitarCartaoCredito()
        {
            return null;
        }

        private string GerarNumeroCartaoCredito()
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();

            // Gerar um número de cartão de crédito de 16 dígitos
            for (int i = 0; i < 16; i++)
            {
                sb.Append(random.Next(0, 10)); // Gera um dígito único
            }

            return sb.ToString();
        }

        public string GetMerchant()
        {
            return NumeroConta + NumeroAgencia + Digito;
        }
    }
}
