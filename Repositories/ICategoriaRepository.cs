using System.Collections.Generic;
using LanchesMac.Models;

namespace LanchesMac.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}