using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.DataLayer.Entites
{
    public class OrderItemSingle
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }

        #region RelationShip
        [ForeignKey("OrderItemId")]
        public OrderItem OrderItem { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        #endregion


    }
}
