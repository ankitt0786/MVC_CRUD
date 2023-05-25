using MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class StudentController : Controller
    {
        StudentDB db= new StudentDB();
        List<Student> Students = new List<Student>();
        // GET: Student
        public ActionResult Index()
        {
            Students = db.GetStudentList();
            return View(Students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            db.AddStudent(student);
            return View();
        }


        public ActionResult Delete(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            //Students = db.GetStudent(id);
            var data = db.GetStudentList().Where(item => item.Id == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var data= db.GetStudentList().Where(item=>item.Id==id).FirstOrDefault(); 
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            db.update(student);
            return RedirectToAction("Index");
        }
    }
}