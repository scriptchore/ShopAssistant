using System;
using System.Collections.Generic;


namespace CozyLounge.Models
{
    public class Products
    {
       

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public int CostPrice { get; set; }
        public int SellingPrice { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
