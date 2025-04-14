using Cumulative01.Models;
using Microsoft.AspNetCore.Mvc;

//handling the requests from the teacher page.
namespace Cumulative01.Controllers
{
  
    public class TeacherPageController : Controller
    {
        private readonly TeacherAPIController _api;

        public TeacherPageController(TeacherAPIController api)
        {
            _api = api;
        }

        // method for the list of teachers.
        /// <summary>
        /// Returns a list of Teachers on the page
        /// </summary>
        /// 
        /// <example>
        /// GET TeacherPage/List -> [{"TeacherId":1,"TeacherFirstName":"Katrina","TeacherLastName":"Bernadett",...},..]
        /// </example>
        /// 
        /// <returns>
        /// A list of Teacher objects containing ID, Name, EmployeeID, JoinedOn, and Income
        /// </returns>

        public IActionResult List()
        {
            List<Teacher> Teach = _api.ListTeacherNames();
            return View(Teach);
        }

        ///method that will be called when the user wants to see the details of a teacher by its ID.

        /// <summary>
        /// Returns details of a specific teacher based on the given ID
        /// </summary>
        /// 
        /// <example>
        /// GET TeacherPage/Show/1 -> {"TeacherId":1,"TeacherFirstName":"Katrina","TeacherLastName":"Bernadett",...}
        /// </example>
        /// 
        /// <param name="Id">The ID of the teacher</param>
        /// 
        /// <returns>
        /// A Teacher object containing ID, Name, EmployeeID, JoinedOn, and Income
        /// </returns>

        public IActionResult Show(int Id)
        {
            Teacher teach1 = _api.FindTeacher(Id);
            return View(teach1);
        }
    }
}
