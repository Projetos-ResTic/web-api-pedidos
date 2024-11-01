using WebApiPedidos.Dto.Cliente;
using WebApiPedidos.Dto.Pedido;
using WebApiPedidos.Models;

namespace WebApiPedidos.Services.Pedido
{
    public interface IPedidoInterface
    {
        Task<ResponseModel<List<PedidoModel>>> ListarPedidos();

        Task<ResponseModel<List<PedidoModel>>> AdicionarPedido(PedidoCriacaoDto pedidoCriacaoDto);

        Task<ResponseModel<List<PedidoModel>>> EditarPedido(PedidoEdicaoDto pedidoEdicaoDto);
        Task<ResponseModel<List<PedidoModel>>> ExcluirPedido(int idPedido);
    }
}
