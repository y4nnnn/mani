using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mani.Models
{
    public class ShoppingItem
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public string ProductImg { get; set; }

        //public int UnitInStock { get; set; }

        public string ProductDesc { get; set; }

        public int Amount { get; set; }
    }
}