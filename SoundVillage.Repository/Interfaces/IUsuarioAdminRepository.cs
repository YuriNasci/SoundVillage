using SoundVillage.Domain.Admin.Aggregates;

namespace SoundVillage.Repository.Interfaces
{
    public interface IUsuarioAdminRepository
    {
        object GetAll();
        UsuarioAdmin GetUsuarioAdminByEmailAndPassword(string email, string password);
        void Save(UsuarioAdmin usuario);
    }
}