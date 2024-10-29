using WebApiPedidos.Dto.Cliente;
using WebApiPedidos.Models;

namespace WebApiPedidos.Services.Cliente
{
    public interface IClienteInterface
    {
        Task<ResponseModel<List<ClienteModel>>> ListarClientes();
        Task<ResponseModel<ClienteModel>> BuscarClientePorId(int idCliente);
        Task<ResponseModel<ClienteModel>> BuscarClientePorIdPedido(int idPedido);
        Task<ResponseModel<List<ClienteModel>>> AdicionarCliente(ClienteCriacaoDto clienteCriacaoDto);




    }
}
