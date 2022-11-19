using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N01576807_Assignment3.Models;

namespace N01576807_Assignment3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET: /Teacher/List
        public ActionResult List(string SearchKey=null)
        {
            //To access/Connect TeacherDataController
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        //GET: /Teacher/Show/{id}

        public ActionResult Show(int id)
        {
            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = "Gajendra";
            NewTeacher.TeacherLname = "Suwal";

            NewTeacher.HireDate = "2022-06-09";
            NewTeacher.Salary = "55.55";

            return View(NewTeacher);
        }
    }
}