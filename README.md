# Projeto de Pedidos

Este é um projeto de exemplo para demonstrar a criação de pedidos com itens e valor total.

## Descrição

O objetivo deste projeto é fornecer uma API para criação de pedidos de compra. Cada pedido pode ter vários itens, onde cada item possui uma quantidade, um valor unitário, um possível desconto e uma descrição. O valor total do pedido é calculado com base nos itens e pode ser aplicado um desconto geral.

## Funcionalidades

- Criar um novo pedido com itens
- Calcular o valor total do pedido com base nos itens
- Aplicar um desconto geral ao pedido
- Retornar o pedido criado com o número de pedido gerado aleatoriamente e o valor total calculado

## Tecnologias Utilizadas

- C#
- ASP.NET Core
- Swagger (para documentação da API)
- DDD (Domain-Driven Design)
- SOLID Principles

## Como Executar o Projeto

1. Certifique-se de ter o SDK do .NET Core instalado em sua máquina.
2. Clone este repositório em sua máquina local.
3. Abra o projeto em seu editor de código preferido.
4. Abra um terminal na pasta raiz do projeto e execute o comando `dotnet run`.
5. Acesse a documentação da API em `https://localhost:{porta}/swagger`, onde `{porta}` é a porta em que o servidor está sendo executado.

## Exemplo de Uso

### Criar um Novo Pedido

Para criar um novo pedido, envie uma solicitação POST para `/api/pedidos` com os detalhes do pedido no corpo da solicitação no formato JSON.

Exemplo de corpo da solicitação:

```json
{
  "nomeFornecedor": "Exemplo Fornecedor",
  "descontoGeral": 10.0,
  "itens": [
    {
      "quantidade": 2,
      "valorUnitario": 50.0,
      "desconto": 5.0,
      "descricao": "Produto A"
    },
    {
      "quantidade": 1,
      "valorUnitario": 30.0,
      "desconto": 0.0,
      "descricao": "Produto B"
    }
  ]
}
```
### Resposta da Solicitação

A resposta da solicitação será o pedido criado, incluindo o número do pedido gerado aleatoriamente e o valor total do pedido.

Exemplo de resposta:

```json
{
  "numeroPedido": 1234,
  "nomeFornecedor": "EXEMPLO FORNECEDOR - Valor Total: R$ 115,00",
  "descontoGeral": 10.0,
  "valorTotal": 115.0,
  "itens": [
    {
      "quantidade": 2,
      "valorUnitario": 50.0,
      "desconto": 5.0,
      "descricao": "Produto A",
      "valorLiquido": 95.0
    },
    {
      "quantidade": 1,
      "valorUnitario": 30.0,
      "desconto": 0.0,
      "descricao": "Produto B",
      "valorLiquido": 30.0
    }
  ]
}
```


