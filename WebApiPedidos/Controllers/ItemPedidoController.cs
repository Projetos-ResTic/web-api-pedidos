using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPedidos.Dto.ItemPedido;
using WebApiPedidos.Models;
using WebApiPedidos.Models.WebApiPedidos.Models;
using WebApiPedidos.Services.ItemPedido;
using WebApiPedidos.Services.StatusPedido;

namespace WebApiPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoInterface _itemPedidoInterface;
        public ItemPedidoController(IItemPedidoInterface itemPedidoInterface)
        {
            _itemPedidoInterface = itemPedidoInterface;
        }

        [HttpGet("ListarItemPedido")]
        public async Task<ActionResult<ResponseModel<List<ItemPedidoModel>>>> ListarItemPedido()
        {
            var itemPedido = await _itemPedidoInterface.ListarItemPedido();
            return Ok(itemPedido);
        }

        [HttpPost("AdicionarItemPedido")]
        public async Task<ActionResult<ResponseModel<List<ItemPedidoModel>>>> AdicionarItemPedido(ItemPedidoCriacaoDto itemPedidoCriacaoDto)
        {
            var itemPedido = await _itemPedidoInterface.AdicionarItemPedido(itemPedidoCriacaoDto);
            return Ok(itemPedido);
        }


        [HttpPut("EditarItemPedido")]
        public async Task<ActionResult<ResponseModel<List<ItemPedidoModel>>>> EditarItemPedido(ItemPedidoEdicaoDto itemPedidoEdicaoDto)
        {
            var itemPedido = await _itemPedidoInterface.EditarItemPedido(itemPedidoEdicaoDto);
            return Ok(itemPedido);
        }

        [HttpDelete("ExcluirItemPedido")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> ExcluirItemPedido(int produtoId, int pedidoId)
        {
            var itemPedido = await _itemPedidoInterface.ExcluirItemPedido(produtoId, pedidoId);
            return Ok(itemPedido);
        }

    }
}
