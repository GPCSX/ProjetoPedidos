namespace ProjetoPedidos.Models
{
    public class ItemPedido
    {
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
        public string? Descricao { get; set; }
        public decimal ValorLiquido { get; internal set; }

        public decimal CalcularValorTotal()
        {
            return (Quantidade * ValorUnitario) - Desconto;
        }

        public ItemPedido() { }

        public ItemPedido(decimal quantidade, decimal valorUnitario, decimal desconto, string? descricao)
        {
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Desconto = desconto;
            Descricao = descricao;
        }
    }
}
