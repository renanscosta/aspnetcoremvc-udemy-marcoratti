using LanchesMac.Models;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        public CarrinhoCompra _carrinhoCompra { get; set; }
        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke()
        {
            _carrinhoCompra.CarrinhoCompraItens = _carrinhoCompra.GetCarrinhoCompraItems();
            // _carrinhoCompra.CarrinhoCompraItens = new System.Collections.Generic.List<CarrinhoCompraItem>()
            // {
            //     new CarrinhoCompraItem(), new CarrinhoCompraItem()
            // };

            var vwCarrinhoCompra = new CarrinhoCompraViewModel()
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(vwCarrinhoCompra);
        }

    }
}