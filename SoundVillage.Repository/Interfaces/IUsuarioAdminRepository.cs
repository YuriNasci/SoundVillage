using SoundVillage.Domain.Admin.Aggregates;
using SoundVillage.Domain.Conta.Agreggates;

namespace SoundVillage.Repository.Interfaces
{
    public interface IUsuarioAdminRepository
    {
        IEnumerable<UsuarioAdmin> GetAll();
        UsuarioAdmin GetUsuarioAdminByEmailAndPassword(string email, string password);
        void Save(UsuarioAdmin usuario);
    }
}