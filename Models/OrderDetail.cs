using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAspMvc.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderMasterId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public OrderMaster OrderMaster { get; set; }
    }
}