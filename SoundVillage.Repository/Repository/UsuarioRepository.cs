using Microsoft.EntityFrameworkCore;
using SoundVillage.Domain.Conta.Agreggates;
using SoundVillage.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public SoundVillageContext Context { get; set; }

        public UsuarioRepository(SoundVillageContext context) : base(context)
        {
            Context = context;
        }

        public List<Usuario> Find(Func<Usuario, bool> value)
        {
            return null;
        }

        public bool Exists(Func<Usuario, bool> value) { return false; }
    }
}
