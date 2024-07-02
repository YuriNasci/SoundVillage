namespace SoundVillage.Admin.ViewsModels.Musica
{
    public class CriarViewModel
    {
        public String Nome { get; set; }
        public string Duracao { get; set; }
        public Guid ArtistaId { get; set; }
        public Guid? AlbumId { get; set; }
    }
}
