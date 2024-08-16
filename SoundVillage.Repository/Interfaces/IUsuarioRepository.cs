using SoundVillage.Domain.Conta.Agreggates;

namespace SoundVillage.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        bool Exists(Func<Usuario, bool> value);
        List<Usuario> Find(Func<Usuario, bool> value);
        Usuario GetById(Guid id);
        void Save(Usuario usuario);
    }
}