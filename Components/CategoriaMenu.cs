using System.Linq;
using LanchesMac.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _repositorio;

        public CategoriaMenu(ICategoriaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _repositorio.Categorias.OrderBy(c => c.CategoriaNome);
            return View(categorias);
        }
    }
}