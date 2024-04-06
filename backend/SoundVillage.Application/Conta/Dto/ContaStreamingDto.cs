using System;
using System.ComponentModel.DataAnnotations;

namespace SoundVillage.Application.Conta.Request
{
    public class ContaStreamingDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string PlanoId { get; set; }
        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public DateTime ValidadeCartao { get; set; }
        public string CodigoSeguranca { get; set; }
    }
}
