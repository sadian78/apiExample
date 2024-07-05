using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.DataLayer.Entites
{
    public class Order
    {

        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        public int CustomerId { get; set; }



        #region RelationShip
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        #endregion
    }
}
