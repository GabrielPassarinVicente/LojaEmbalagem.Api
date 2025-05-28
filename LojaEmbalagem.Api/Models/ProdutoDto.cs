namespace LojaEmbalagem.Api.Models
{
    public class ProdutoDto
    {
        public string Sku { get; set; } = null!;
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }
    }
}