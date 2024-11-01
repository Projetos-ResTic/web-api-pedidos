using WebApiPedidos.Models;

namespace WebApiPedidos.Dto.Produto
{
    public class ProdutoCriacaoDto
    {
        public int TipoId { get; set; } 
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}
