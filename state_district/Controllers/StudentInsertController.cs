using Microsoft.AspNetCore.Mvc;
using state_district.Models;

namespace state_district.Controllers
{
    public class StudentInsertController : Controller
    {
        InsertDB dbobj = new InsertDB();
        private readonly IWebHostEnvironment _hostingEnvironment;
        public StudentInsertController(IWebHostEnvironment hostingEnvironment) //parameterized constructor. This is constructor injection type of dependecy injection. 
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
