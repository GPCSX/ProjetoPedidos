using ProjetoPedidos.Models;

namespace ProjetoPedidos.Services
{
    public class PedidoService : IPedidoService
    {
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

            var pedido = new Pedido
            {
                NumeroPedido = GerarNumeroPedido(),
                NomeFornecedor = nomeFornecedor,
                DescontoGeral = descontoGeral,
                Itens = itens
            };


            return pedido;
        }

        private int GerarNumeroPedido()
        {
            return 1001;
        }
    }
}
