using System.Text.Json.Serialization;
using WebApiPedidos.Models.WebApiPedidos.Models;

namespace WebApiPedidos.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public int TipoId { get; set; } // Chave estrangeira
        public TipoProdutoModel Tipo { get; set; } // Propriedade de navegação
        public string Nome { get; set; }
        public double Valor { get; set;}

        [JsonIgnore]
        public ICollection<ItemPedidoModel> ItemsPedido { get; set; } = [];
    }
}
