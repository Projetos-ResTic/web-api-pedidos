using WebApiPedidos.Dto.ItemPedido;
using WebApiPedidos.Models;
using WebApiPedidos.Models.WebApiPedidos.Models;

namespace WebApiPedidos.Services.ItemPedido
{
    public interface IItemPedidoInterface
    {
        Task<ResponseModel<List<ItemPedidoModel>>> ListarItemPedido();

        Task<ResponseModel<List<ItemPedidoModel>>> AdicionarItemPedido(ItemPedidoCriacaoDto itemPedidoCriacaoDto);

        Task<ResponseModel<List<ItemPedidoModel>>> EditarItemPedido(ItemPedidoEdicaoDto itemPedidoEdicaoDto);
        Task<ResponseModel<List<ItemPedidoModel>>> ExcluirItemPedido(int produtoId, int pedidoId);
    }
}
