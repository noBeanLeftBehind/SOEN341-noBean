using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SOEN341_nobean.Class
{
    public class Global
    {
        /// <summary>
        /// Global variable storing important stuff.
        /// this class should contain 
        /// the connection to database that was created at the login page
        /// the User that loged in.. 
        ///     including his preferences from database 
        /// ALSO it will have object of CourseDirectory that will also be created on login before going to home page
        /// </summary>
        /// 

        static SqlConnection _myConnection;
        static public User MainUser;
        static public User Admin;
        static public CourseDirectory CourseDirectory;
        static public List<Course> ListPreferences;
        static public List<Course> ListCourseTaken;
        static public List<Course> ListCourseRemaining;

        Global()
        {
            _myConnection = new SqlConnection();
        }

        ~Global()
        {
            //close connection when global is destructed.. when all pages are closed hopefully ... this should be tested im not sure about it 
            if (_myConnection != null && _myConnection.State == ConnectionState.Open)
            {
                _myConnection.Close();
            }
        }
        /// <summary>
        /// Get or set the static database connection
        /// </summary>
        public static SqlConnection myConnection
        {
            get
            {
                return _myConnection;
            }
            set
            {
                _myConnection = value;
            }
        }
    }
}