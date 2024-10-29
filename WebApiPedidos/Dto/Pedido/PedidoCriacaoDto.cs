using WebApiPedidos.Models;

namespace WebApiPedidos.Dto.Pedido
{
    public class PedidoCriacaoDto
    {
        public int ClienteId { get; set; } 
        public int StatusPedidoId { get; set; } 
        public DateTime DataPedido { get; set; }
    }
}
