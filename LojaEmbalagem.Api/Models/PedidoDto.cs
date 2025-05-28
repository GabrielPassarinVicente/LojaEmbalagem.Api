namespace LojaEmbalagem.Api.Models
{
    public class PedidoDto
    {
        public string Id { get; set; } = null!;
        public List<ProdutoDto> Produtos { get; set; } = new();
    }
}