using System.Text.Json.Serialization;
using WebApiPedidos.Models.WebApiPedidos.Models;

namespace WebApiPedidos.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; } // Chave estrangeira
        public ClienteModel Cliente { get; set; } // Propriedade de navegação
        public int StatusPedidoId { get; set; } // Chave estrangeira
        public StatusPedidoModel StatusPedido { get; set; } // Propriedade de navegação
        public DateTime DataPedido { get; set; }

        [JsonIgnore]
        public ICollection<ItemPedidoModel> ItemsPedido { get; set;}
        
    }
}
