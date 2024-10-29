namespace WebApiPedidos.Models
{
    namespace WebApiPedidos.Models
    {
        public class ItemPedidoModel
        {
            public int ProdutoId { get; set; }  // Chave estrangeira para Produto
            public ProdutoModel Produto { get; set; }  // Propriedade de navegação

            public int PedidoId { get; set; }  // Chave estrangeira para Pedido
            public PedidoModel Pedido { get; set; }  // Propriedade de navegação

            public int Quantidade { get; set; }
        }
    }
}
