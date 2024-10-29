using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPedidos.Dto.Cliente;
using WebApiPedidos.Models;
using WebApiPedidos.Services.Cliente;

namespace WebApiPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;
        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        [HttpGet("ListarClientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ListarClientes()
        {
            var clientes = await _clienteInterface.ListarClientes();
            return Ok(clientes);
        }

        [HttpGet("BuscarClientePorId/{idCliente}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> BuscarClientePorId(int idCliente)
        {
            var cliente = await _clienteInterface.BuscarClientePorId(idCliente);
            return Ok(cliente);
        }


        [HttpGet("BuscarClientePorIdPedido/{idPedido}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> BuscarClientePorIdPedido(int idPedido)
        {
            var cliente = await _clienteInterface.BuscarClientePorIdPedido(idPedido);
            return Ok(cliente);
        }

        [HttpPost("AdicionarCliente")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> AdicionarCliente(ClienteCriacaoDto clienteCriacaoDto)
        {
            var clientes = await _clienteInterface.AdicionarCliente(clienteCriacaoDto);
            return Ok(clientes);
        }
    }
}
