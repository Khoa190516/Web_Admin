using Microsoft.AspNetCore.Mvc;
using Web_Admin.Models;

namespace Web_Admin.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<User> users = new List<User>();
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("User").Result;
            users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            return View(users);
        }

        [HttpGet]
        public ActionResult Insert(String id)
        {
            return View(new User());           
        }

        [HttpPost]
        public ActionResult Insert(User user)
        {
            if (user == null || !Validate(user))
            {
                return View();
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("User", user).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(String id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("User/" + id).Result;
            User selectedUser = response.Content.ReadAsAsync<User>().Result;

            return View(selectedUser);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (user == null || !ValidateEdit(user))
            {
                return View();
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("User/"+user.uid, user).Result;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(String id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("User/"+ id).Result;
            }        
            return RedirectToAction("Index");
        }

        private bool Validate(User user)
        {
            IEnumerable<User> users = new List<User>();
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("User").Result;
            users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;

            if (String.IsNullOrEmpty(user.uid) || String.IsNullOrEmpty(user.name)
                || String.IsNullOrEmpty(user.userImageUrl) || String.IsNullOrEmpty(user.email) ||
                String.IsNullOrEmpty(user.joinedAt) || String.IsNullOrEmpty(user.password)||
                user.phoneNumber.ToString().Length < 8)
            {
                return false;
            }

            foreach (User us in users)
            {
                if (us.uid.Equals(user.uid))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateEdit(User user)
        {
            IEnumerable<User> users = new List<User>();
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("User").Result;
            users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;

            if (String.IsNullOrEmpty(user.uid) || String.IsNullOrEmpty(user.name)
                || String.IsNullOrEmpty(user.userImageUrl) || String.IsNullOrEmpty(user.email) ||
                String.IsNullOrEmpty(user.joinedAt) || String.IsNullOrEmpty(user.password) ||
                user.phoneNumber.ToString().Length < 8)
            {
                return false;
            }

            foreach (User us in users)
            {
                if (us.uid.Equals(user.uid))
                {
                    return true;
                }
            }

            return true;
        }

    }
}
