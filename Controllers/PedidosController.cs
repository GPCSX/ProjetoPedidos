using Microsoft.AspNetCore.Mvc;
using ProjetoPedidos.Models;
using ProjetoPedidos.Services;
using System;
using System.Data;

namespace ProjetoPedidos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly Random _random;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
            _random = Program.GetRandom();
        }

        [HttpPost]
        public ActionResult<Pedido> CriarPedido([FromBody] PedidoRequest request)
        {
            try
            {
                // Gerar um número aleatório para o pedido
                int numeroPedido = _random.Next(1000, 10000);

                // Calcular o valor líquido para cada item do pedido
                List<ItemPedido> itensComValorLiquido = new List<ItemPedido>();
                foreach (var item in request.Itens)
                {
                    decimal valorLiquido = item.ValorUnitario * item.Quantidade - item.Desconto;
                    item.ValorLiquido = valorLiquido;
                    itensComValorLiquido.Add(item);
                }

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
