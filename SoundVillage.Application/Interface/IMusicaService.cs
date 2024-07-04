using SoundVillage.Application.Admin.Dto;
using SoundVillage.Domain.Streaming.Aggregates;

namespace SoundVillage.Application.Interface
{
    public interface IMusicaService
    {
        void Atualizar(MusicaDto musicaDto);
        void Excluir(Guid id);
        void FavoritarMusica(Guid IdMusica, Guid IdUsuario);
        MusicaDto Obter(Guid id);
        IEnumerable<Musica> ObterMaisCurtidas(int top = 10);
        IEnumerable<MusicaDto> ObterTodas();
        void Salvar(Musica musica);
    }
}