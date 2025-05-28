using LojaEmbalagem.Api.Models;
using LojaEmbalagem.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaEmbalagem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PackagingController : ControllerBase
    {
        private readonly IPackagingService _service;
        public PackagingController(IPackagingService service) => _service = service;

        [HttpPost("embalar")]
        public ActionResult<List<EmbalagemDto>> Embalar([FromBody] List<PedidoDto> pedidos)
        {
            var result = _service.EmbalarPedidos(pedidos);
            return Ok(result);
        }
    }
}