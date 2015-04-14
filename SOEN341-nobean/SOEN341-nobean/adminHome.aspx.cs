using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using SOEN341_nobean.Class;
using System.Data.SqlClient;

namespace SOEN341_nobean
{
    public partial class adminHome : System.Web.UI.Page
    {
        private DBHandler userHandler = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Global.myConnection == null || Global.myConnection.State == System.Data.ConnectionState.Closed || Global.MainUser == null)
                Response.Redirect("login.aspx");

            if (Global.MainUser.getisAdmin() == false)
                Response.Redirect("home.aspx");
            Global.Admin = Global.MainUser;

            SubmitIDButton.Click += new EventHandler(this.SubmitIDButton_Click);
            connectStudent.Click += new EventHandler(this.connectStudent_Click1);
        }

        private void SubmitIDButton_Click(object sender, EventArgs e)
        {
            //matching 8-digits only for student ID
            String studentID = studentIDTextBox.Text;
            Regex ID_regex = new Regex(@"^\d{8}$");
            Match match = ID_regex.Match(studentID);
            error_IDStudent.Style["color"] = "red";
            if (match.Success)
            {
                error_IDStudent.Style["color"] = "black";
                error_IDStudent.Text = String.Format("Searching for {0}...", studentIDTextBox.Text);

                try
                {
                    User tempStudent = userHandler.getUserByID(studentID);
                   if (tempStudent != null) { 
                    if (tempStudent.getisAdmin())
                    {
                        error_IDStudent.Style["color"] = "red";
                        error_IDStudent.Text = String.Format("You have not the rights to log in as an administrator", studentIDTextBox.Text);
                        connectStudent.Visible = false;
                        LabelStudentFound.Text = "";
                    }
                    else if (tempStudent.getfirstName() != null && tempStudent.getlastName() != null)
                    {
                        ViewState["StudentViewState"] = tempStudent;
                        hiddenStudentID.Value = studentID;
                        error_IDStudent.Style["color"] = "black";
                        error_IDStudent.Text = "Student found: ";
                        LabelStudentFound.Text = String.Format("<p>\r\n {0}, {1} </p>", tempStudent.getlastName(), tempStudent.getfirstName());
                        studentIDTextBox.Text = "";
                        connectStudent.Visible = true;
                    }
                   }
                   else
                    {
                        error_IDStudent.Style["color"] = "red";
                        error_IDStudent.Text = String.Format("Student with ID {0} was not found", studentIDTextBox.Text);
                        connectStudent.Visible = false;
                        LabelStudentFound.Text = "";
                    }
                       
                }
                catch (Exception ex)
                {
                    Response.Write("Error:" + ex.ToString());

                }

            }
            else
            {
                error_IDStudent.Text = "ERROR: Enter a 8 digit Student ID";
                LabelStudentFound.Text = "";
                connectStudent.Visible = false;
                connectStudent.Visible = false;
            }

        }

        protected void connectStudent_Click1(object sender, EventArgs e)
        {
            Global.MainUser = (User)ViewState["StudentViewState"];
            CourseDirectory cd = new CourseDirectory();
            userHandler.addAllCoursestoDirectory(cd);
            Global.CourseDirectory = cd;
           // savePreferencesToGlobal(Global.MainUser.getUserID() + "");
            savePassedCoursesToGlobal(Global.MainUser.getUserID() + "");
            getRemainingCourses();
            Response.Redirect("home.aspx");
        }

        public void savePassedCoursesToGlobal(string userID)
        {
            DBHandler DBHandler = new DBHandler();
            List<int> CourseID = DBHandler.getRecord(userID);
            List<Course> TakenCourse = new List<Course>();
            int[] ids = CourseID.ToArray();
            if (CourseID.Count != 0)
            {
                //add in order of courseID
                for (int i = 0; i < ids.Length - 1; i++)
                {
                    for (int j = i + 1; j < ids.Length; j++)
                    {
                        if (ids[i] > ids[j])
                        {
                            int temp = ids[i];
                            ids[i] = ids[j];
                            ids[j] = temp;
                        }
                    }
                }
                foreach (int id in ids)
                {
                    TakenCourse.Add(DBHandler.getCourse(id + ""));
                }
            }
            Global.ListCourseTaken = TakenCourse;
        }

        public void getRemainingCourses()
        {
            List<Course> passedCourse = Global.ListCourseTaken;
            List<Course> preferenceList = Global.ListPreferences;
            List<Course> remainingCourse = new List<Course>();
            CourseDirectory cd = Global.CourseDirectory;
            List<Course> coreCourse = cd.getAllCourses();

            if (passedCourse.Count != 0)
            {
                foreach (Course cours in coreCourse)
                {
                    bool passed = false;
                    foreach (Course cours2 in passedCourse)
                    {
                        if (cours.getCourseID() == cours2.getCourseID())
                        {
                            passed = true;
                        }
                    }
                    if (!passed)
                    {
                        remainingCourse.Add(cours);
                    }
                }
            }
            else
                remainingCourse = coreCourse;

            Global.ListCourseRemaining = remainingCourse;
        }
    }
}