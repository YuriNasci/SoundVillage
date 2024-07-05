using SoundVillage.Application.Admin.Dto;
using SoundVillage.Domain.Admin.Aggregates;
using SoundVillage.Domain.Conta.Agreggates;

namespace SoundVillage.Application.Admin
{
    public interface IUsuarioAdminService
    {
        void Atualizar(UsuarioAdmin usuario);
        UsuarioAdmin Authenticate(string email, string password);
        void Excluir(Guid id);
        UsuarioAdmin Obter(Guid id);
        IEnumerable<UsuarioAdminDto> ObterTodos();
        void Salvar(UsuarioAdminDto dto);
    }
}