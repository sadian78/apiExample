using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.DataLayer.Entites
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("NameProduct")]
        [Required(ErrorMessage = "please enter Product Name")]
        [MaxLength(100, ErrorMessage = "Product Name has Over Lenght")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "please enter Price")]
        public double Price { get; set; }
        public double DisCount { get; set; }
        public double PriceFinally { get; set; }

        [Required(ErrorMessage = "please enter Inventory")]
        public int Inventory { get; set; }

        public int SalePersonId { get; set; }


        #region RelationShip

        [ForeignKey("SalePersonId")]
        public SalePerson SalePerson { get; set; }
        public virtual ICollection<OrderItemSingle> OrderItemSingles { get; set; }

        #endregion
    }
}
