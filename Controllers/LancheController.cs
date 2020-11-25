using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LanchesMac.Models;
using LanchesMac.Repositories;
using LanchesMac.ViewModel;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILogger<LancheController> _logger;
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LancheController(ILogger<LancheController> logger, ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
        {
            _logger = logger;
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string _categoria = categoria;

            if (String.IsNullOrWhiteSpace(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(lanches => lanches.LancheId);
                _categoria = "Todos os lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals(_categoria, StringComparison.OrdinalIgnoreCase))
                                                          .OrderBy(l => l.Nome);
            }


            var viewModel = new LancheListViewModel();
            viewModel.Lanches = lanches;
            viewModel.CategoriaAtual = _categoria;

            return View(viewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);

            if (lanche == null)
                return View("~/Views/Error/Error.cshtml");

            return View(lanche);
        }
    }
}
