using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesMac.Migrations
{
    public partial class PopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Categorias\"(\"CategoriaNome\",\"Descricao\") VALUES('Normal','Lanche feito com ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO \"Categorias\"(\"CategoriaNome\",\"Descricao\") VALUES('Natural','Lanche feito com ingredientes integrais e naturais')");

            migrationBuilder.Sql("INSERT INTO \"Lanches\"(\"CategoriaId\",\"DescricaoCurta\",\"DescricaoDetalhada\",\"EmEstoque\",\"ImagemThumbnailUrl\",\"ImagemUrl\",\"IsLanchePreferido\",\"Nome\",\"Preco\") VALUES((select \"CategoriaId\" from \"Categorias\" c where \"CategoriaNome\" = 'Normal'),'Pão, hambúrger, ovo, presunto, queijo e batata palha','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha',true, 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg', false ,'Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO \"Lanches\"(\"CategoriaId\",\"DescricaoCurta\",\"DescricaoDetalhada\",\"EmEstoque\",\"ImagemThumbnailUrl\",\"ImagemUrl\",\"IsLanchePreferido\",\"Nome\",\"Preco\") VALUES((select \"CategoriaId\" from \"Categorias\" c where \"CategoriaNome\" = 'Normal'),'Pão, presunto, mussarela e tomate','Delicioso pão francês quentinho na chapa com presunto e mussarela bem servidos com tomate preparado com carinho.',true,'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg','http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg',false,'Misto Quente', 8.00)");
            migrationBuilder.Sql("INSERT INTO \"Lanches\"(\"CategoriaId\",\"DescricaoCurta\",\"DescricaoDetalhada\",\"EmEstoque\",\"ImagemThumbnailUrl\",\"ImagemUrl\",\"IsLanchePreferido\",\"Nome\",\"Preco\") VALUES((select \"CategoriaId\" from \"Categorias\" c where \"CategoriaNome\" = 'Normal'),'Pão, hambúrger, presunto, mussarela e batalha palha','Pão de hambúrger especial com hambúrger de nossa preparação e presunto e mussarela; acompanha batata palha.',true,'http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg','http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg',false,'Cheese Burger', 11.00)");
            migrationBuilder.Sql("INSERT INTO \"Lanches\"(\"CategoriaId\",\"DescricaoCurta\",\"DescricaoDetalhada\",\"EmEstoque\",\"ImagemThumbnailUrl\",\"ImagemUrl\",\"IsLanchePreferido\",\"Nome\",\"Preco\") VALUES((select \"CategoriaId\" from \"Categorias\" c where \"CategoriaNome\" = 'Natural'),'Pão Integral, queijo branco, peito de peru, cenoura, alface, iogurte','Pão integral natural com queijo branco, peito de peru e cenoura ralada com alface picado e iorgurte natural.',true,'http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg','http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg',false,'Lanche Natural Peito Peru', 15.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Categorias\"");
            migrationBuilder.Sql("DELETE FROM \"Lanches\"");
        }
    }
}
