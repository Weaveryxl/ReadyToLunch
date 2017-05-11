using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadyToLunch.Model.Models
{
    //public enum Role
    //{
    //    Employee, Customer, Manager, CEO
    //}
    // I was thinking about this one, but I'm not sure if it's going to work

    public class User
    {
        public User()
        {
            RegisterDate = DateTime.Now;
            isActived = false;
            VIP = 0;
            FullAddress = Address1 + "\n" + Address2 + "\n" + Address3;
            FullName = FirstName + " " + LastName;

        }
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "User name cannot be longer than 50 characters")]
        [Display(Name = "User Name")]
        public virtual string UserName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password cannot be longer than 50 characters")]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }
        public string Address3 { get; set; }

        [Required]
        public string State { get; set; }

        public DateTime RegisterDate { get; private set; }

        [Required]
        public string Roles { get; set; }
        public bool isActived { get; set; }
        public int VIP { get; set; }

        [Display(Name = "Address")]
        public string FullAddress { get; private set; }

        [Display(Name = "Name")]
        public string FullName { get; private set; }

        [Display(Name = "Contact")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Telephone { get; set; }
    }
}