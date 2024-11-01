using WebApiPedidos.Models;

namespace WebApiPedidos.Dto.ItemPedido
{
    public class ItemPedidoEdicaoDto
    {
        public int ProdutoId { get; set; }  
        public int PedidoId { get; set; }  
        public int Quantidade { get; set; }
    }
}
