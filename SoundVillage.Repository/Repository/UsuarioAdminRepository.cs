using SoundVillage.Domain.Admin.Aggregates;
using SoundVillage.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundVillage.Repository.Repository
{
    public class UsuarioAdminRepository : RepositoryBase<UsuarioAdmin>, IUsuarioAdminRepository
    {
        public UsuarioAdminRepository(SoundVillageAdminContext context) : base(context)
        {
        }

        public virtual UsuarioAdmin GetUsuarioAdminByEmailAndPassword(string email, string password)
        {
            return this.Find(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        object IUsuarioAdminRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
