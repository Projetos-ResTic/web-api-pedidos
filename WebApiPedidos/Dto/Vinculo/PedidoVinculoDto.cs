using WebApiPedidos.Models;

namespace WebApiPedidos.Dto.Vinculo
{
    public class PedidoVinculoDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; } // Chave estrangeira

        public int StatusPedidoId { get; set; } // Chave estrangeira
  
        public DateTime DataPedido { get; set; }
    }
}
