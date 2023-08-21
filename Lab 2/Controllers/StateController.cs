using Microsoft.AspNetCore.Mvc;

namespace Lab_2.Controllers
{
    public class StateController : Controller
    {
        public IActionResult setSession(string name)
        {
            
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", 23);
            
            return Content("Session Saved");
        }

        public IActionResult getSession()
        {
            string n = HttpContext.Session.GetString("Name");
            int? a = HttpContext.Session.GetInt32("Age");
            return Content($"name= {n} \t age={a}");
        }


        //=========== Cookie
        public IActionResult SetCookie()
        {

            
            HttpContext.Response.Cookies.Append("Name", "MONA");

            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(1);

            HttpContext.Response.Cookies.Append("Age", "33", cookieOptions);

            return Content("CookieSaved");

        }
        public IActionResult getCookie()
        {
            
            string n = HttpContext.Request.Cookies["Name"];
            string a = HttpContext.Request.Cookies["Age"];
            
            return Content($"name={n}, age={a}");
        }
    }
}
