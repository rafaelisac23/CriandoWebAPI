using Microsoft.AspNetCore.Mvc;
using WebApiCatalogo.Context;
using WebApiCatalogo.Models;

namespace WebApiCatalogo.Controllers
{
    [Route("controller")]
    [ApiController]
    public class ProductsController : Controller
    {
        /* variavel do tipo readonly e apenas para leitura
         * aqui essa variavel junto com o construtor indica que o banco de dados vai ter que ser acessado
         por esse controller */


        private readonly WebApiCatalogoContext _context;

        public ProductsController(WebApiCatalogoContext context)
        {
            _context = context;
        }

        // Fica a Dica !!!
        /* voce quando quiser fazer listas voce pode usar o list mas tente aplicar a boa pratica
         de usar IEnumerable por ser mais agil e melhor */

        /*aqui os metodos não sao Sincronos , os mais utilizados são sincronos ,então use os sincronos*/

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _context.Products.ToList(); /*aqui ele ta colocando a tabela do banco de dados Products como valor da variavel*/
            if (products is null)
            {
                return NotFound("Produtos Não Encontrados");
                /*aqui pode ser caso não ache o valor
                 * se voce so deixar return NotFound(); ele vai dar erro pois nao vai conseguir transformar 
                 * o valor de products em NotFound() ai voce adciona ActionResult<> no tipo da function
                 * para dizer que o valor que vai retornar é um Ienumerable do tipo Product
                 */
            }

            return products;
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        /*se voce colocar : o valor digitados vai ter que ser obrigatorioamente do informado depois do :*/
        public ActionResult<Product> Get(int id)
        {
            var product = _context.Products.FirstOrDefault(p=>p.ProductId == id);

            if (product is null)
            {
                return NotFound("Valor Não Encontrado");
            }

            return product;
            
        }

        [HttpPost]
        public ActionResult Post(Product produto)
        {

            if (produto is null)
                return BadRequest();


             _context.Products.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProductId }, produto);

            /*para poder acessar esse produto voce vai ter que por no metodo
             get pelo id a seguinte rota ", Name ="ObterProduto" "*/

        }

        
    }
}
