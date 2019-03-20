using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.Data.Abstract;
using SimpleCRUD.Dto;
using SimpleCRUD.Helpers;
using SimpleCRUD.Model.Entities;

namespace SimpleCRUD.Controllers
{    
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(source: repository.items);
            return new OkObjectResult(result);
            //return new Response(status: true, data: result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return new NotFoundResult();
            }

            //Schedule schedule = repository.items.Where(m => m.Id == id).FirstOrDefault(); //find entity first

            Product product = repository[id]; 

            //Schedule schedule = repository.GetSingle(id: id); 

            if (product == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(mapper.Map<Product, ProductDto>(source: product));
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = repository.Add(mapper.Map<ProductDto, Product>(source: productDto));
            repository.Commit();

            return new OkObjectResult(mapper.Map<Product, ProductDto>(source: item));
        }

        [HttpPut]
        public IActionResult Put([FromBody]ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (productDto.Id <= 0)
            {
                return new NotFoundResult();
            }

            Product product = repository[productDto.Id]; //find entity first
            
            if (product == null)
            {
                return new NotFoundResult();
            }

            //update properties
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.IsDeleted = productDto.IsDeleted;

            var item = repository.Update(product);
            repository.Commit();

            return new OkObjectResult(mapper.Map<Product, ProductDto>(source: item));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new NotFoundResult();
            }

            Product product = repository[id]; //find entity first

            if (product == null)
            {
                return new NotFoundResult();
            }

            var item = repository.Delete(product);
            repository.Commit();

            return new NoContentResult();
        }
    }
}