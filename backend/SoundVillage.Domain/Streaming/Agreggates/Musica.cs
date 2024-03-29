﻿using SoundVillage.Domain.Conta;
using SoundVillage.Domain.Streaming.ValueObject;

namespace SoundVillage.Domain.Streaming.Aggregates
{
    public class Musica
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public Duracao Duracao { get; set; }

        public virtual IList<Playlist> Playlists { get; set; } = new List<Playlist>();

    }
}
