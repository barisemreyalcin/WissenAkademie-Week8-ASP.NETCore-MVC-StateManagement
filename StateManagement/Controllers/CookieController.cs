using Microsoft.AspNetCore.Mvc;

namespace StateManagement.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            // HttpContext http üzerindeki yapılara erişmemi sağlar. Response/Request olaya göre
            // Cookies bir collection
            // Kullanıcı izin verirse bu dataları kullanıcıya özel temp folder'da saklar
            HttpContext.Response.Cookies.Append("AppName", "Contoso"); // key value
            HttpContext.Response.Cookies.Append("PersonName", "John Doe");
            HttpContext.Response.Cookies.Append("PersonAge", "30"); 
            HttpContext.Response.Cookies.Append("PersonMail", "johndoe@contoso.com");
            HttpContext.Response.Cookies.Append("Role", "User"); 
            return View();
        }

        public IActionResult ShowCookie()
        {
            ViewBag.AppName = GetCookieVal("AppName");
            ViewBag.PersonName = GetCookieVal("PersonName");
            ViewBag.PersonAge = GetCookieVal("PersonAge");
            ViewBag.PersonMail = GetCookieVal("PersonMail");
            ViewBag.Role = GetCookieVal("Role");
            return View();
		}

		private string GetCookieVal(string key) // key: AppName, PersonName...
		{
            // Kullanıcının makineden bir şey okuyabilmem için Request
            HttpContext.Request.Cookies.TryGetValue(key, out string cookieValue);
            return cookieValue;
		}
	}
}
