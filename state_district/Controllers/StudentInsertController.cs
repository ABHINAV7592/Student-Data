using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult insert_pageload()
        {
            List<stclass> stlist = dbobj.selectstates();
            ViewBag.selstates = new SelectList(stlist, "stid", "stname");
            return View();
        }
        [HttpPost]
        public IActionResult insert_click(Insert clsobj,IFormFile singlefile)
        {
            try
            {
                if(singlefile!=null && singlefile.Length > 0)
                {
                    string uploadfolder = Path.Combine(_hostingEnvironment.WebRootPath, "photos"); //server.mappath.
                    string uniquefilename = Guid.NewGuid().ToString() + "_" + Path.GetFileName(singlefile.FileName); //guid togenerate unique id for files.
                    string filepath = Path.Combine(uploadfolder, uniquefilename);
                    using(var stream = System.IO.File.Create(filepath)) //system.IO is namespace and can be used above in namespace directly or used like this.
                    {
                        singlefile.CopyTo(stream);
                    }
                    clsobj.sphoto = "/photos" + uniquefilename;
                }
                string resp = dbobj.insertdb(clsobj);
                TempData["msg"] = resp;
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("insert_pageload");
        }
        public IActionResult getdistricts(int stateid)
        {
            var districts = getdistrictsbystateid(stateid);
            return Json(districts);
        }
        private List<SelectListItem> getdistrictsbystateid(int stateid)
        {
            var dists = dbobj.selectdistrict(stateid);
            var districtsbystate = dists.Select(a => new SelectListItem() { Value = a.did.ToString(), Text = a.dname }).ToList();
            return districtsbystate;
        }


    }
}
