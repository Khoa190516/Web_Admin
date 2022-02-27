using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Admin.Models;

namespace Web_Admin.Controllers
{
    public class AuthensController : Controller
    {
        // GET: Authen
        public ActionResult Index() 
        {
            var login = new Authen();
            return View(login);
        }

        [HttpPost]
        public ActionResult Index(Authen info)
        {
            if(info == null||String.IsNullOrEmpty(info.uid)|| String.IsNullOrEmpty(info.password))
            {
                return View();
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("User/" + info.uid).Result;
            User user = response.Content.ReadAsAsync<User>().Result;
            if(user.password.Equals(info.password.Trim()))
            {
                return RedirectToAction("Index","Home");
            }

            TempData["ErrorMessage"] = "Username or Password is incorrect";
            return View();
        }

    }
}
