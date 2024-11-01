using System.Text.Json.Serialization;
using WebApiPedidos.Enum;

namespace WebApiPedidos.Models
{
    public class StatusPedidoModel
    {
        public int Id { get; set; }
        public StatusPedido Status {  get; set; }

        [JsonIgnore]
        public ICollection<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>(); // Inicializando como lista vazia
    }
}
