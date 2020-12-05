using LanchesMac.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context
{
    /*Nesta classe ocorrem os mapeamentos para as tabelas no banco de dados*/
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        /*IdentitDbContext: Representa os tipos padrão do aspnet para o Identity
         *IdentityUser: Classe padrão que representa a implementação do Entity do Identity
         */
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}