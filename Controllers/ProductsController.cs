using Microsoft.AspNetCore.Mvc;
using Web_Admin.Models;

namespace Web_Admin.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Product> products = new List<Product>();
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            return View(products);
        }
        
        [HttpGet]
        public ActionResult Insert()
        {          
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Insert(Product product)
        {
            if(product == null || !Validate(product))
            {
                return View();
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Products", product).Result;
            return RedirectToAction("Index");
            
        }

        public ActionResult Edit(String id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/" + id).Result;
            Product selectedProduct = response.Content.ReadAsAsync<Product>().Result;

            return View(selectedProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (product == null || !ValidateEdit(product))
            {
                return View();
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Products/" + product.id, product).Result;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(String id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Products/" + id).Result;
            }
            return RedirectToAction("Index");
        }

        private bool Validate(Product product)
        {
            IEnumerable<Product> products = new List<Product>();
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;

            if (String.IsNullOrEmpty(product.id)||String.IsNullOrEmpty(product.title)
                || String.IsNullOrEmpty(product.description)|| String.IsNullOrEmpty(product.imageUrl)||
                String.IsNullOrEmpty(product.brand)|| String.IsNullOrEmpty(product.productCategoryName)||
                product.price <= 0 || product.quantity < 0)
            {
                return false;
            }
    
            foreach(Product p in products)
            {
                if(p.id == product.id)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateEdit(Product product)
        {
            IEnumerable<Product> products = new List<Product>();
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;

            if (String.IsNullOrEmpty(product.id) || String.IsNullOrEmpty(product.title)
                || String.IsNullOrEmpty(product.description) || String.IsNullOrEmpty(product.imageUrl) ||
                String.IsNullOrEmpty(product.brand) || String.IsNullOrEmpty(product.productCategoryName) ||
                product.price <= 0 || product.quantity < 0)
            {
                return false;
            }

            foreach (Product us in products)
            {
                if (us.id.Equals(product.id))
                {
                    return true;
                }
            }

            return true;
        }
    }

}
