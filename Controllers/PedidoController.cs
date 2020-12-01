using LanchesMac.Models;
using LanchesMac.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LanchesMac.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IPedidoRepository _repository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(ILogger<PedidoController> logger, IPedidoRepository repository, CarrinhoCompra carrinhoCompra)
        {
            _logger = logger;
            _repository = repository;
            _carrinhoCompra = carrinhoCompra;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            //ModelBind: os dados são injetados pela view conforme modelo definido

            var items = _carrinhoCompra.GetCarrinhoCompraItems();

            _carrinhoCompra.CarrinhoCompraItens = items;

            if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                //adiciona uma mensagem de erro que será disparada quando acontecer o ModelState.isvalid
                ModelState.AddModelError("", "Seu carrinho esta vazio, que tal incluir um lanche...");
            }

            if (ModelState.IsValid)//aplica as validações definidas via annotations
            {
                _repository.CriarPedido(pedido);

                //TempData: usado para passar dados de action para action
                //possui um controle de sessão interno, com um tempo um pouco maior que o viewBag
                //deve ser usado apenas para informações simples, como mostrado a seguir.

                // TempData["Cliente"] = pedido.Nome;
                // TempData["NumeroPedido"] = pedido.PedidoId;
                // TempData["DataPedido"] = pedido.PedidoEnviado;
                // TempData["TotalPedido"] = _carrinhoCompra.GetCarrinhoCompraTotal().ToString("C2");

                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal().ToString("C2");
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :)";

                _carrinhoCompra.LimparCarrinho();
                //aqui eu chamo a action que por sua vez chamará a view. A passagem dos dados é via TempData o que me limita
                //return RedirectToAction("CheckoutCompleto");

                //aqui eu chamo a view diretamente, passando o modelo, me possibilitando exibir mais dados
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }

            return View(pedido);
        }

        public IActionResult CheckoutCompleto()
        {
            //ViewBag = propriedade dinâmica para transportar dados do controller para view "temporariamente"
            //TempData = ver definição acima. Está recebendo os dados enviados de um controller
            ViewBag.Cliente = TempData["Cliente"];
            ViewBag.DataPedido = TempData["DataPedido"];
            ViewBag.NumeroPedido = TempData["NumeroPedido"];
            ViewBag.TotalPedido = TempData["TotalPedido"];
            ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :)";
            return View();
        }
    }
}