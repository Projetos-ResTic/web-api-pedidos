﻿using Microsoft.EntityFrameworkCore;
using WebApiPedidos.Data;
using WebApiPedidos.Dto.ItemPedido;
using WebApiPedidos.Enum;
using WebApiPedidos.Models;
using WebApiPedidos.Models.WebApiPedidos.Models;

namespace WebApiPedidos.Services.ItemPedido
{
    public class ItemPedidoService : IItemPedidoInterface
    {
        private readonly AppDbContext _context;
        public ItemPedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ItemPedidoModel>>> AdicionarItemPedido(ItemPedidoCriacaoDto itemPedidoCriacaoDto)
        {
            ResponseModel<List<ItemPedidoModel>> resposta = new ResponseModel<List<ItemPedidoModel>>();
            try
            {
                var itemPedido = new ItemPedidoModel
                {
                    ProdutoId = itemPedidoCriacaoDto.ProdutoId,
                    PedidoId = itemPedidoCriacaoDto.PedidoId,
                    Quantidade = itemPedidoCriacaoDto.Quantidade
                };

                _context.Add(itemPedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.ItensPedido.ToListAsync();
                resposta.Mensagem = "Item pedido adicionado com sucesso!";
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

        public async Task<ResponseModel<List<ItemPedidoModel>>> EditarItemPedido(ItemPedidoEdicaoDto itemPedidoEdicaoDto)
        {
            ResponseModel<List<ItemPedidoModel>> resposta = new ResponseModel<List<ItemPedidoModel>>();

            try
            {
                var itemPedido = await _context.ItensPedido
            .FirstOrDefaultAsync(item => item.ProdutoId == itemPedidoEdicaoDto.ProdutoId
                                      && item.PedidoId == itemPedidoEdicaoDto.PedidoId);
                if (itemPedido == null)
                {
                    resposta.Mensagem = "Item do pedido não encontrado!";
                    return resposta;
                }

                itemPedido.ProdutoId = itemPedidoEdicaoDto.ProdutoId;
                itemPedido.PedidoId = itemPedidoEdicaoDto.PedidoId;
                itemPedido.Quantidade = itemPedidoEdicaoDto.Quantidade;

                _context.Update(itemPedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.ItensPedido.ToListAsync();
                resposta.Mensagem = "Item do pedido atualizado com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ItemPedidoModel>>> ExcluirItemPedido(int produtoId, int pedidoId)
        {
            ResponseModel<List<ItemPedidoModel>> resposta = new ResponseModel<List<ItemPedidoModel>>();
            try
            {
                var itemPedido = await _context.ItensPedido.FirstOrDefaultAsync(item => item.ProdutoId == produtoId && item.PedidoId == pedidoId);

                if (itemPedido == null)
                {
                    resposta.Mensagem = "Nenhum item de pedido localizado!";
                    return resposta;
                }

                _context.Remove(itemPedido);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.ItensPedido.ToListAsync();
                resposta.Mensagem = "Item de pedido removido com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


        public async Task<ResponseModel<List<ItemPedidoModel>>> ListarItemPedido()
        {
            ResponseModel<List<ItemPedidoModel>> resposta = new ResponseModel<List<ItemPedidoModel>>();
            try
            {
                var itemPedido = await _context.ItensPedido.ToListAsync();

                resposta.Dados = itemPedido;
                resposta.Mensagem = "Todos os itens de pedidos foram coletados!";
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
