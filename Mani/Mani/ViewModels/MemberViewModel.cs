using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mani.ViewModels
{
    public class MemberViewModel
    {
        [Required(ErrorMessage = "帳號為必填欄位")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密碼為必填欄位")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "必須由8個英文或數字組合")]

        public string PassWord { get; set; }

        [Compare("PassWord", ErrorMessage = "密碼必須與確認密碼一致")]
        public string ConfirmPassWord { get; set; }

        [Required(ErrorMessage = "姓名為必填欄位")]
        public string Name { get; set; }

        [Required(ErrorMessage = "手機為必填欄位")]
        [RegularExpression(@"^09\d{8}$", ErrorMessage = "手機格式不正確，請輸入正確的手機號碼")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "電子信箱為必填欄位")]
        [EmailAddress(ErrorMessage = "電子信箱格式不正確")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "地址為必填欄位")]
        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Status { get; set; }
    }
}