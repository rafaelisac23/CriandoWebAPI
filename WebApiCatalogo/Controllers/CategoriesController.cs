using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCatalogo.Context;
using WebApiCatalogo.Models;

namespace WebApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
       private readonly WebApiCatalogoContext _context;

        public CategoriesController(WebApiCatalogoContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]

        public ActionResult<IEnumerable<Category>> GetCategoriasProducts()
        {
            return _context.Categories.Include(p=>p.Produtcts).ToList();

        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            try
            {
                
                 return _context.Categories.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação ");
                //quando não há conexão com banco
                
            }
              
            
           
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        /*se voce colocar : o valor digitados vai ter que ser obrigatorioamente do informado depois do :*/
        public ActionResult<Category> Get(int id)
        {
            try
            {
                var categoria = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

                if (categoria is null)
                {
                    return NotFound("Valor Não Encontrado");
                }

                return Ok(categoria);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar sua solicitação ");

            }
        }

        [HttpPost]
        public ActionResult Post(Category categoria)
        {

            if (categoria is null)
                return BadRequest();


            _context.Categories.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.CategoryId }, categoria);

            /*para poder acessar esse produto voce vai ter que por no metodo
             get pelo id a seguinte rota ", Name ="ObterProduto" "*/

        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category categoria)
        {
            if (id != categoria.CategoryId)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            if (categoria is null)
            {
                return NotFound("Não encontrado");
            }
            _context.Categories.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }


    }
}
