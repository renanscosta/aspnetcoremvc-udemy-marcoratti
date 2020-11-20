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

        public IActionResult List()
        {
            var viewModel = new LancheListViewModel();
            viewModel.Lanches = _lancheRepository.Lanches;
            viewModel.CategoriaAtual = "Todos os lanches";

            return View(viewModel);
        }
    }
}
