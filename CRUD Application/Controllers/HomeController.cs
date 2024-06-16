using CRUD_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult AddEmployee()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }
            try
            {

                _context.Emplyees.Add(model);
                _context.SaveChanges();
                TempData["msg"] = "Added Successfully";
                RedirectToAction("AddEmployee");
            }

            catch (Exception ex)
            {
                TempData["EX MSG"] = "Unable to add" + ex.Message;

            }
            return View();

        }

        public IActionResult ListEmployee()
        {
            var EmployeeList = _context.Emplyees.ToList();
            return View(EmployeeList);
        }

        public IActionResult EditEmployee(int id)
        {
            var Employee = _context.Emplyees.SingleOrDefault(x => x.Id == id);
            return View(Employee);
        }

        [HttpPost]

        public IActionResult EditEmployee(EmployeeModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _context.Emplyees.Update(model);
                _context.SaveChanges();
                RedirectToAction("ListEmployee");
                TempData["msg"] = "updated successfully";
               
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Unable to update" + ex.Message;
            }

            return View();

        }


        public IActionResult DeleteEmployee(int id)
        {



            try
            {
                var EmpDelete = _context.Emplyees.SingleOrDefault(y => y.Id == id);

                if (EmpDelete != null)
                {
                    _context.Emplyees.Remove(EmpDelete);
                    _context.SaveChanges();

                }

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("Listemployee");
        }
    }
}
