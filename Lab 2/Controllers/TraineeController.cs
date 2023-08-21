using Lab_2.Models;
using Lab_2.ViewModel;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Lab_2.Controllers
{
    public class TraineeController : Controller

    {

        ITIContext db = new ITIContext();
        private object c;

        public IActionResult Index()
        {
            List<Trainee> trainees = db.Trainee.ToList();
            return View(trainees);
        }

        // /trainee/ShowCourseResult/1
        public IActionResult ShowCourseResult(int id)
        {
            List<Course> courses = db.Courses.ToList();
            List<Trainee> trainees = db.Trainee.ToList();
            List<crsResult> crsResults = db.CourseResult.ToList();
            var traineeCourse = (from courseR in crsResults
                                 join course in courses on courseR.crs_id equals course.Id
                                 join trainee in trainees on courseR.trainee_id equals trainee.Id
                                 where courseR.crs_id == id
                                 select new TraineeCrsColorDegree
                                 {
                                     crs_Name = course.Name,
                                     trn_Name = trainee.Name,
                                     degree = courseR.Degree,
                                     color = courseR.Degree < course.minDegree ? "red" : "green"

                                 }).ToList();


            return View(traineeCourse);
        }



        // /trainee/ShowTraineeResult/1
        public IActionResult ShowTraineeResult(int id)
        {
            List<Course> courses = db.Courses.ToList();
            List<Trainee> trainees = db.Trainee.ToList();
            List<crsResult> crsResults = db.CourseResult.ToList();
            var traineeResult = (from courseR in crsResults
                                 join course in courses on courseR.crs_id equals course.Id
                                 join trainee in trainees on courseR.trainee_id equals trainee.Id
                                 where courseR.trainee_id == id
                                 select new TraineeCrsColorDegree
                                 {
                                     crs_Name = course.Name,
                                     trn_Name = trainee.Name,
                                     degree = courseR.Degree,
                                     color = courseR.Degree < course.minDegree ? "red" : "green"

                                 }).ToList();


            return View("ShowTraineeResult", traineeResult);
        }
    }
}
