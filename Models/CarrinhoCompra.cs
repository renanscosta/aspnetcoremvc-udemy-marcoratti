using System;
using System.Collections.Generic;
using System.Linq;
using LanchesMac.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _contexto;

        public CarrinhoCompra(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessao acessando o contexto atual (tem que registrar em IServiceCollection)
            ISession session =
            services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto de banco de dados
            var context = services.GetService<AppDbContext>();

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche, int quantidade)
        {
            var carrinhoCompraItem = _contexto.CarrinhoCompraItens.SingleOrDefault(s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = quantidade
                };

                _contexto.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade = quantidade;
            }

            _contexto.SaveChanges();
        }

        public int RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _contexto.CarrinhoCompraItens.SingleOrDefault(s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                    _contexto.CarrinhoCompraItens.Remove(carrinhoCompraItem);
            }

            _contexto.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItens ??
            (CarrinhoCompraItens = _contexto.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                                                                .Include(s => s.Lanche)
                                                                .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _contexto.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId);

            _contexto.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _contexto.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _contexto.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                                                    .Select(c => c.Lanche.Preco * c.Quantidade).Sum();

            return total;
        }
    }
}