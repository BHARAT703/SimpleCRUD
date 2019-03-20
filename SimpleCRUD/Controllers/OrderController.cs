using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.Data.Abstract;
using SimpleCRUD.Dto;
using SimpleCRUD.Model.Entities;

namespace SimpleCRUD.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository repository;
        private readonly IMapper mapper;

        public OrderController(IOrderRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(source: repository.AllIncluding(m => m.Product).ToList()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return new NotFoundResult();
            }

            //Schedule schedule = repository.items.Where(m => m.Id == id).FirstOrDefault(); //find entity first

            Order order = repository[id];

            if (order == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(mapper.Map<Order, OrderDto>(source: order));
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = repository.Add(mapper.Map<OrderDto, Order>(source: orderDto));
            repository.Commit();

            return new OkObjectResult(mapper.Map<Order, OrderDto>(source: item));
        }

        [HttpPut]
        public IActionResult Put([FromBody]OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (orderDto.Id <= 0)
            {
                return new NotFoundResult();
            }

            Order order = repository[orderDto.Id]; //find entity first

            if (order == null)
            {
                return new NotFoundResult();
            }

            //update properties
            order.Name = orderDto.Name;
            order.IsDeleted = orderDto.IsDeleted;
            order.Address = orderDto.Address;
            order.City = orderDto.City;            
            
            var item = repository.Update(order);
            repository.Commit();

            return new OkObjectResult(mapper.Map<Order, OrderDto>(source: item));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new NotFoundResult();
            }

            Order order = repository[id]; //find entity first

            if (order == null)
            {
                return new NotFoundResult();
            }

            var item = repository.Delete(order);
            repository.Commit();

            return new NoContentResult();
        }
    }
}