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
                /*List<ItemPedido> itensComValorLiquido = new List<ItemPedido>();
                foreach (var item in request.Itens)
                {
                    decimal valorLiquido = item.ValorUnitario * item.Quantidade - item.Desconto;
                    itensComValorLiquido.Add(new ItemPedido
                    {
                        Quantidade = item.Quantidade,
                        ValorUnitario = item.ValorUnitario,
                        Desconto = item.Desconto,
                        Descricao = item.Descricao
                    });
                }*/

                // Calcular o valor total do pedido
                decimal valorTotalPedido = 0;
                foreach (var item in request.Itens)
                {
                    valorTotalPedido += item.Quantidade * item.ValorUnitario;
                }

                // Chamar o serviço de aplicação para criar um novo pedido
                var pedido = _pedidoService.CriarPedido(request.NomeFornecedor, request.DescontoGeral, request.Itens);

                // Verificar se o pedido foi criado com sucesso e os dados inseridos
                if (pedido != null && pedido.Itens != null && pedido.Itens.Count > 0)
                {
                    // Calcular o valor líquido para cada item do pedido
                    foreach (var item in pedido.Itens)
                    {
                        item.ValorLiquido = item.Quantidade * item.ValorUnitario - item.Desconto;
                    }
                }

                // Adicionar o valor total ao pedido
                pedido.ValorTotal = valorTotalPedido;

                return Ok(pedido);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
