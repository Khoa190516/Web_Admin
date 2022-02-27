using System.ComponentModel.DataAnnotations;

namespace Web_Admin.Models
{
    public class User
    {
        [Key]
        [Required]
        [Display(Name = "User ID")]
        public String uid { get; set; }
        [Display(Name = "Name")]
        public String name { get; set; }
        [Display(Name = "Email")]
        public String email { get; set; }
        [Display(Name = "Date Join")]
        public String joinedAt { get; set; }
        [Display(Name = "Phone Number")]
        public int phoneNumber { get; set; }
        [Display(Name = "Avatar")]
        public String userImageUrl { get; set; }
        [Display(Name = "Password")]
        public String password { get; set; }

        public User()
        {

        }
        
    }
}
