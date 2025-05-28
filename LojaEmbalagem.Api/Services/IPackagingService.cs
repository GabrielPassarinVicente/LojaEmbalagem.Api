using LojaEmbalagem.Api.Models;

namespace LojaEmbalagem.Api.Services
{
    public interface IPackagingService
    {
        List<EmbalagemDto> EmbalarPedidos(List<PedidoDto> pedidos);
    }
}