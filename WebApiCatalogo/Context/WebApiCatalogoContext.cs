using Microsoft.EntityFrameworkCore;
using WebApiCatalogo.Models;

namespace WebApiCatalogo.Context

    /*Essa classe serve para especificar no banco de dados nossas Entidades/models,mostrar o que é  tabela,
     * o que e campo da tabela
     * Só posso usar se tiver o Microsoft.EntityFrameworkCore
     * "Usado para realizar a comunicação entre as minhas entidades e o banco de dados "
     * mapeamento das entidades
     */
{
    public class WebApiCatalogoContext : DbContext
    {
        public WebApiCatalogoContext(DbContextOptions<WebApiCatalogoContext> options) : base(options) //no construtor voce define um parametro
        {
            
        }
        /*use como base a entidade que deseja usar como exemplo da tabela e depois o nome em plural */
        public DbSet<Category>? Categories { get; set; } 
        public DbSet<Product>? Products { get; set; } 
    }
}
