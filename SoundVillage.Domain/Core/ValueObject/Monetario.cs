using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Core.ValueObject
{
    public class Monetario
    {
        public decimal Valor { get; set; }

        public static implicit operator decimal(Monetario d) => d.Valor;
        public static implicit operator Monetario(decimal valor) => new Monetario(valor);

        public Monetario(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor monetário não pode ser negativo");

            Valor = valor;
        }

        public string Formatado()
        {
            return $"R$ {Valor.ToString("N2")}";
        }
    }
}
