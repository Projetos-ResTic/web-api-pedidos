﻿using Microsoft.EntityFrameworkCore;
using WebApiPedidos.Data;
using WebApiPedidos.Dto.Pedido;
using WebApiPedidos.Models;

namespace WebApiPedidos.Services.StatusPedido
{
    public class StatusPedidoService : IStatusPedidoInterface
    {

        private readonly AppDbContext _context;
        public StatusPedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<StatusPedidoModel>>> AdicionarStatusPedido(StatusPedidoModel statusPedidoModel)
        {
            ResponseModel<List<StatusPedidoModel>> resposta = new ResponseModel<List<StatusPedidoModel>>();

            try
            {
            
                var statusPedido = new StatusPedidoModel
                {
                    Id = statusPedidoModel.Id,
                    Status = statusPedidoModel.Status,
                    Pedidos = new List<PedidoModel>() 
                };

                _context.Add(statusPedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.StatusPedido.ToListAsync();
                resposta.Mensagem = "Status do pedido adicionado com sucesso!";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<List<StatusPedidoModel>>> EditarStatusPedido(StatusPedidoModel statusPedidoModel)
        {
            ResponseModel<List<StatusPedidoModel>> resposta = new ResponseModel<List<StatusPedidoModel>>();

            try
            {
                var statusPedido = await _context.StatusPedido.FirstOrDefaultAsync(statusPedidoBanco => statusPedidoBanco.Id == statusPedidoModel.Id);
                if (statusPedido == null)
                {
                    resposta.Mensagem = "Nenhum status de pedido localizado!";
                    return resposta;
                }

               
                statusPedido.Id = statusPedidoModel.Id;
                statusPedido.Status = statusPedidoModel.Status;


                _context.Update(statusPedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.StatusPedido.ToListAsync();
                resposta.Mensagem = "Status de pedido editado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<StatusPedidoModel>>> ExcluirStatusPedido(int idStatusPedido)
        {
            ResponseModel<List<StatusPedidoModel>> resposta = new ResponseModel<List<StatusPedidoModel>>();
            try
            {
                var statusPedido = await _context.StatusPedido.FirstOrDefaultAsync(pedidoBanco => pedidoBanco.Id == idStatusPedido);

                if (statusPedido == null)
                {
                    resposta.Mensagem = "Nenhum status de pedido localizado!";
                    return resposta;
                }

                _context.Remove(statusPedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.StatusPedido.ToListAsync();
                resposta.Mensagem = " Status de pedido removido!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<StatusPedidoModel>>> ListarStatusPedidos()
        {
            ResponseModel<List<StatusPedidoModel>> resposta = new ResponseModel<List<StatusPedidoModel>>();
            try
            {
                var statusPedidos = await _context.StatusPedido.ToListAsync();

                resposta.Dados = statusPedidos;
                resposta.Mensagem = "Todos os status de pedidos foram coletados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            };
        }
    }
}