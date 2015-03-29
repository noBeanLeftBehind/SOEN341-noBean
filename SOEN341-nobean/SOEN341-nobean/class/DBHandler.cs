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

        public User getUserByID(string schoolID)
        {
            //Global.myConnection.Open();

            var page = HttpContext.Current.CurrentHandler as Page;
            User tempUser = new User();
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[User] WHERE schoolID = @schoolID;", Global.myConnection);
                SqlParameter myParam = new SqlParameter("@schoolID", SqlDbType.VarChar, 11);
                myParam.Value = schoolID;
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

        public Course getCourceV2(String CourseID)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            Course course = new Course();
            Section tempLec = new Section();
            try
            {
                SqlDataReader myReader = null;
                SqlDataReader lecReder = null;
                SqlDataReader tutReader = null;
                SqlDataReader labReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[Course] WHERE CourseID = @CourseID;", Global.myConnection
                    );
                SqlParameter myParam = new SqlParameter("@CourseID", SqlDbType.VarChar, 11);
                myParam.Value = CourseID;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                course.setCode(myReader["Number"].ToString());
                course.setCourseName(myReader["Name"].ToString());
                course.setPriority(Convert.ToInt32(myReader["Priority"].ToString()));
                SqlCommand getLec = new SqlCommand(
                    "SELECT * FROM [dbo].[Lecture] WHERE CourseID = @CourseID", Global.myConnection
                    );
                getLec.Parameters.Add(myParam);
                lecReder = getLec.ExecuteReader();
                while(lecReder.HasRows)
                {
                    //populating lecture section object as there maybe more than one section of lectures
                    tempLec.setSemester((int)lecReder["Semester"]);
                    tempLec.setSectionName(lecReder["Section"].ToString());
                    tempLec.setDay(lecReder["onDay"].ToString());
                    tempLec.setTime(lecReder["StartTime"].ToString(), lecReder["EndTime"].ToString());
                    tempLec.setId(lecReder["LecID"].ToString());

                    //populating tut for that particular lecture
                    Section tut = new Section();
                    SqlCommand getTut = new SqlCommand(
                        "SELECT * from [dbo].[Tutorial] WHERE LecID = @LecID", Global.myConnection
                        );
                    SqlParameter tutParam = new SqlParameter("@LecID", SqlDbType.VarChar, 11);
                    tutParam.Value = tempLec.getID();
                    getTut.Parameters.Add(tutParam);
                    tutReader = getTut.ExecuteReader();
                    while (tutReader.HasRows)
                    {
                        tut.setSemester((int)tutReader["Semester"]);
                        tut.setDay(tutReader["onDay"].ToString());
                        tut.setSectionName(tutReader["Section"].ToString());
                        tut.setTime(tutReader["StartTime"].ToString(), tutReader["EndTime"].ToString());
                    }
                    tempLec.addTut(tut);
                    //do something similar for the lab sections
                    Section lab = new Section();
                    SqlCommand getLab = new SqlCommand(
                        "SELECT * from [dbo].[Lab] WHERE LecID = @LecID", Global.myConnection
                        );
                    SqlParameter LabParam = new SqlParameter("@LecID", SqlDbType.VarChar, 11);
                    LabParam.Value = tempLec.getID();
                    getLab.Parameters.Add(LabParam);
                    labReader = getLab.ExecuteReader();
                    while (labReader.HasRows)
                    {
                        lab.setSemester((int)labReader["Semester"]);
                        lab.setDay(labReader["onDay"].ToString());
                        lab.setSectionName(labReader["Section"].ToString());
                        lab.setTime(labReader["StartTime"].ToString(), labReader["EndTime"].ToString());
                    }
                    tempLec.addLab(lab);
                }
                course.addLecture(tempLec);

            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }

            return course;
        }
    }
}