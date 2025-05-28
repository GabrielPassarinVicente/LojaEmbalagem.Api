namespace LojaEmbalagem.Api.Models
{
    public class EmbalagemDto
    {
        public string PedidoId { get; set; } = null!;
        public List<CaixaUsoDto> Caixas { get; set; } = new();
    }
}