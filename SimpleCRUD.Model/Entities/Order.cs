using SimpleCRUD.Model.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCRUD.Model.Entities
{
    [Table(name: "Orders")]
    public class Order : FullAuditedEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool Shipped { get; set; }

        [ForeignKey(name: "ProductId")]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
