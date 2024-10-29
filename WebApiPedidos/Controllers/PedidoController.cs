﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPedidos.Dto.Cliente;
using WebApiPedidos.Dto.Pedido;
using WebApiPedidos.Models;
using WebApiPedidos.Services.Cliente;
using WebApiPedidos.Services.Pedido;

namespace WebApiPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoInterface _pedidoInterface;
        public PedidoController(IPedidoInterface pedidoInterface)
        {
            _pedidoInterface = pedidoInterface;
        }

        [HttpGet("ListarPedidos")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> ListarPedidos()
        {
            var pedidos = await _pedidoInterface.ListarPedidos();
            return Ok(pedidos);
        }

        [HttpPost("AdicionarPedido")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> AdicionarPedido(PedidoCriacaoDto pedidoCriacaoDto)
        {
            var pedidos = await _pedidoInterface.AdicionarPedido(pedidoCriacaoDto);
            return Ok(pedidos);
        }
    }
}