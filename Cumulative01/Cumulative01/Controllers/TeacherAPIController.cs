using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cumulative01.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Cumulative01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeacherAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context;


        //constructor assign connection to the database and private variable.
        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        //setting up the API method to receveive a GET request to the endpoint /api/Teacher
        [HttpGet(template:"Teacher")]

        //calling database and returning a list of teachers.

        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary>
        /// 
        /// <example>
        /// GET api/Teacher -> [{"TeacherId":1,"TeacherFirstName":"Katrina","TeacherLastName":"Bernadett",...},..]
        /// </example>
        /// 
        /// <returns>
        /// A list of Teacher objects containing ID, Name, EmployeeID, JoinedOn, and Income
        /// </returns>



        public List<Teacher> ListTeacherNames()
        {
            //list of a list type of Teacher which hold the teachers instances in as objects in the list.
            List<Teacher> teachers = new List<Teacher>();
            MySqlConnection Connection = _context.GetConnection();
            Connection.Open();
            Debug.WriteLine("DbConnected");
            string SQLQuery = "SELECT * FROM teachers";
            MySqlCommand Command = Connection.CreateCommand();
            Command.CommandText = SQLQuery;
            MySqlDataReader DataReader = Command.ExecuteReader();
              while (DataReader.Read())
            { 
                int TeacherId = Convert.ToInt32(DataReader["teacherid"]);
                string TeacherFName = DataReader["teacherfname"].ToString();
                string TeacherLName = DataReader["teacherlname"].ToString();
                string EmployeeID = DataReader["employeenumber"].ToString();
                DateTime HireDate = Convert.ToDateTime(DataReader["hiredate"]);
                double Salary = Convert.ToDouble(DataReader["salary"]);

                Teacher newTeacher = new Teacher();
                newTeacher.TeacherId = TeacherId;
                newTeacher.TeacherFirstName = TeacherFName;
                newTeacher.TeacherLastName = TeacherLName;
                newTeacher.EmployeeID = EmployeeID;
                newTeacher.HireDate = HireDate;
                newTeacher.Salary = Salary;
                teachers.Add(newTeacher);


            }
            Connection.Close();
            return teachers;
        }



        /// <summary>
        /// Finding a teacher by their ID
        /// </summary>
        /// 
        /// <example>
        /// GET api/FindTeacher/1 -> {"TeacherId":1,"TeacherFirstName":"Katrina","TeacherLastName":"Bernadett",...}
        /// </example>
        /// 
        /// <param name="id">The ID of the teacher</param>
        /// 
        /// <returns>
        /// A Teacher object containing ID, Name, EmployeeID, HireDate, and Salary
        /// </returns>




        //APIto recieve a GET request to the endpoint /api/FindTeacher/{id}
        [HttpGet]
        [Route(template: "FindTeacher/{id}")]

        //calling the database and returning a teacher object by teacher's ID.
        public Teacher FindTeacher(int id)
        {
            Teacher teacher = new Teacher();
            MySqlConnection Connection = _context.GetConnection();
            Connection.Open();

            string SQL = "Select * FROM teachers Where Teacherid = "+id.ToString();

            MySqlCommand Command = Connection.CreateCommand();
            Command.CommandText = SQL;
            
            MySqlDataReader DataReader = Command.ExecuteReader();

            while (DataReader.Read())
            {
                int TeacherId = Convert.ToInt32(DataReader["teacherid"]);
                string TeacherFName = DataReader["teacherfname"].ToString();
                string TeacherLName = DataReader["teacherlname"].ToString();
                string EmployeeID = DataReader["employeenumber"].ToString();
                DateTime HireDate = Convert.ToDateTime(DataReader["hiredate"]);
                double Salary = Convert.ToDouble(DataReader["salary"]);

                teacher.TeacherId = TeacherId;
                teacher.TeacherFirstName = TeacherFName;
                teacher.TeacherLastName = TeacherLName;
                teacher.EmployeeID = EmployeeID;
                teacher.HireDate = HireDate;
                teacher.Salary = Salary;
            }

            Connection.Close(); 


            return teacher;
        }

    }
}
