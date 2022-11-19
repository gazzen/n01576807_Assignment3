using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using N01576807_Assignment3.Models;
using MySql.Data.MySqlClient;

namespace N01576807_Assignment3.Controllers
{
    public class StudentDataController : ApiController
    {

        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext schooldb = new SchoolDbContext();

        //This Controller Will access the students table of our schooldb database.
        /// <summary>
        /// Returns a list of Students in the system
        /// </summary>
        /// <example>GET api/StudentData/ListStudents</example>
        /// <returns>
        /// A list of students (first names and last names)
        /// </returns>

        [HttpGet]

        // For SEARCHING name,hiringdate etc pass the searchKey  as a STRING 
        //And PUT ROUTE
        //[Route("api/StudentData/ListStudents")]
        public IEnumerable<Student> ListStudents()
        {
            //Create an instance of a connection
            MySqlConnection Conn = schooldb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY +For SEARCHING
            cmd.CommandText = "Select * from Students";

            
            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Students
            List<Student> Students = new List<Student> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index

               
                string StudentFname = (string)ResultSet["studentfname"];
                string StudentLname = (string)ResultSet["studentlname"];

               

                Student NewStudent = new Student();
                
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;

                                

                //Add the Student Name to the List
                Students.Add(NewStudent);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of teachers names
            return Students;
        }

        [HttpGet]
        public Student FindStudent(int id)
        {
            Student NewStudent = new Student();

            return NewStudent;
        }
    }
}
