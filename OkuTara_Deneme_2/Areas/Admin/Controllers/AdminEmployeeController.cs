using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkuTara_Deneme_2.Models.Classes;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class AdminEmployeeController : Controller
    {
        // GET: Admin/AdminEmployee
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var employees = from x in c.Employees select x;
            if (!string.IsNullOrEmpty(p))
            {
                employees = employees.Where(y => y.EmployeeName.Contains(p));
            }

            return View(employees.ToList());
        }

        public ActionResult EmployeeDetail(int id)
        {
            var employee = c.Employees.Find(id);
            return View("EmployeeDetail", employee);
        }

        [HttpPost]
        public ActionResult EmployeeDetail(Employee employee, HttpPostedFileBase PhotoUpload)
        {
            var emp = c.Employees.Find(employee.EmployeeId);

            if (PhotoUpload != null && PhotoUpload.ContentLength > 0)
            {
                // Dosya kaydedileceği klasörün yolu
                try
                {
                    var photoDirectory = Server.MapPath("~/Content/Employee");

                    if (!Directory.Exists(photoDirectory))
                    {
                        Directory.CreateDirectory(photoDirectory);
                    }

                    var photoFileName = Path.GetFileName(PhotoUpload.FileName);

                    var photoPath = Path.Combine(photoDirectory, photoFileName);

                    PhotoUpload.SaveAs(photoPath);

                    emp.EmployeeImage = "/Content/Employee/" + PhotoUpload.FileName;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }


            emp.EmployeeName = employee.EmployeeName;
            emp.EmployeeSurname = employee.EmployeeSurname;
            emp.EmployeeDepartment = employee.EmployeeDepartment;
            c.Entry(emp).State = EntityState.Modified;
            //emp.EmployeeImage = employee.EmployeeImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        //Employee Ekleme
        [HttpGet]
        public ActionResult NewEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewEmployee(Employee employee)
        {
            c.Employees.Add(employee);
            c.SaveChanges();
            return RedirectToAction("Index");
        }  
    }
}