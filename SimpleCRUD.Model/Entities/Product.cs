using SimpleCRUD.Model.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCRUD.Model.Entities
{
    [Table(name: "Products")]
    public class Product : FullAuditedEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
    }
}
