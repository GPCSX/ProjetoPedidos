using Microsoft.AspNetCore.Mvc;
using ProjetoPedidos.Models;
using ProjetoPedidos.Services;

namespace ProjetoPedidos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public ActionResult<Pedido> CriarPedido([FromBody] PedidoRequest request)
        {
            try
            {
                // Chamar o serviço de aplicação para criar um novo pedido
                var pedido = _pedidoService.CriarPedido(request.NomeFornecedor, request.DescontoGeral, request.Itens);
                return Ok(pedido);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
