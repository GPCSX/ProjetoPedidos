using ProjetoPedidos.Models;
using System;

namespace ProjetoPedidos.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly Random _random;

        public PedidoService()
        {
            _random = new Random();
        }
        public Pedido CriarPedido(string nomeFornecedor, decimal descontoGeral, List<ItemPedido> itens)
        {
            // Validar dados do pedido
            if (string.IsNullOrWhiteSpace(nomeFornecedor))
            {
                throw new ArgumentException("Nome do fornecedor não pode estar em branco.");
            }

            if (itens == null || itens.Count == 0)
            {
                throw new ArgumentException("O pedido deve conter pelo menos um item.");
            }

            // Converter o nome do fornecedor para caixa alta
            string nomeFornecedorUpper = nomeFornecedor.ToUpper();

            // Calcular o valor líquido para cada item do pedido
            decimal valorTotalPedido = 0;
            foreach (var item in itens)
            {
                item.ValorLiquido = item.Quantidade * item.ValorUnitario - item.Desconto;
                valorTotalPedido += item.Quantidade * item.ValorUnitario;
            }

            var pedido = new Pedido
            {
                NumeroPedido = GerarNumeroPedido(),
                NomeFornecedor = nomeFornecedorUpper,
                DescontoGeral = descontoGeral,
                Itens = itens
            };

            pedido.ValorTotal = valorTotalPedido;

            return pedido;
        }

        private int GerarNumeroPedido()
        {
            return _random.Next(1000, 10000);
        }
    }
}
