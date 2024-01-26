using KostasKatsinas.Portfolio.Services;
using KostasKatsinas.Portfolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace KostasKatsinas.Portfolio.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        public ProductsController(JsonFileProductService productService) 
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);

            return Ok();
        }

        public class RatingRequest
        {
            public string ProductId { get; set; }
            public int Rating { get; set; }
        }

        //[Route("rate")]
        //[HttpGet]
        //public ActionResult Get(
        //    [FromQuery] string ProductId,
        //    [FromQuery] int Rating)
        //{
        //    ProductService.AddRating(ProductId, Rating);
        //    return Ok();
        //}

    }
}
