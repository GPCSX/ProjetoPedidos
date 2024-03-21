namespace ProjetoPedidos.Models
{
    public class PedidoRequest
    {
        public string NomeFornecedor { get; set; }
        public decimal DescontoGeral { get; set; }
        public List<ItemPedido> Itens { get; set; }
    }
}
