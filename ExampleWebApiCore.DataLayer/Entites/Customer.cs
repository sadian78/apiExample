using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.DataLayer.Entites
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string ValidationCode { get; set; }

        [DisplayName("PasswordCustomer")]
        [Required(ErrorMessage = "please enter Customer Password")]
        public string Password { get; set; }

        public TypeOfActivityCustomer? TypeOfActivityCustomer { get; set; }

        [DisplayName("NameCustomer")]
        [MaxLength(30, ErrorMessage = "Customer Name has Over Lenght")]
        public string? Name { get; set; }


        [DisplayName("FamilyCustomer")]
        [MaxLength(30, ErrorMessage = "Customer Family has Over Lenght")]
        public string? Family { get; set; }

        [MaxLength(50, ErrorMessage = "Email has Over Lenght")]
        [EmailAddress]
        public string? Email { get; set; }


        [DisplayName("PhoneNumberCustomer")]
        [Required(ErrorMessage = "please enter Customer PhoneNumber")]
        [MaxLength(15, ErrorMessage = "Customer PhoneNumber has Over Lenght")]
        public string PhoneNumber { get; set; }

        [MaxLength(13, ErrorMessage = "Customer TellPhone has Over Lenght")]
        public string? TellPhone { get; set; }

        [MaxLength(100, ErrorMessage = "Customer Address has Over Lenght")]
        public string? Address { get; set; }
        public DateTime CreateAccount { get; set; }

        #region RelationShip
        public virtual ICollection<Order> Orders { get; set; }
        #endregion
    }

    public enum TypeOfActivityCustomer
    {
        NotActive=1,
        Active=2,
        Delete=3
    }
}
