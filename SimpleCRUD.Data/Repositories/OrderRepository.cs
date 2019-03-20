using SimpleCRUD.Data.Abstract;
using SimpleCRUD.Model.Entities;

namespace SimpleCRUD.Data.Repositories
{
    public class OrderRepository : EntityBaseRepository<Order>, IOrderRepository
    {
        private readonly ApplicationContext context;

        public OrderRepository(ApplicationContext context) : base(context: context)
        {
            this.context = context;
        }        
    }
}
