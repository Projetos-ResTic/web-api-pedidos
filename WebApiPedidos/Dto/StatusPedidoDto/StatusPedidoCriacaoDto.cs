using System.Text.Json.Serialization;
using WebApiPedidos.Dto.Vinculo;
using WebApiPedidos.Enum;
using WebApiPedidos.Models;

namespace WebApiPedidos.Dto.StatusPedidoDto
{
    public class StatusPedidoCriacaoDto
    {
        public int Id { get; set; }
        public StatusPedido Status { get; set; }
   
    }
}
