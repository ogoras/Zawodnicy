using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zawodnicy.WebApp.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage="Wymagana nazwa użytkownika")]
        [Display(Name= "Nazwa użytkownika")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Wymagane hasło")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
