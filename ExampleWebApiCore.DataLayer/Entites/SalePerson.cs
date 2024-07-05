using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.DataLayer.Entites
{
    public class SalePerson
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("PasswordCustomer")]
        [Required(ErrorMessage = "please enter Customer Password")]
        public string Password { get; set; }

        [DisplayName("NameCustomer")]
        [Required(ErrorMessage = "please enter Customer Name")]
        [MaxLength(30, ErrorMessage = "Customer Name has Over Lenght")]
        public string Name { get; set; }


        [DisplayName("FamilyCustomer")]
        [Required(ErrorMessage = "please enter Customer Family")]
        [MaxLength(30, ErrorMessage = "Customer Family has Over Lenght")]
        public string Family { get; set; }

        [DisplayName("PhoneNumberCustomer")]
        [Required(ErrorMessage = "please enter Customer PhoneNumber")]
        [MaxLength(15, ErrorMessage = "Customer PhoneNumber has Over Lenght")]
        public string PhoneNumber { get; set; }

        [MaxLength(13, ErrorMessage = "Customer TellPhone has Over Lenght")]
        public string? TellPhone { get; set; }


        [MaxLength(100, ErrorMessage = "Customer Address has Over Lenght")]
        public string? Address { get; set; }
        public DateTime BirthDate { get; set; }

        #region RelationShip
        public virtual ICollection<Product> Products { get; set; }
        #endregion
    }
}
