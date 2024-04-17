using Microsoft.AspNetCore.Mvc;

namespace MDK._01._01_PR_38.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult Index()
        {
            return Redirect("/Items/List");
        }
    }
}
