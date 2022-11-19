using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using N01576807_Assignment3.Models;

namespace N01576807_Assignment3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        //GET: /Student/List
        public ActionResult List()
        {
            //To access/Connect StudentDataController
            StudentDataController controller = new StudentDataController();
            IEnumerable<Student> Students = controller.ListStudents();
            return View(Students);
        }

        //GET: /Student/Show

        public ActionResult Show()
        {
            Student NewStudent = new Student();
            NewStudent.StudentFname = "Gajendra";
            NewStudent.StudentLname = "Suwal";

            
            return View(NewStudent);
        }
    }
}