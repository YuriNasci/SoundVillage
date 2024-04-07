using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Conta.Dto
{
    public class UsuarioFormDto
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
