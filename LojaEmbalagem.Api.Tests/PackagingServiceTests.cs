using LojaEmbalagem.Api.Data;
using LojaEmbalagem.Api.Models;
using LojaEmbalagem.Api.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class PackagingServiceTests
{
    private ApplicationDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        var context = new ApplicationDbContext(options);
        context.Boxes.AddRange(
            new Box { Nome = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80 },
            new Box { Nome = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40 },
            new Box { Nome = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60 }
        );
        context.SaveChanges();
        return context;
    }

    [Fact]
    public void EmbalarPedidos_CabeNosBoxes()
    {
        var context = GetDbContext();
        var service = new PackagingService(context);
        var pedidos = new List<PedidoDto>
        {
            new PedidoDto
            {
                Id = "p1",
                Produtos = new List<ProdutoDto>
                {
                    new ProdutoDto { Sku = "p1a", Altura = 10, Largura = 10, Comprimento = 10 },
                    new ProdutoDto { Sku = "p1b", Altura = 70, Largura = 40, Comprimento = 30 }
                }
            }
        };

        var result = service.EmbalarPedidos(pedidos);

        Assert.Single(result);
        var embal = result[0];
        Assert.Equal("p1", embal.PedidoId);
        Assert.Contains(embal.Caixas, c => c.NomeCaixa == "Caixa 1" && c.Skus.Contains("p1a"));
        Assert.Contains(embal.Caixas, c => c.NomeCaixa == "Caixa 2" && c.Skus.Contains("p1b"));
    }
}