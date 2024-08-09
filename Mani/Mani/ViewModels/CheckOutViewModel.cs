using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Mani.Models;

namespace Mani.ViewModels
{
    public class CheckOutViewModel
    {
        public List<ShoppingItem> CartItems { get; set; }
        public MemberViewModel MemberInfo { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Delivery { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }

        [Required(ErrorMessage = "地址為必填欄位")]
        public string Address { get; set; }
    }
}