using Lab_2.Models;
using Microsoft.AspNetCore.Mvc;
using Lab_2.ViewModel;
using Microsoft.EntityFrameworkCore;


namespace Lab_2.Controllers
{
    public class InstructorController : Controller
    {
        ITIContext db = new ITIContext();

        public IActionResult Index()
        {

            List<Instructor> insModel =db.Instructor.ToList();

            return View(insModel);
        }


        public IActionResult Details(int id)
        {
            Instructor ins = db.Instructor.SingleOrDefault(x => x.Id == id);
            Department Dept = db.Department.SingleOrDefault(y => y.Id == ins.dept_id);
            Course crs = db.Courses.SingleOrDefault(c => c.Id == ins.crs_id);

            InsDeptCrs MD = new InsDeptCrs();
            MD.Ins_Id = (int)ins.Id;
            MD.Ins_Name = ins.Name;
            MD.Ins_Image = ins.Image;
            MD.Ins_Address = ins.Address;
            MD.Ins_Salary = ins.Salary;
            MD.Ins_Department = Dept.Name;
            MD.Ins_Course = crs.Name;
            return View(MD);
        }


        public ActionResult ShowResult(int courseId, int studentId)
        {
            var courseResult = db.CourseResult
                .Include(cr => cr.Course)
                .Include(cr => cr.Trainee)
                .FirstOrDefault(cr => cr.crs_id == courseId && cr.trainee_id == studentId);

            if (courseResult == null)
            {
                // Handle case when the course result is not found
                return RedirectToAction("Index");
            }

            var viewModel = new CourseResultV
            {
                CourseId = courseId,
                StudentId = studentId,
                CourseResult = courseResult
            };

            return View(viewModel);
        }

        

        [HttpGet]
        public IActionResult New()
        {
            //List<Department> Depts = db.Department.ToList();
            ViewBag.Depts = db.Department;
            //List<Course> Crses = db.Courses.ToList();
            ViewBag.Crses = db.Courses;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(Instructor instructor , IFormFile Image)
        {
            if (Image == null || Image.Length == 0)
                return Content("file not selected");


            var fileName = Path.GetFileName(Image.FileName);
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/Images",
                fileName);


            using (var stream = new FileStream(path, FileMode.Create))
            {
                await Image.CopyToAsync(stream);
            }

           

            instructor.Image = fileName;

            db.Instructor.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            

        }

        

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Instructor instructor = db.Instructor.SingleOrDefault(x => x.Id == Id);
            List<Department> Depts = db.Department.ToList();
            ViewBag.Depts = Depts;
            List<Course> Crses = db.Courses.ToList();
            ViewBag.Crses = Crses;
            return View(instructor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Instructor instructor, int id , IFormFile Image)
        {
            if (Image == null || Image.Length == 0)
                return Content("file not selected");

            var fileName = Path.GetFileName(Image.FileName);
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/Images",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await Image.CopyToAsync(stream);
            }
            Instructor inst = db.Instructor.SingleOrDefault(x => x.Id == instructor.Id);
            inst.Name = instructor.Name;
            inst.Salary = instructor.Salary;
            inst.Address = instructor.Address;
            inst.dept_id = instructor.dept_id;
            inst.crs_id = instructor.crs_id;


            inst.Image = fileName;
          
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Search(string Name)
        {
            if (Name != "")
            {
                var insts = db.Instructor.Where(x => x.Name.ToLower().Contains(Name.ToLower())).ToList();
                return View("Index", insts);
            }
            else
            {
                var instructors = db.Instructor.ToList();

                return View("Index", instructors);
            }

        }

        public IActionResult Delete(int Id)
        {
            Instructor instructor = db.Instructor.SingleOrDefault(x => x.Id == Id);
            db.Instructor.Remove(instructor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        public IActionResult GetCourseByDept(int deptid)
        {
            List<Course> Crses = db.Courses.Where(d => d.dept_id == deptid).ToList();
            return Json(Crses);
        }


    }
}
