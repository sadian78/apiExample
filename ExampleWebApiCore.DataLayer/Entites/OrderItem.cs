using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.DataLayer.Entites
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public double Price { get; set; }
        public double Discount { get; set; }
        public double PriceFinally { get; set; }
        public string CodeDiscount { get; set; }
        public int OrderId { get; set; }



        #region RelationShip

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public virtual ICollection<OrderItemSingle> OrderItemSingles { get; set; }

        #endregion
    }
}
