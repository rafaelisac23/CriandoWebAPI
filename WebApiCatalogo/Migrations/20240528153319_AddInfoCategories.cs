using Microsoft.EntityFrameworkCore.Migrations;
//adcionando valores a tabela

#nullable disable

namespace WebApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class AddInfoCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categories(Name,ImageUrl) values('Bebidas','bebidas.jpg')");
            mb.Sql("Insert into Categories(Name,ImageUrl) values('Lanches','lanches.jpg')");
            mb.Sql("Insert into Categories(Name,ImageUrl) values('Sobremesas','sobremesas.jpg')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {

            mb.Sql("Delete from Categories");

        }
    }
}
