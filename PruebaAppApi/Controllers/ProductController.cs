using AplicationServices.Application.Contracts.Product;
using AplicationServices.DTOs.Generics;
using AplicationServices.DTOs.Product;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaAppApi.DataAccess.Entities;

namespace PruebaAppApi.Controllers
{
    [ApiController]
    [Route("Api/Product")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productAppService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productAppService.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var success = await _productAppService.CreateAsync(dto);
            if (!success) return BadRequest("Error al crear el producto");
            return Ok();
        }
    }
}
