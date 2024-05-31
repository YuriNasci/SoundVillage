namespace SoundVillage.Application.Conta.Request
{
    public class CartaoDto
    {
        public Guid Id {  get; set; }
        public bool Ativo { get; set; }
        public decimal LimiteDisponivel { get; set; }
        public string Numero { get; set; }
    }
}
