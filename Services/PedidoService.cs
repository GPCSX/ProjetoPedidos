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

            // Criar o objeto Pedido com os dados fornecidos
            var pedido = new Pedido
            {
                NumeroPedido = GerarNumeroPedido(),
                NomeFornecedor = nomeFornecedor,
                DescontoGeral = descontoGeral,
                Itens = itens
            };

            // Realizar qualquer lógica adicional necessária (ex: cálculo de valores, validações adicionais, etc.)
            // Por exemplo, poderíamos calcular o valor total do pedido aqui se necessário:
            // pedido.ValorTotal = pedido.CalcularValorTotal();

            return pedido;
        }

        private int GerarNumeroPedido()
        {
            // Aqui poderíamos implementar a lógica para gerar um número de pedido único,
            // como gerar um número aleatório ou buscar o próximo número disponível no banco de dados.
            // Por simplicidade, retornaremos um número fixo neste exemplo.
            return 1001;
        }
    }
}
