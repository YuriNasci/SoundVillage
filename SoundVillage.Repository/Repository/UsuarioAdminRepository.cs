using SoundVillage.Domain.Admin.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Repository
{
    public class UsuarioAdminRepository : RepositoryBase<UsuarioAdmin>
    {
        public UsuarioAdminRepository(SoundVillageContext context) : base(context)
        {
        }
    }
}
