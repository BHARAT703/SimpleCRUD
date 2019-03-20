using SimpleCRUD.Model.Entities;
using System.Collections.Generic;

namespace SimpleCRUD.Data.Abstract
{
    public interface IProductRepository : IEntityBaseRepository<Product> { }

    public interface IOrderRepository : IEntityBaseRepository<Order> { }
}
