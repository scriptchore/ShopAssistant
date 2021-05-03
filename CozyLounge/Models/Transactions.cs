using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CozyLounge.Models
{
    public partial class Transactions : BaseEntity
    {
  
        public string TransCode { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int SalesPersonId { get; set; }
        public int ProductId { get; set; }

        public virtual Products Product { get; set; }
        public virtual SalesPersons SalesPerson { get; set; }
    }
}
