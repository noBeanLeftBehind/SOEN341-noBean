using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SOEN341_nobean.Class
{
    public class DBHandler
    {
       
        public DBHandler()
        {
           
        }

        public User getUser(string netname)
        {
            //Global.myConnection.Open();

            var page = HttpContext.Current.CurrentHandler as Page;
            User tempUser = new User();
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[User] WHERE netName = @netName;", Global.myConnection);
                SqlParameter myParam = new SqlParameter("@netName", SqlDbType.VarChar, 11);
                myParam.Value = netname;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tempUser.setUserID(Convert.ToInt32(myReader["UserID"].ToString()));
                    tempUser.setfirstName(myReader["FirstName"].ToString());
                    tempUser.setlastName(myReader["LastName"].ToString());
                    tempUser.setPassword(myReader["Password"].ToString());
                    tempUser.setnetName(myReader["netName"].ToString());
                    tempUser.setEmail(myReader["email"].ToString());
                    tempUser.setStudentID(Convert.ToInt32(myReader["SchoolID"].ToString()));
                    tempUser.setisAdmin(Convert.ToBoolean(myReader["isAdmin"].ToString()));
                    //tempUser.setisAdmin(myReader["isAdmin"].ToString());
                    //page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myReader["isAdmin"].ToString() + "');", true);

                   // tempUser.setisAdmin(myReader[""])

                   
                }
            }
            catch (Exception exp)
            {
                //TextBox3.Text = TextBox3.Text + exp.ToString() + "\n";
                
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }

           

            return tempUser;
        }

        public List<Course> getPreferences(string netname)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            List<Course> preferenceCourses = new List<Course>();
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[Preferences] WHERE netName = @netName;", Global.myConnection);
                SqlParameter myParam = new SqlParameter("@netName", SqlDbType.VarChar, 11);
                myParam.Value = netname;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                String courseID;
                Course tempCourse;
                while (myReader.Read())
                {
                    courseID = myReader["CourseID"].ToString();
                    tempCourse = getCourse(courseID);
                    preferenceCourses.Add(tempCourse);
                }
            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }

            return preferenceCourses;
        }
        public Course getCourse(String CourseID)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            Course course = new Course();
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[Course] WHERE CourseID = @CourseID;", Global.myConnection);
                SqlParameter myParam = new SqlParameter("@CourseID", SqlDbType.VarChar, 11);
                myParam.Value = CourseID;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                course.setCode(myReader["Number"].ToString());
                course.setCourseName(myReader["Name"].ToString());
                course.setPriority(Convert.ToInt32(myReader["Priority"].ToString()));

            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }

            return course;
        }
    }
}