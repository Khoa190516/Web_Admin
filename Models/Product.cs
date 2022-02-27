using System.ComponentModel.DataAnnotations;

namespace Web_Admin.Models
{
    public class Product
    {
        [Key]
        [Required]
        [Display(Name = "Product ID")]
        public String id { get; set; }
        [Display(Name = "Product Name")]
        public String title { get; set; }
        [Display(Name = "Product Description")]
        public String description { get; set; }
        [Display(Name = "Price")]
        public float price { get; set; }
        [Display(Name = "Product Image")]
        public String imageUrl { get; set; }
        [Display(Name = "Category")]
        public String productCategoryName { get; set; }
        [Display(Name = "Brand")]
        public String brand { get; set; }
        [Display(Name = "Quantity")]
        public int quantity { get; set; }
        [Display(Name = "Favorite")]
        public Boolean isFavorite { get; set; }
        [Display(Name = "Popular")]
        public Boolean isPopular { get; set; }

        public Product()
        {

        }
    }
}
