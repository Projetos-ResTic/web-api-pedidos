using Microsoft.EntityFrameworkCore;
using WebApiPedidos.Data;
using WebApiPedidos.Dto.Cliente;
using WebApiPedidos.Dto.Pedido;
using WebApiPedidos.Models;

namespace WebApiPedidos.Services.Pedido
{
    public class PedidoService : IPedidoInterface
    {
        private readonly AppDbContext _context;
        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<PedidoModel>>> AdicionarPedido(PedidoCriacaoDto pedidoCriacaoDto)
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();

            try
            {
                var pedido = new PedidoModel()
                {
                    ClienteId = pedidoCriacaoDto.ClienteId,
                    StatusPedidoId = pedidoCriacaoDto.StatusPedidoId,
                    DataPedido = pedidoCriacaoDto.DataPedido
                };

                _context.Add(pedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Pedidos.ToListAsync();
                resposta.Mensagem = "Pedido adicionado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PedidoModel>>> ListarPedidos()
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();
            try
            {
                var  pedidos = await _context.Pedidos.ToListAsync();

                resposta.Dados = pedidos;
                resposta.Mensagem = "Todos os pedidos foram coletados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
