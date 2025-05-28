using LojaEmbalagem.Api.Data;
using LojaEmbalagem.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaEmbalagem.Api.Services
{
    public class PackagingService : IPackagingService
    {
        private readonly ApplicationDbContext _context;
        public PackagingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<EmbalagemDto> EmbalarPedidos(List<PedidoDto> pedidos)
        {
            var boxes = _context.Boxes.AsNoTracking().ToList();
            var resultado = new List<EmbalagemDto>();

            foreach (var pedido in pedidos)
            {
                var embalagem = new EmbalagemDto { PedidoId = pedido.Id };

                foreach (var produto in pedido.Produtos)
                {
                    bool placed = false;
                    foreach (var uso in embalagem.Caixas)
                    {
                        var boxInfo = boxes.First(b => b.Nome == uso.NomeCaixa);
                        if (produto.Altura <= boxInfo.Altura &&
                            produto.Largura <= boxInfo.Largura &&
                            produto.Comprimento <= boxInfo.Comprimento)
                        {
                            uso.Skus.Add(produto.Sku);
                            placed = true;
                            break;
                        }
                    }

                    if (!placed)
                    {
                        var box = boxes.FirstOrDefault(b =>
                            produto.Altura <= b.Altura &&
                            produto.Largura <= b.Largura &&
                            produto.Comprimento <= b.Comprimento);

                        if (box == null)
                        {
                            throw new Exception($"Produto {produto.Sku} não cabe em nenhuma caixa.");
                        }

                        embalagem.Caixas.Add(new CaixaUsoDto
                        {
                            NomeCaixa = box.Nome,
                            Skus = new List<string> { produto.Sku }
                        });
                    }
                }

                resultado.Add(embalagem);
            }

            return resultado;
        }
    }
}