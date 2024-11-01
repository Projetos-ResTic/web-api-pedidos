using WebApiPedidos.Dto.Pedido;
using WebApiPedidos.Dto.Produto;
using WebApiPedidos.Models;

namespace WebApiPedidos.Services.Produto
{
    public interface IProdutoInterface
    {
        Task<ResponseModel<List<ProdutoModel>>> ListarProduto();

        Task<ResponseModel<List<ProdutoModel>>> AdicionarProduto(ProdutoCriacaoDto produtoCriacaoDto);

        Task<ResponseModel<List<ProdutoModel>>> EditarProduto(ProdutoEdicaoDto produtoEdicaoDto);
        Task<ResponseModel<List<ProdutoModel>>> ExcluirProduto(int idProduto);
    }
}
