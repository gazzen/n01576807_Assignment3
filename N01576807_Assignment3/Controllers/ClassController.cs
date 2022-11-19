using N01576807_Assignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace N01576807_Assignment3.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }



        //GET: /Class/List
        public ActionResult List()
        {
            //To access/Connect ClassDataController
            ClassesDataController controller = new ClassesDataController();
            IEnumerable<Class> Classes = controller.ListClasses();
            return View(Classes);
        }

        //GET: /Class/Show

        public ActionResult Show()
        {
            Class NewClass = new Class();
            NewClass.ClassName = "Web";
        

        

            return View(NewClass);
        }
    }
}