using System.Text.Json.Serialization;

namespace WebApiPedidos.Models
{
    public class TipoProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public ICollection<ProdutoModel> Produtos { get; set; }
    }
}
