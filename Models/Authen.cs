using System.ComponentModel.DataAnnotations;

namespace Web_Admin.Models
{
    public class Authen
    {
        [Required(ErrorMessage ="Username is required")]
        [Display(Name = "Username")]
        public String uid { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public String password { get; set; }

        public Authen()
        {

        }
    }
}
