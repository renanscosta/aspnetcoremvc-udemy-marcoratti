using LanchesMac.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LanchesMac.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "usuario")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UrlRedirect { get; set; }
    }
}