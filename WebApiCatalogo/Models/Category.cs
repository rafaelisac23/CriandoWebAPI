using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations; //tem que ser adcionado quando se faz um data anotation
using System.ComponentModel.DataAnnotations.Schema;//tem que ser adcionado quando se faz um data anotation

namespace WebApiCatalogo.Models;


// aqui adcionamos o data anotation que é nada mais nada menos do jeito que voce quer que fique o nome e o formato no banco de dados

[Table("Categories")]
public class Category
 
{

    public Category()
    {
        Produtcts = new Collection<Product>();
    }
    /* quando não tiver os ? em frente ao tipo das variaveis o compilador vai dar um alerta com um verdinho embaixo
     * pois as propriedades por padrão tem que ser nullable
     * 
     * se voce comolocar "nomedaclasse"+Id o proprio entity framework core define aquela propertie como chave primaria na sua tabela
     * do banco de dados !!! fica a dica !!!
     */

    [Key]
    public int CategoryId { get; set; }


    [Required]// DataAnnotations
    [StringLength(80)]// DataAnnotations
    public string? Name { get; set; }

    [Required]// DataAnnotations
    [StringLength(300)] // DataAnnotations
    public string? ImageUrl { get; set; }

    // definindo entidade de navegação - chave estrangeira no banco de dados

    public ICollection<Product>? Produtcts { get; set; }

}
