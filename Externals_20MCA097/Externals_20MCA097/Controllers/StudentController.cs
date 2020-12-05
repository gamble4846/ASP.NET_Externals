using Externals_20MCA097.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Externals_20MCA097.Controllers
{
    public class StudentController : Controller
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rohan\Documents\DBStudents.mdf;Integrated Security=True;Connect Timeout=30");

        public List<Student> GetStudentData()
        {
            SqlCommand cmd = new SqlCommand("Select * from TBLStudents", con);

            List<Student> students = new List<Student>();

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student temp = new Student();
                temp.id = reader.GetInt32(0);
                temp.fname = reader.GetString(1);
                temp.course = reader.GetString(2);
                temp.year = reader.GetInt32(3);
                temp.Gender = reader.GetString(4);

                students.Add(temp);
            }

            con.Close();

            return students;
        }

        // GET: Student
        public ActionResult GetStudent()
        {
            return View("StudentData", GetStudentData());
        }

        public ActionResult CallInsertView()
        {
            return View("InsertStudents");
        }

        public ActionResult AddStudent(Student f)
        {
            if (ModelState.IsValid)
            {
                SqlCommand cmd = new SqlCommand("insert into TBLStudents values ('" + f.fname + "','" + f.course + "'," + f.year + ",'" + f.Gender + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return RedirectToAction("GetStudent");
            }
            else
            {
                return View("InsertStudents");
            }
        }
    }
}