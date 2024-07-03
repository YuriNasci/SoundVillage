using System;
using System.Text.RegularExpressions;

namespace SoundVillage.Domain.Streaming.ValueObject
{
    public record Duracao
    {
        public int Valor { get; private set; }

        public Duracao(int valor)
        {
            if (valor < 0)
                throw new ArgumentException("A duração da música não pode ser negativa");

            Valor = valor;
        }

        public Duracao(string formattedDuration)
        {
            if (string.IsNullOrWhiteSpace(formattedDuration))
                throw new ArgumentException("O valor não pode ser nulo ou vazio.", nameof(formattedDuration));

            var regex = new Regex(@"^\d{2}:\d{2}$");
            if (!regex.IsMatch(formattedDuration))
                throw new FormatException("A duração deve estar no formato mm:ss.");

            var parts = formattedDuration.Split(':');
            if (!int.TryParse(parts[0], out int minutos) || !int.TryParse(parts[1], out int segundos))
                throw new FormatException("A duração deve conter apenas números.");

            if (minutos < 0 || segundos < 0 || segundos >= 60)
                throw new ArgumentOutOfRangeException("Minutos e segundos devem ser positivos e segundos devem estar entre 0 e 59.");

            Valor = minutos * 60 + segundos;
        }

        public string Formatado()
        {
            int minutos = Valor / 60;
            int segundos = Valor % 60;

            return $"{minutos.ToString().PadLeft(2, '0')}:{segundos.ToString().PadLeft(2, '0')}";
        }

        public static implicit operator int(Duracao d) => d.Valor;
        public static implicit operator Duracao(int valor) => new Duracao(valor);
    }
}
