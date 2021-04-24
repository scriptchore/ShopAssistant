using System;
using System.Collections.Generic;


namespace CozyLounge.Models
{
    public partial class Dockets : BaseEntity
    {
     
        public string TransCode { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int SalesPersonId { get; set; }
        public int ProductId { get; set; }
        public int? Total { get; set; }
    }
}
