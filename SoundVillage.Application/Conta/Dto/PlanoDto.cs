using SoundVillage.Domain.Core.ValueObjects;
using SoundVillage.Domain.Streaming.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Application.Conta.Dto
{
    public class PlanoDto
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public decimal Valor { get; set; }

        public virtual RecorrenciaPlano Recorrencia { get; set; }
    }
}
