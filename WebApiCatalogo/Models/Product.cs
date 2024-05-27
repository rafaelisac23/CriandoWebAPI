namespace WebApiCatalogo.Models;

/*este exemplo não tem imagens armazenadas no banco , apenas o caminho para exemplificar
 * não esquecer de instalar o Pomelo.EntityFrameworkCore.Mysql e o 
 * Microsoft.EntityFrameworkCore.Design para fazer a lincagem com o banco e o 
 * Microsoft.EntityFrameworkCore.Tools para usar o migrations
 
 */
public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public  string? ImageUrl { get; set; }
    public float stock { get; set; }
}
