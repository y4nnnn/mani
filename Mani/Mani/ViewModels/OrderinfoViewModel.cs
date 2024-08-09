using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mani.ViewModels
{
    public class OrderinfoViewModel
    {
        [Required(ErrorMessage = "姓名為必填欄位")]
        public string Name { get; set; }

        [Required(ErrorMessage = "手機為必填欄位")]
        [RegularExpression(@"^09\d{8}$", ErrorMessage = "手機格式不正確，請輸入正確的手機號碼")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "電子信箱為必填欄位")]
        [EmailAddress(ErrorMessage = "格式不正確")]
        public string Email { get; set; }
    }
}