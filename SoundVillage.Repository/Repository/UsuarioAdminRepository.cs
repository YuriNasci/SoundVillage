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
        public UsuarioAdminRepository(SoundVillageAdminContext context) : base(context)
        {
        }

        public UsuarioAdmin GetUsuarioAdminByEmailAndPassword(string email, string password)
        {
            return this.Find(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
    }
}
