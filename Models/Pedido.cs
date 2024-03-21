namespace ProjetoPedidos.Models
{
    public class Pedido
    {
        public int? NumeroPedido { get; set; }
        public string? NomeFornecedor { get; set; }
        public decimal? DescontoGeral { get; set; }
        public List<ItemPedido> Itens { get; set; }

        public decimal CalcularValorTotal()
        {
            return Itens.Sum(item => item.CalcularValorTotal());
        }
    }
}
