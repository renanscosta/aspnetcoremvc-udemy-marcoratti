using System.Collections.Generic;
using LanchesMac.Models;
using LanchesMac.Context;
using System;

namespace LanchesMac.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext context, CarrinhoCompra carrinhoCompra)
        {
            _context = context;
            _carrinhoCompra = carrinhoCompra;
        }

        public IEnumerable<Pedido> Pedidos => _context.Pedidos;

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _context.Pedidos.Add(pedido);

            foreach (var carrinhoItem in _carrinhoCompra.CarrinhoCompraItens)
            {
                var pedidoDetalhe = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.LancheId,
                    Preco = carrinhoItem.Lanche.Preco,
                    PedidoId = pedido.PedidoId
                };

                _context.PedidoDetalhes.Add(pedidoDetalhe);
            }

            _context.SaveChanges();

            throw new System.NotImplementedException();
        }
    }
}