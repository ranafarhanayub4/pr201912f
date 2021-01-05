using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication20.Models;

namespace WebApplication20.Controllers
{
    
    public class HomeController : Controller
    {
        aptech_studentsEntities db = new aptech_studentsEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getdata()
        {
            return View(db.teachers.ToList());
        }
        public JsonResult delete(int id)
        {
            var data = db.teachers.Find(id);
            if (data == null)
            {
                var msg = new
                {
                    message = "unable to delete",
                    status = 1,
                    color = "red"
                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            else
            {
                db.teachers.Remove(data);
                db.SaveChanges();
                var msg = new
                {
                    message = "delete succefully",
                    status = 1,
                    color = "green"
                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            

           
        }
        public JsonResult update(teacher t)
        {
            var data = db.teachers.Find(t.teacherid);
            if (data == null)
            {
                var msg = new
                {
                    message = "unable to Update",
                    status = 1,
                    color = "red"
                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            else
            {
                data.teacher_name = t.teacher_name;
                data.working_hours = t.working_hours;
                db.SaveChanges();
                var msg = new
                {
                    message = "Update succefully",
                    status = 1,
                    color = "green"
                };
                return Json(msg, JsonRequestBehavior.AllowGet);
            }



        }
    }
}