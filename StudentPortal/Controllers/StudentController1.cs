using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    public class StudentController1 : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
