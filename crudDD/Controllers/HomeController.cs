using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crudDD.Models;
using crudDD.Repository;

namespace crudDD.Controllers
{
    public class HomeController : Controller
    {


       //------------------insert Record start Here-----------------------

        [HttpGet]
        public ActionResult insertRecord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insertRecord(Student stu)
        {
                studentRepository rp = new studentRepository();
                    bool key = rp.insertStudent(stu);
                if(key)
                {
                    ViewBag.msg = "Sucess! Added Sucessfully";
                }
            
            return View();
        }

        //-----------------Insert record end here--------------------------


        //---------------Showing Records Starts-----------------------------

        [HttpGet]
        public ActionResult showTables()
        {
            studentRepository sp = new studentRepository();
            List<Student> student_list = sp.show_table();
            ViewBag.students = student_list;
            return View();
        }

        [HttpPost]
        public ActionResult showTables(Student stu)
        {
            return View();
        }

        //-------------------Showing Records Ends-----------------------------
        [HttpGet]
        public ActionResult Delete(string id)
        {
            studentRepository sp = new studentRepository();
            bool key = sp.deleteRecord(id);
            if(key)
            {
                return RedirectToAction("showTables");
            }
            return RedirectToAction("showTables");
        }
        [HttpPost]
        public ActionResult Delete()
        {
            return View();
        }


        [HttpGet]
        public ActionResult updateRecords(string stID)
        {
            studentRepository sp = new studentRepository();
            List<Student> stu_data = sp.bindingSingleData(stID);
            ViewBag.stud_data = stu_data;
            return View();
        }
        [HttpPost]
        public ActionResult updateRecords(Student st)
        {
            studentRepository sp = new studentRepository();
            bool key = sp.updateRecord(st);
            if(key)
            {
                return RedirectToAction("showTables");
            }
            return RedirectToAction("showTables");
        }



    }
}