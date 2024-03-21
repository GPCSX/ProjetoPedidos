using ProjetoPedidos.Models;

namespace ProjetoPedidos.Services
{
    public interface IPedidoService
    {
        Pedido CriarPedido(string nomeFornecedor, decimal descontoGeral, List<ItemPedido> itens);
    }
}
