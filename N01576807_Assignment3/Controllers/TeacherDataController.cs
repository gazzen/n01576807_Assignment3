using N01576807_Assignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MySql.Data.MySqlClient;

namespace N01576807_Assignment3.Controllers
{
    public class TeacherDataController : ApiController
    {


        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext schooldb = new SchoolDbContext();

        //This Controller Will access the teachers table of our schooldb database.
        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers</example>
        /// <returns>
        /// A list of teachers (first names and last names)
        /// </returns>
        
        [HttpGet]

        // For SEARCHING name,hiringdate etc pass the searchKey  as a STRING 
        //And PUT ROUTE
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        public IEnumerable<Teacher> ListTeachers(string SearchKey=null)
        {
            //Create an instance of a connection
            MySqlConnection Conn = schooldb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY +For SEARCHING
            //cmd.CommandText = "Select * from Teachers where lower(teacherfname) like lower('%"+Searchkey+"%') or lower(teacherlname) like lower('%"+Searchkey+"%') or lower(concat(teacherfname, ' ', teacherlname)) like lower('%"+SearchKey+ "%') or lower(hiredate) like lower('%"+SearchKey+ "%') or lower(salary) like lower('%"+SearchKey+"%')";

            //For Preventing from Web SERVER Crash/ATTACK: do CODE like below
            cmd.CommandText = "Select * from Teachers where lower(teacherfname) like lower(@key) or lower(teacherlname) like lower(@key) or lower(concat(teacherfname, ' ', teacherlname)) like lower(@key) or lower(hiredate) like lower(@key) or lower(salary) like lower(@key)";

            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();
            
            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teachers
            List<Teacher> Teachers = new List<Teacher>{ };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index

                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];

                string HireDate = (string)ResultSet["hiredate"];
                string Salary = (string)ResultSet["salary"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;

                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
                //string TeacherName = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];

                //Add the Teacher Name to the List
                Teachers.Add(NewTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of teachers names
            return Teachers;
        }

        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            return NewTeacher;
        }

    }
}
