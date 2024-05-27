namespace WebApiCatalogo.Models;

public class Category
{
    /* quando não tiver os ? em frente ao tipo das variaveis o compilador vai dar um alerta com um verdinho embaixo
     * pois as propriedades por padrão tem que ser nullable
     * 
     * se voce comolocar "nomedaclasse"+Id o proprio entity framework core define aquela propertie como chave primaria na sua tabela
     * do banco de dados !!! fica a dica !!!
     */


    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }

}
