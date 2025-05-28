namespace LojaEmbalagem.Api.Models
{
    public class CaixaUsoDto
    {
        public string NomeCaixa { get; set; } = null!;
        public List<string> Skus { get; set; } = new();
    }
}