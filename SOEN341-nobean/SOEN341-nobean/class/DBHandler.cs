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
            User tempUser = null;
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[User] WHERE netName = @netName;", Global.myConnection);
                SqlParameter myParam = new SqlParameter("@netName", SqlDbType.VarChar);
                myParam.Value = netname;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tempUser = new User();
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
                myReader.Close();
            }
            catch (Exception exp)
            {
                //TextBox3.Text = TextBox3.Text + exp.ToString() + "\n";
                
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }

           

            return tempUser;
        }
        public User getUserByEmail(string email)
        {
            //Global.myConnection.Open();

            var page = HttpContext.Current.CurrentHandler as Page;
            User tempUser = null;
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[User] WHERE email = @email;", Global.myConnection);
                SqlParameter myParam = new SqlParameter("@email", SqlDbType.VarChar);
                myParam.Value = email;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tempUser = new User();
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
                myReader.Close();
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
            User tempUser = null;
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[User] WHERE schoolID = @schoolID;", Global.myConnection);
                SqlParameter myParam = new SqlParameter("@schoolID", SqlDbType.VarChar);
                myParam.Value = schoolID;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tempUser = new User();
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
                myReader.Close();
            }
            catch (Exception exp)
            {
                //TextBox3.Text = TextBox3.Text + exp.ToString() + "\n";

                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }



            return tempUser;
        }

        public List<List<Course>> getPreferences(string UserID)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            //create lists of elective courses by type
            List<Course> scienceCourses = new List<Course>();
            List<Course> generalCourses = new List<Course>();
            List<Course> technicalCourses = new List<Course>();
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[Preferences] WHERE UserID = @UserID;", Global.myConnection);
                SqlParameter myParam = new SqlParameter("@UserID", SqlDbType.VarChar);
                myParam.Value = UserID;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                String courseID;
                Course tempCourse;
                //get all courses for a user from the preference DB and sort them
                while (myReader.Read())
                {
                    //get course by id
                    courseID = myReader["CourseID"].ToString();
                    tempCourse = getCourse(courseID);
                    //place course in right course type list
                    if (tempCourse.isScienceCourse())
                    {
                        scienceCourses.Add(tempCourse);
                    }
                    else if (tempCourse.isGeneralCourse())
                    {
                        generalCourses.Add(tempCourse);
                    }
                    else if (tempCourse.isTechnicalCourse())
                    {
                        technicalCourses.Add(tempCourse);
                    }
                    else { }
                }
                myReader.Close();
            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }
            //place all electives list in a list
            List<List<Course>> preferences = new List<List<Course>>();
            preferences.Add(scienceCourses);
            preferences.Add(generalCourses);
            preferences.Add(technicalCourses);
            

            return preferences;
        }

        public Course getCourse(String CourseID)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            Course course = null;
            Section tempLec = null;
            try
            {
                SqlDataReader myReader = null;
                SqlDataReader lecReder = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[Course] WHERE CourseID = @CourseID;", Global.myConnection
                    );
                SqlParameter myParam = new SqlParameter("@CourseID", SqlDbType.VarChar);
                myParam.Value = CourseID;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    course = new Course();
                    course.setCode(myReader["Number"].ToString());
                    course.setCourseName(myReader["Title"].ToString());
                    course.setPriority(Convert.ToInt32(myReader["Priority"].ToString()));
                    //set course type
                   
                    if (myReader["isCore"].ToString().Equals("True"))
                        course.setAsCore();
                    else if (myReader["isScience"].ToString().Equals("True"))
                        course.setAsScience();
                    else if (myReader["isGeneral"].ToString().Equals("True"))
                        course.setAsGeneral();
                    else if (myReader["isTechnical"].ToString().Equals("True"))
                        course.setAsTechnical();
                }

                myReader.Close();
                SqlCommand getLec = new SqlCommand(
                    "SELECT * FROM [dbo].[Lecture] WHERE CourseID = @CourseID", Global.myConnection
                    );
                SqlParameter lecParam = new SqlParameter("@CourseID", SqlDbType.VarChar);
                lecParam.Value = CourseID;
                getLec.Parameters.Add(lecParam);
                lecReder = getLec.ExecuteReader();
                while(lecReder.Read())
                {
                    //populating lecture section object as there maybe more than one section of lectures
                    tempLec= new Section();
                    tempLec.setSemester((int)lecReder["Semester"]);
                    tempLec.setSectionName(lecReder["Section"].ToString());
                    tempLec.setDay(lecReder["onDay"].ToString());
                    tempLec.setTime(lecReder["StartTime"].ToString(), lecReder["EndTime"].ToString());
                    tempLec.setId(lecReder["LecID"].ToString());
                    course.addLecture(tempLec);
                }
                lecReder.Close();
                    //populating tut and lab for that particular lecture
                  
                    foreach(Section lecture in course.getLectures())
                    {
                        addTutorials(lecture);
                        addLabs(lecture);
                    }
                    
                }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }

            return course;
        }

        private void addTutorials(Section lecture)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            Section tut = null;
            SqlDataReader tutReader = null;
            try
            {
                SqlCommand getTut = new SqlCommand(
                    "SELECT * from [dbo].[Tutorial] WHERE LecID = @LecID", Global.myConnection
                    );
                SqlParameter tutParam = new SqlParameter("@LecID", SqlDbType.VarChar);
                tutParam.Value = lecture.getID();
                getTut.Parameters.Add(tutParam);
                tutReader = getTut.ExecuteReader();
                while (tutReader.Read())
                {
                    tut = new Section();
                    tut.setSemester((int)tutReader["Semester"]);
                    tut.setDay(tutReader["onDay"].ToString());
                    tut.setSectionName(tutReader["Section"].ToString());
                    tut.setTime(tutReader["StartTime"].ToString(), tutReader["EndTime"].ToString());
                    lecture.addTut(tut);
                }
                tutReader.Close();
            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }
           
        }

        private void addLabs(Section lecture)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            Section lab = null;
            SqlDataReader labReader = null;
            try{
            
            SqlCommand getLab = new SqlCommand(
                 "SELECT * from [dbo].[Lab] WHERE LecID = @LecID", Global.myConnection
                        );
                SqlParameter LabParam = new SqlParameter("@LecID", SqlDbType.VarChar);
                    LabParam.Value = lecture.getID();
                    getLab.Parameters.Add(LabParam);
                    labReader = getLab.ExecuteReader();
                    while (labReader.Read())
                    {
                        lab=new Section();
                        lab.setSemester((int)labReader["Semester"]);
                        lab.setDay(labReader["onDay"].ToString());
                        lab.setSectionName(labReader["Section"].ToString());
                        lab.setTime(labReader["StartTime"].ToString(), labReader["EndTime"].ToString());
                        lecture.addLab(lab);
                    }
                    labReader.Close();
                    
            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }

        }
    }
}