using WebApiPedidos.Dto.Pedido;
using WebApiPedidos.Models;

namespace WebApiPedidos.Services.StatusPedido
{
    public interface IStatusPedidoInterface
    {

        Task<ResponseModel<List<StatusPedidoModel>>> ListarStatusPedidos();

        Task<ResponseModel<List<StatusPedidoModel>>> AdicionarStatusPedido(StatusPedidoModel statusPedidoModel);

        Task<ResponseModel<List<StatusPedidoModel>>> EditarStatusPedido(StatusPedidoModel statusPedidoModel);
        Task<ResponseModel<List<StatusPedidoModel>>> ExcluirStatusPedido(int idStatusPedido);
    }
}
