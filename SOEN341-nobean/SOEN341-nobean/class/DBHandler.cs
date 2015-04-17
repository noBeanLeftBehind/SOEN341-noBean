using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Diagnostics;

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
        public List<int> getPreferences(string UserID)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            List<int> courseIDList = new List<int>();
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[Preferences] WHERE UserID = @UserID;", Global.myConnection);
                SqlParameter myParam = new SqlParameter("@UserID", SqlDbType.VarChar);
                myParam.Value = UserID;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //get course by id
                    courseIDList.Add(Convert.ToInt32(myReader["CourseID"].ToString()));
                }
                myReader.Close(); 
            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }
            return courseIDList;
        }
        public void removeUserPreferences(string netName)
        {
            SqlCommand myCommand = new SqlCommand(
                    "DELETE FROM [dbo].[Preferences] WHERE UserID = @netName;", 
                    Global.myConnection);
            myCommand.Parameters.AddWithValue("@netName", netName);
            myCommand.ExecuteNonQuery();
        }
        public void insertUserPreferences(string netNameString, string courseIDString)
        {
            int netName = Convert.ToInt32(netNameString);
            int courseID = Convert.ToInt32(courseIDString);
            string insertQuery = "insert into [dbo].[Preferences] (UserID,CourseID,Answer) values (@UserID,@CourseID,@Answer)";

            SqlCommand com = new SqlCommand(insertQuery, Global.myConnection);

            com.Parameters.AddWithValue("@UserID", netName);
            com.Parameters.AddWithValue("@CourseID", courseID);
            com.Parameters.AddWithValue("@Answer", true);

            com.ExecuteNonQuery();
        }
        public void addAllCoursestoDirectory(CourseDirectory cd)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            List<String> courseIds = new List<string>(0);
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[Course];", Global.myConnection
                    );
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    courseIds.Add(myReader["CourseID"].ToString());
                }
                myReader.Close();
                foreach(String id in courseIds)
                {
                    Course temp = getCourse(id);
                    if (temp.isGeneralCourse())
                        cd.addelectiveGeneral(temp);
                    else if (temp.isScienceCourse())
                        cd.addelectiveScience(temp);
                    else if (temp.isTechnicalCourse())
                        cd.addelectiveTechnical(temp);
                    else
                        cd.addallCourses(temp);
                }
            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }
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
                    course.setCourseID(Convert.ToInt32(myReader["CourseID"].ToString()));
                    course.setCode(myReader["Number"].ToString());
                    course.setCourseName(myReader["Title"].ToString());
                    course.setSubject(myReader["Name"].ToString());
                    course.setPriority(Convert.ToInt32(myReader["Priority"].ToString()));
                    course.setDescription(myReader["CourseDescription"].ToString());
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
                    tempLec.setCourseID(CourseID);
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
                    tut.setId(tutReader["TutID"].ToString());
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
                        lab.setId(labReader["LabID"].ToString());
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
        public List<Course> getAllCourse()
        {//could just iterate through getCourses 
            var page = HttpContext.Current.CurrentHandler as Page;
            List<Course> ret = new List<Course>();
            //what we would do if we wanted to extend it but since this is a one time thing
            /*int numberOfCourses = 0;
            SqlDataReader myReader;
            try
            {
                SqlCommand getCount = new SqlCommand(
                 "SELECT COUNT(COURSEID) from dbo.Course", Global.myConnection
                        );
                myReader = getCount.ExecuteReader();
                numberOfCourses = (int)myReader;
                for (int i = 0; i < numberOfCourses; i++)
                {
                    ret.Add(getCourse(i.ToString()));
                }

            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }*/
            //since we know how many courses are in the db and the course id increases by one
            for (int i = 0; i < 15; i++)
            {
                ret.Add(getCourse(i.ToString()));
            }

            return ret;
        }

        //alright an attempt at getting
        //i have no clue what im doing

        /*public void GetUserSchedules(string ID)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            Schedule userSchedule = new Schedule();
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[SemesterSchedule] WHERE UserID = @UserID;", Global.myConnection
                    );
                SqlParameter myParam = new SqlParameter("@UserID", SqlDbType.VarChar);
                myParam.Value = ID;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    semester tempSemester = new semester();
                    tempSemester.setYear((int)myReader["year"]);
                    tempSemester.setSection((int)myReader["section"]);
                    tempSemester.setCourses(GetCourseSchedule(myReader["ScheduleID"].ToString()));
                }
            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }
        }*/
        public List<semester> getCourseSchedule(String UserID)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            List<semester> schedule = new List<semester>();
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[CourseSchedule] WHERE UserID = @UserID;", Global.myConnection
                    );
                SqlParameter myParam = new SqlParameter("@UserID", SqlDbType.VarChar);
                myParam.Value = UserID;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    semester tempSemester = new semester();
                    tempSemester.setSection(Convert.ToInt32(myReader["Section"].ToString()));
                    tempSemester.setYear(Convert.ToInt32(myReader["year"].ToString()));
                    foreach(semester sem in schedule)
                    {
                        if (sem.getSection() == tempSemester.getSection() && sem.getYear() == tempSemester.getYear())
                            tempSemester = sem;
                    }
                    Course tempCourse = Global.CourseDirectory.getCourse(myReader["CourseID"].ToString());
                    if (!string.IsNullOrEmpty(myReader["LecID"].ToString()) && !myReader["LecID"].ToString().Equals("0"))
                    {
                        tempSemester.addOnlineCourse(tempCourse);
                    }
                    else
                    {
                        Section tempLecture = tempCourse.getLecture(myReader["LecID"].ToString());
                        tempSemester.addLecture(tempLecture);
                        tempLecture.setCourseSig(tempCourse.getSubject() + " " + tempCourse.getCode());

                        if (!string.IsNullOrEmpty(myReader["TutID"].ToString()) && !myReader["TutID"].ToString().Equals("0"))
                        {
                            Section tempTut = tempLecture.getTut(myReader["TutID"].ToString());
                            tempSemester.addTutorials(tempTut);
                            tempTut.setCourseSig(tempCourse.getSubject() + " " + tempCourse.getCode());
                        }
                        if (!string.IsNullOrEmpty(myReader["LabID"].ToString()) && !myReader["LabID"].ToString().Equals("0"))
                        {
                            Section tempLab = tempLecture.getLab(myReader["LabID"].ToString());
                            tempLab.setCourseSig(tempCourse.getSubject() + " " + tempCourse.getCode());
                            tempSemester.addLabs(tempLab);
                        }
                    }
                    if(!schedule.Contains(tempSemester))
                        schedule.Add(tempSemester);
                }
                myReader.Close();

            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }
            return schedule;
        }
        public void insertCourseSchedule(Schedule sched)
        {
            List<semester> allSems = sched.getSemester();
            foreach(semester sem in allSems)
            {
                foreach(Section lecture in sem.getLectures())
                {
                    String TutID = "";
                    String LabID = "";

                    foreach(Section tut in sem.getTuts())
                    {
                        if (lecture.getTutorials().Contains(tut))
                            TutID = tut.getID();
                    }

                    foreach (Section lab in sem.getLabs())
                    {
                        if (lecture.getLabs().Contains(lab))
                            LabID = lab.getID();
                    }

                    string insertQuery = "insert into [dbo].[CourseSchedule] (UserID, Section, year, CourseID, LecID, TutID, LabID) values (@UserID, @Section, @year, @CourseID, @LecID, @TutID, @LabID)";

                    SqlCommand com = new SqlCommand(insertQuery, Global.myConnection);

                    com.Parameters.AddWithValue("@UserID", Global.MainUser.getUserID());
                    com.Parameters.AddWithValue("@Section", sem.getSection());
                    com.Parameters.AddWithValue("@year", sem.getYear());
                    com.Parameters.AddWithValue("@CourseID", lecture.getCourseID());
                    com.Parameters.AddWithValue("@LecID", lecture.getID());
                    com.Parameters.AddWithValue("@TutID", TutID);
                    com.Parameters.AddWithValue("@LabID", LabID);


                    com.ExecuteNonQuery();
                }
                foreach(Course crs in sem.getOnlineCourses())
                {
                    String TutID = "";
                    String LabID = "";
                    String LecID = "";

                    String insertQuery = "insert into [dbo].[CourseSchedule] (UserID, Section, year, CourseID, LecID, TutID, LabID) values (@UserID, @Section, @year, @CourseID, @LecID, @TutID, @LabID)";

                    SqlCommand com = new SqlCommand(insertQuery, Global.myConnection);

                    com.Parameters.AddWithValue("@UserID", Global.MainUser.getUserID());
                    com.Parameters.AddWithValue("@Section", sem.getSection());
                    com.Parameters.AddWithValue("@year", sem.getYear());
                    com.Parameters.AddWithValue("@CourseID", crs.getCourseID());
                    com.Parameters.AddWithValue("@LecID", LecID);
                    com.Parameters.AddWithValue("@TutID", TutID);
                    com.Parameters.AddWithValue("@LabID", LabID);


                    com.ExecuteNonQuery();
                }
            }
        }
        public void insertUserRecord(string netNameString, string courseIDString)
        {
            int netName = Convert.ToInt32(netNameString);
            int courseID = Convert.ToInt32(courseIDString);

            string insertQuery = "IF NOT EXISTS (SELECT * FROM [dbo].[Record] WHERE UserID = @UserID AND CourseID = @CourseID) INSERT INTO [dbo].[Record] (UserID, CourseID) values(@UserID,@CourseID)";


            SqlCommand com = new SqlCommand(insertQuery, Global.myConnection);

            com.Parameters.AddWithValue("@UserID", netName);
            com.Parameters.AddWithValue("@CourseID", courseID);

            if (com.ExecuteNonQuery() != 1)
                throw new Exception();
        }

        public void removeUserRecord(string netNameString, string courseIDString)
        {
            int netName = Convert.ToInt32(netNameString);
            int courseID = Convert.ToInt32(courseIDString);

            string insertQuery = "IF EXISTS (SELECT * FROM [dbo].[Record] WHERE UserID = @UserID AND CourseID = @CourseID) DELETE FROM [dbo].[Record] WHERE UserID = @UserID AND CourseID = @CourseID";


            SqlCommand com = new SqlCommand(insertQuery, Global.myConnection);

            com.Parameters.AddWithValue("@UserID", netName);
            com.Parameters.AddWithValue("@CourseID", courseID);

            if (com.ExecuteNonQuery() < 1)
                throw new Exception();
        }

        public List<int> getRecord(string UserID)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            List<int> courseIDList = new List<int>();
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[Record] WHERE UserID = @UserID;", Global.myConnection);
                SqlParameter myParam = new SqlParameter("@UserID", SqlDbType.VarChar);
                myParam.Value = UserID;
                myCommand.Parameters.Add(myParam);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //get course by id
                    courseIDList.Add(Convert.ToInt32(myReader["CourseID"].ToString()));
                }
                myReader.Close();
            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }
            return courseIDList;
        }

        public List<int> getCoreClasses()
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            List<int> courseId = new List<int>(0);
            Course course = null;
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM [dbo].[Course] WHERE isCore = 1;", Global.myConnection
                    );
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    course = new Course();
                    course.setCourseID(Convert.ToInt32(myReader["CourseID"].ToString()));
                    course.setCode(myReader["Number"].ToString());
                    course.setCourseName(myReader["Title"].ToString());
                    course.setSubject(myReader["Name"].ToString());
                    course.setPriority(Convert.ToInt32(myReader["Priority"].ToString()));
                    course.setAsCore();
                    courseId.Add(course.getCourseID());
                }

                myReader.Close();
            }
            catch (Exception exp)
            {
                page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.ToString() + "');", true);
            }

            return courseId;
        }
     }
}