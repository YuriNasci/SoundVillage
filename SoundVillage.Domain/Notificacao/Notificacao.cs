using SoundVillage.Domain.Core.Abstracts;
using SoundVillage.Domain.Transacao.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Notificacao
{
    public class Notificacao: BaseEntity
    {
        public virtual ContaBancaria ContaBancaria {  get; set; }
        public bool Visualizada { get; set; }
        public DateTime DataNotificacao { get; set; }
        public String Mensagem { get; set; }
        public String Titulo { get; set; }

        public static Notificacao Criar(string titulo, string mensagem, ContaBancaria conta)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentNullException("Informe o titulo da notificacao");

            if (string.IsNullOrWhiteSpace(mensagem))
                throw new ArgumentNullException("Informe o mensagem da notificacao");

            return new Notificacao()
            {
                DataNotificacao = DateTime.Now,
                Mensagem = mensagem,
                Titulo = titulo,
                ContaBancaria = conta
            };
        }
    }
}
