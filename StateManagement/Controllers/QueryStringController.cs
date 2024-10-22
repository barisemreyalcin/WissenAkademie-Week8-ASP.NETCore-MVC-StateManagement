using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;

namespace StateManagement.Controllers
{
	public class QueryStringController : Controller
	{
		public IActionResult Index(int userID, string username, string password)
		{
			User user = new User()
			{
				UserID = userID,
				Username = username,
				Password = password
			};
			return View(user);
		}

 		// Query string nesneleri context'te de taşınıyor
		public IActionResult QueryStringDetails()
		{
			int userID = int.Parse(HttpContext.Request.Query["userID"].ToString());
            string username = HttpContext.Request.Query["username"].ToString();
            string password = HttpContext.Request.Query["password"].ToString();

            User user = new User()
            {
                UserID = userID,
                Username = username,
                Password = password
            };

			return View(user);
        } 
	}
}
