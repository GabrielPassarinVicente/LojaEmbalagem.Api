namespace LojaEmbalagem.Api.Models
{
    public class Box
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }
    }
}