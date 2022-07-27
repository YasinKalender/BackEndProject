using BackEndProject.Business.Interfaces;
using BackEndProject.Entities.ORM.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBaseService<Product> _productsService;
        public ProductsController(IBaseService<Product> productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _productsService.GetAllAsync());
        }
    }
}
