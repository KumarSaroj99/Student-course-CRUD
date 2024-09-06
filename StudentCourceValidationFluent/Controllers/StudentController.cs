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
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(student);
                        transaction.Commit();
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }

        // Edit student
        public ActionResult Edit(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Get<Student>(id);
                if (student == null) return HttpNotFound();
                return View(student);
            }
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Update(student);
                        transaction.Commit();
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }

        // Delete student
        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Get<Student>(id);
                if (student == null) return HttpNotFound();
                return View(student);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Get<Student>(id);
                if (student != null)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(student);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
        }
    }

}