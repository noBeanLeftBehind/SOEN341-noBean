using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SOEN341_nobean.Class;
using System.Data;
using System.Data.SqlClient;

namespace SOEN341_nobean
{
    public partial class Preferences : System.Web.UI.Page
    {
        DBHandler DBHandler = new DBHandler();
        string netName = Global.MainUser.getUserID() + "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection tempConnection = new SqlConnection();
            //tempConnection.ConnectionString = "Data Source=buax9l2psh.database.windows.net,1433;Initial Catalog=masterscheduler100_db;Persist Security Info=True;User ID=nobean;Password=Abc_12345";
            //Global.myConnection = tempConnection;

            if (Global.myConnection != null && Global.myConnection.State == ConnectionState.Open && Global.MainUser != null)
            {
                if (!IsPostBack)
                {
                    displayCourses();
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
                
        }
        public void editPreferences(object sender, EventArgs e)
        {
            //switch buttons and allow checkboxes to be edited
            ChkLstGeneral.Enabled = true;
            ChkLstTechnical.Enabled = true;
            ChkLstScience.Enabled = true;
            editPreferencesBtnTop.Visible = false;
            editPreferencesBtnBottom.Visible = false;
            savePreferencesBtnTop.Visible = true;
            savePreferencesBtnBottom.Visible = true;
        }
        public void savePreferences(object sender, EventArgs e)
        {
            //switch buttons and disable checkboxes
            ChkLstGeneral.Enabled = false;
            ChkLstTechnical.Enabled = false;
            ChkLstScience.Enabled = false;
            editPreferencesBtnTop.Visible = true;
            editPreferencesBtnBottom.Visible = true;
            savePreferencesBtnTop.Visible = false;
            savePreferencesBtnBottom.Visible = false;

            //Get all selected courses by values(Corse ids) and add them to a list
            List<string> selectedValuesGeneral = ChkLstGeneral.Items.Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(li => li.Value)
                .ToList();
            List<string> selectedValuesTechnical = ChkLstTechnical.Items.Cast<ListItem>()
               .Where(li => li.Selected)
               .Select(li => li.Value)
               .ToList();
            List<string> selectedValuesScience = ChkLstScience.Items.Cast<ListItem>()
                           .Where(li => li.Selected)
                           .Select(li => li.Value)
                           .ToList();

            List<string> preferenceCourseID = new List<string>();
            //add all preferences Course Id to one list
            preferenceCourseID.AddRange(selectedValuesGeneral);
            preferenceCourseID.AddRange(selectedValuesTechnical);
            preferenceCourseID.AddRange(selectedValuesScience);
            
            //delete all user preferences
            DBHandler.removeUserPreferences(netName);
            //add new preferences to DB
            foreach (string value in preferenceCourseID)
            {
                DBHandler.insertUserPreferences(netName, value);
            }
            //reload the page
            savePreferencesToGlobal(preferenceCourseID);
            Response.Redirect("Preferences.aspx");

        }
        private void savePreferencesToGlobal(List<string> preferenceCourseID)
        {
            List<Course> preferenceCourse = new List<Course>();
            foreach (string courseID in preferenceCourseID)
            {
                preferenceCourse.Add(DBHandler.getCourse(courseID));
            }
            Global.ListPreferences = preferenceCourse;
        }
        private void displayCourses()
        {
            ChkLstGeneral.Items.Clear();
            ChkLstTechnical.Items.Clear();
            ChkLstScience.Items.Clear();
            List<int> preferenceCourseID = DBHandler.getPreferences(netName);
            CourseDirectory CourseDirectory = Global.CourseDirectory;

            List<Course> electiveGeneral = CourseDirectory.getElectiveGeneral();
            List<Course> electiveTechnical = CourseDirectory.getElectiveTechnical();
            List<Course> electiveScience = CourseDirectory.getElectiveScience();
         
            //generates checkboxlist for general
            foreach (Course course in electiveGeneral)
            {
                string chkText = course.getSubject() + " " + course.getCode() + " - " + course.getCourseName();
                int courseID = course.getCourseID();
                ListItem item = new ListItem(chkText);
                //set value to courseID for save function
                item.Value = courseID+"";

                if (preferenceCourseID.IndexOf(courseID) != -1)//if courseId is in preferenceCourseID
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
                ChkLstGeneral.Items.Add(item);
            }
            ChkLstGeneral.Enabled = false;
            foreach (Course course in electiveTechnical)
            {
                string chkText = course.getSubject() + " " + course.getCode() + " - "+course.getCourseName();
                int courseID = course.getCourseID();
                ListItem item = new ListItem(chkText);
                //set value to courseID for save function
                item.Value = courseID + "";

                if (preferenceCourseID.IndexOf(courseID) != -1)//if courseId is in preferenceCourseID
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
                ChkLstTechnical.Items.Add(item);
            }
            ChkLstTechnical.Enabled = false;
            foreach (Course course in electiveScience)
            {
                string chkText = course.getSubject() + " " + course.getCode() + " - " + course.getCourseName();
                int courseID = course.getCourseID();
                ListItem item = new ListItem(chkText);
                //set value to courseID for save function
                item.Value = courseID + "";

                if (preferenceCourseID.IndexOf(courseID) != -1)//if courseId is in preferenceCourseID
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
                ChkLstScience.Items.Add(item);
            }
            ChkLstScience.Enabled = false;
        }
    }
}