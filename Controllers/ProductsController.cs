using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Products;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ProductsController(
            IProductService productService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _productService = productService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        

        [HttpPost("")]
        
        public IActionResult Add([FromBody]ProductModel model)
        {
            // map model to entity
            var product = _mapper.Map<Product>(model);

            try
            {
                // create user
                _productService.Create(product, model.Name, model.Description, model.User, model.Price);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            var model = _mapper.Map<IList<ProductModel>>(products);
            return Ok(model);
        }

        [HttpGet("user/{user}")]
        public IActionResult GetByUser(int user)
        {
            var product = _productService.GetByUser(user);
            var model = _mapper.Map<ProductModel>(product);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            var model = _mapper.Map<ProductModel>(product);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ProductUpdateModel model)
        {
            // map model to entity and set id
            var product = _mapper.Map<Product>(model);
            product.Id = id;

            try
            {
                // update product 
                _productService.Update(product, model.Name, model.Description, model.User, model.Price);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
