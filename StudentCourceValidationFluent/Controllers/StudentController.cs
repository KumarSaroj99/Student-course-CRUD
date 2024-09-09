using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate;
using StudentCourceValidationFluent.Models;
using StudentCourceValidationFluent.Data;

namespace StudentCourceValidationFluent.Controllers
{

    public class StudentController : Controller
    {
        
        // List all students
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var students = session.Query<Student>().ToList();
                return View(students);
            }
        }

        // Create new student
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
           using(var session = NHibernateHelper.CreateSession())
            {
                using(var transaction = session.BeginTransaction())
                {
                    student.Course.Student=student;
                    session.Save(student);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }
        }


        // Edit student
        public ActionResult Edit(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().SingleOrDefault(u => u.Id == id);
                return View(student);
            }
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    student.Course.Student= student;
                    session.Update(student);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }
            
        }

        // Delete student
        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().SingleOrDefault(u => u.Id == id);
                return View(student);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var student = session.Query<Student>().SingleOrDefault(u => u.Id == id);
                    session.Delete(student);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }
            
        }
        public ActionResult Details(int id)
        {
            using(var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().SingleOrDefault(u=>u.Id==id);
                return View(student);
            }
        }
    }

}