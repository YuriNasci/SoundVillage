using System;

namespace SoundVillage.Application.Conta.Request
{
    public class ContaStreamingDto
    {
        public Guid Id {  get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid PlanoId { get; set; }
        public CartaoDto Cartao { get; set; }
    }
}
