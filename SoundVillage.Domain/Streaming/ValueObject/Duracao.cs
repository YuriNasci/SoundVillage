﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Domain.Streaming.ValueObject
{
    public record Duracao
    {
        public int Valor { get; set; }

        public Duracao(int valor)
        {
            if (valor < 0)
                throw new ArgumentException("Duração da musica não pode ser negativa");

            Valor = valor;
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
