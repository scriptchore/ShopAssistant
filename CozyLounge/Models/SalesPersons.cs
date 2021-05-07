using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CozyLounge.Models
{
    public class SalesPersons
    {

        [Key]
        public int SalesPersonId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please enter Fullname.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter Username.")]
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
