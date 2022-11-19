using MySql.Data.MySqlClient;
using N01576807_Assignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace N01576807_Assignment3.Controllers
{
    public class ClassesDataController : ApiController
    {

        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext schooldb = new SchoolDbContext();

        //This Controller Will access the teachers table of our schooldb database.
        /// <summary>
        /// Returns a list of Classes in the system
        /// </summary>
        /// <example>GET api/ClassData/ListClasses</example>
        /// <returns>
        /// A list of classes (first names and last names)
        /// </returns>

        [HttpGet]

        // For SEARCHING name,hiringdate etc pass the searchKey  as a STRING 
        //And PUT ROUTE
        //[Route("api/ClassData/ListClasses/")]
        public IEnumerable<Class> ListClasses()
        {
            //Create an instance of a connection
            MySqlConnection Conn = schooldb.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY +For SEARCHING
            

            //For Preventing from Web SERVER Crash/ATTACK: do CODE like below
            cmd.CommandText = "Select * from Classes" ;

            

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teachers
            List<Class> Classes = new List<Class> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index

                
                string ClassName = (string)ResultSet["classname"];
               

          
                Class NewClass = new Class();
                NewClass.ClassName = ClassName;
            

                
                //string TeacherName = ResultSet["teacherfname"] + " " + ResultSet["teacherlname"];

                //Add the Teacher Name to the List
                Classes.Add(NewClass);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of teachers names
            return Classes;
        }

    }
}
