namespace ProjetoPedidos.Models
{
    public class ItemPedido
    {
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
        public string? Descricao { get; set; }

        public decimal CalcularValorTotal()
        {
            return (Quantidade * ValorUnitario) - Desconto;
        }
    }
}
