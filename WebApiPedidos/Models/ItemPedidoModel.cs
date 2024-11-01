namespace WebApiPedidos.Models
{
    namespace WebApiPedidos.Models
    {
        public class ItemPedidoModel
        {
            public int ProdutoId { get; set; } 
            public ProdutoModel Produto { get; set; }  

            public int PedidoId { get; set; } 
            public PedidoModel Pedido { get; set; }  

            public int Quantidade { get; set; }
        }
    }
}
