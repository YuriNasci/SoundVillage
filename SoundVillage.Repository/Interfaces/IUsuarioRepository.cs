using SoundVillage.Domain.Conta.Agreggates;

namespace SoundVillage.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario GetById(Guid id);
    }
}