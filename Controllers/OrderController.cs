using MyAspMvc.DAL;
using MyAspMvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAspMvc.Controllers
{
    public class OrderController : Controller
    {
        public MyDbContext db = new MyDbContext();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getBookFaculties()
        {
            List<Faculty> faculties = new List<Faculty>();
            faculties = db.Faculties.OrderBy(c => c.Name).ToList();
            return new JsonResult { Data = faculties, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult getBooks(int facultyId)
        {
            List<Book> books = new List<Book>();
            books = db.Books.Where(p => p.FacultyId.Equals(facultyId)).OrderBy(po => po.BookName).ToList();
            return new JsonResult { Data = books, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult Save(OrderMaster order, HttpPostedFileBase file)
        {
            bool status = false;
            if (file != null)
            {
                string folderPath = Server.MapPath("~/Images/");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                file.SaveAs(filePath);
                order.Image = fileName;
            }
            var isvalidmodel = TryUpdateModel(order);
            if (isvalidmodel)
            {
                db.OrderMasters.Add(order);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}
