using System.Collections.Generic;
using LanchesMac.Models;

namespace LanchesMac.Repositories
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
        IEnumerable<Pedido> Pedidos { get; }
    }
}