using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mani.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "帳號為必填欄位")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "密碼為必填欄位")]
        public string PassWord { get; set; }
        public string Name { get; set; }
    }
}