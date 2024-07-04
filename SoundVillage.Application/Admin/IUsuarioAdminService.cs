using SoundVillage.Application.Admin.Dto;
using SoundVillage.Domain.Admin.Aggregates;

namespace SoundVillage.Application.Admin
{
    public interface IUsuarioAdminService
    {
        UsuarioAdmin Authenticate(string email, string password);
        IEnumerable<UsuarioAdminDto> ObterTodos();
        void Salvar(UsuarioAdminDto dto);
    }
}