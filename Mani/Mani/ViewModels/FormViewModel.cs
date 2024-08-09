using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mani.ViewModels
{
    public class FormViewModel
    {
        [Required(ErrorMessage = "入住時間為必填欄位")]
        public string CheckIn { get; set; }

        [Required(ErrorMessage = "退房時間為必填欄位")]
        public string CheckOut { get; set; }

        [Required(ErrorMessage = "貓咪姓名為必填欄位")]
        public string CatsName { get; set; }

        [Required(ErrorMessage = "主人姓名為必填欄位")]
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "手機為必填欄位")]
        [RegularExpression(@"^09\d{8}$", ErrorMessage = "手機格式不正確，請輸入正確的手機號碼")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "電子信箱為必填欄位")]
        [EmailAddress(ErrorMessage = "格式不正確")]
        public string Email { get; set; }

        [Required(ErrorMessage = "房型為必填欄位")]
        public string RoomName { get; set; }

        [Required(ErrorMessage = "貓咪數量為必填欄位")]
        public int CatsNum { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}