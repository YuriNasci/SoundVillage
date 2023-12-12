using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Conta.Agreggates
{
    public class Assinatura
    {
        public List<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
    }
}
