using SoundVillage.STS.Model;

namespace SoundVillage.STS.Data
{
    public interface IIdentityRepository
    {
        Task<Usuario> FindByEmailAndPasswordAsync(string email, string password);
        Task<Usuario> FindByIdAsync(Guid id);
    }
}