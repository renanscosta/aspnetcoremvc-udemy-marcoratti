using System.Collections.Generic;
using LanchesMac.Models;
using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LanchesMac.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c=>c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(l=> l.IsLanchePreferido).Include(c=>c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(item => item.LancheId == lancheId);
        }

    }
}