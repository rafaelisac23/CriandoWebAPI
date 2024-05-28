using System.ComponentModel.DataAnnotations;//tem que ser adcionado quando se faz um data anotation
using System.ComponentModel.DataAnnotations.Schema;//tem que ser adcionado quando se faz um data anotation

namespace WebApiCatalogo.Models;

/*este exemplo não tem imagens armazenadas no banco , apenas o caminho para exemplificar
 * não esquecer de instalar o Pomelo.EntityFrameworkCore.Mysql e o 
 * Microsoft.EntityFrameworkCore.Design para fazer a lincagem com o banco e o 
 * Microsoft.EntityFrameworkCore.Tools para usar o migrations
 
 */

[Table("Products")]
public class Product
{
    [Key]// DataAnnotations
    public int ProductId { get; set; }

    [Required]// DataAnnotations
    [StringLength(80)]// DataAnnotations
    public string? Name { get; set; }

    [Required]// DataAnnotations
    [StringLength(300)]// DataAnnotations
    public string? Description { get; set; }

    [Required]// DataAnnotations
    [Column(TypeName="decimal(10,2)")]// DataAnnotations
    public decimal Price { get; set; }

    [Required]// DataAnnotations
    [StringLength(300)]// DataAnnotations
    public  string? ImageUrl { get; set; }

    public float stock { get; set; }

    public DateTime DataCadastro { get; set; }

    //definindo chave estrangeira em produto - pode se usar esse ou o outro da category

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
