using WebApiPedidos.Models;

namespace WebApiPedidos.Dto.Pedido
{
    public class PedidoEdicaoDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; } 
        public int StatusPedidoId { get; set; } 
        public DateTime DataPedido { get; set; }
    }
}
