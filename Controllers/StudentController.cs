using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentProject.DAL;
using StudentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration configuration;
        StudentDAL studentdal;
        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            studentdal = new StudentDAL(configuration);
        }

        public ActionResult List()
        {
            var student = studentdal.GetAllStudent();
            return View(student);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = studentdal.GetStudentById(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student stud)
        {
            try
            {
                int res = studentdal.AddStudent(stud);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET:StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = studentdal.GetStudentById(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student stud)
        {
            try
            {
                int res = studentdal.UpdateStudent(stud);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = studentdal.GetStudentById(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int res = studentdal.DeleteStudent(id);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }

        }
    }
}
