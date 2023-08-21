using Lab_2.Models;
using Microsoft.AspNetCore.Mvc;
using Lab_2.ViewModel;
using Lab_2.Repository;
using NuGet.Protocol.Core.Types;

namespace Lab_2.Controllers
{
    public class CourseController : Controller
    {
        ITIContext db = new ITIContext();
        //public CourseController()
        //{
        //    db = new ITIContext();
        //}



        //-------------------- Day8 --------------------

        ICourseRepository courseRepository;

        IDepartementRepository departementRepository;
        //DIP
        public CourseController(ICourseRepository crsRepo, IDepartementRepository deptRepo)  //injection
        {
            courseRepository = crsRepo;
            departementRepository = deptRepo;
           
        }

        //----------------------------------------


        [HttpGet]
        public IActionResult Index()
        {
            List<Course> crsmodel =db.Courses.ToList();
            return View(crsmodel);
        }

        [HttpGet]
        public IActionResult New()
        {
            //  List<Course> crs = db.Courses.ToList();
            List<Course> crs = courseRepository.GetAll();

            List<Department> Depts = db.Department.ToList();
            ViewBag.Depts = Depts;

            //ViewData["DeptList"]= db.Department.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Course course)

        {
            //if (course != null)
            if (ModelState.IsValid == true)
            {
                courseRepository.Add(course);
                courseRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                // ViewData["DeptList"] = db.Department.ToList();
                List<Department> Depts = db.Department.ToList();
                ViewBag.Depts = Depts;
                return View(course);
            }
        }

//================ Details
        public IActionResult Details(int id)
        {
            Course? course = db.Courses.SingleOrDefault(c => c.Id == id);
            if (course == null)
            {
                // Handle the case when the course is not found
                return NotFound();
            }

            Department? dept = db.Department.SingleOrDefault(y => y.Id == course.dept_id);
            if (dept == null)
            {
                // Handle the case when the department associated with the course is not found
                return NotFound();
            }

            crsDept crd = new crsDept();
            crd.Crsid = (int)course.Id;
            crd.Crsname = course.Name;
            crd.Crsdergree = course.Degree;
            crd.CrsMindergree = course.minDegree;
            crd.CrsDept = dept.Name;
            return View(crd);
        }

//================ Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Course course = db.Courses.SingleOrDefault(c => c.Id == id);
            Course course = courseRepository.GetBYId(id);
            //List<Department> departments = db.Department.ToList();
            //ViewBag.Departments = departments;



            List<Department> Depts = departementRepository.GetAll();
            ViewBag.Depts = Depts;

            List<Course> Crses = courseRepository.GetAll();
            ViewBag.Crses = Crses;

            // ViewData["DeptList"] = db.Department.ToList();
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Course course , int id)
        {
            //if (course != null)
            if (ModelState.IsValid == true)
            { 
                courseRepository.Update(id,course);


                ////Course crs = db.Courses.SingleOrDefault(c => c.Id == course.Id);
                ////crs.Name = course.Name;
                ////crs.Degree = course.Degree;
                ////crs.minDegree = course.minDegree;
                ////crs.dept_id = course.dept_id;
                /// db.SaveChanges();
                courseRepository.Save();
                return RedirectToAction("index");
            }
            else
            {
               // ViewData["DeptList"] = db.Department.ToList();

                List<Department> Depts = departementRepository.GetAll();
                ViewBag.Depts = Depts;
                return View(course);
            }
        }



        public IActionResult Delete(int Id)
        {
            //Course course = db.Courses.SingleOrDefault(c => c.Id == Id); 
            // db.Courses.Remove(course);
            Course course = courseRepository.GetBYId(Id);
            courseRepository.Delete(Id);
            courseRepository.Save();
           // db.SaveChanges();
            return RedirectToAction("Index");
        }


        public JsonResult ValidateMinDegree(int minDegree, int degree)
        {
            if (minDegree < degree)
            {
                return Json(true);
            }

            return Json($"The minimum degree must be less than the course degree ({degree}).");
        }
    }
}
