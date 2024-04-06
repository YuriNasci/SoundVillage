using System;
using System.ComponentModel.DataAnnotations;

namespace SoundVillage.Application.Conta.Request
{
    public class ContaStreamingDto
    {
        public Guid Id {  get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        public Guid PlanoId { get; set; }
        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public DateTime ValidadeCartao { get; set; }
        public string CodigoSeguranca { get; set; }
    }
}
