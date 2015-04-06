using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SOEN341_nobean.Class;
using System.Data;

namespace SOEN341_nobean
{
    public partial class Preferences : System.Web.UI.Page
    {
        DBHandler DBHandler = new DBHandler();

        //to change------------------------------------------------
        //public static Boolean ReloadChanges = true;//put in global.when logout, resets bool to true.
        //static Boolean FirstLoggin = true;//run displayCourses() when first login
        //test netname
        String netName = "4";//get from global 
        //---------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection tempConnection = new SqlConnection();
            //tempConnection.ConnectionString = "Data Source=buax9l2psh.database.windows.net,1433;Initial Catalog=masterscheduler100_db;Persist Security Info=True;User ID=nobean;Password=Abc_12345";
            //Global.myConnection = tempConnection;

            if (Global.myConnection != null && Global.myConnection.State == ConnectionState.Open && Global.MainUser != null)
            {
                //testLabel.Text = "ReloadChange: "+ReloadChanges;
                    displayCourses();

            }
            else
            {
                Response.Redirect("login.aspx");
            }
                
        }
        public void editPreferences(object sender, EventArgs e)
        {
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

            //CheckedListBox.CheckedItemCollection
            //get all checked items, for each item, check item.Value (courseId in DB). 
            //if item.Selected = true, add to DB
            ChkLstGeneral.Enabled = false;
            ChkLstTechnical.Enabled = false;
            ChkLstScience.Enabled = false;
            editPreferencesBtnTop.Visible = true;
            editPreferencesBtnBottom.Visible = true;
            savePreferencesBtnTop.Visible = false;
            savePreferencesBtnBottom.Visible = false;
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
                String chkText = course.getSubject() + " " + course.getCode() + " - " + course.getCourseName();
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
                String chkText = course.getSubject() + " " + course.getCode() + " - "+course.getCourseName();
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
                String chkText = course.getSubject() + " " + course.getCode() + " - " + course.getCourseName();
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
        /*private void displayAllPreferences()
        {
            
            //--------------------------------------------
            Once list of all preferences is made
             * Display list of all preferences
             * then compare each item with user preferences
             * if match, then selected=true
             
            //get list of all preferences of user
            List<List<SOEN341_nobean.Class.Course>> preferencesList = dbhandler.getPreferences(netName);
            //populate tables with course name+code and checkbox
            
            //**** do same as technical course 
            foreach (SOEN341_nobean.Class.Course course in preferencesList[0])
            {
                TableRow row = new TableRow();
                TableCell cellCourseName = new TableCell();
                TableCell cellCheckBox = new TableCell();
                CheckBox checkbox = new CheckBox();
                checkbox.ID = "Checkbox" + course.getSubject() + course.getCode();

                cellCourseName.Text = course.getSubject() + " " + course.getCode();
                if (true)//change to check if course is in student preferences
                {
                    checkbox.Checked = true;
                    //checkbox.Enabled = false;
                }
                else
                {
                    checkbox.Checked = false;
                    //checkbox.Enabled = false;
                }
                cellCheckBox.Controls.Add(checkbox);
                row.Cells.Add(cellCourseName);
                row.Cells.Add(cellCheckBox);
                TableScience.Rows.Add(row);
            }
            //**** do same as technical course 
            foreach (SOEN341_nobean.Class.Course course in preferencesList[1])
            {
                TableRow row = new TableRow();
                TableCell cellCourseName = new TableCell();
                TableCell cellCheckBox = new TableCell();
                CheckBox checkbox = new CheckBox();
                checkbox.ID = "Checkbox" + course.getSubject() + course.getCode();

                cellCourseName.Text = course.getSubject() + " " + course.getCode();
                if (true)//change to check if course is in student preferences
                {
                    checkbox.Checked = true;
                    //checkbox.Enabled = false;
                }
                else
                {
                    checkbox.Checked = false;
                    //checkbox.Enabled = false;
                }
                cellCheckBox.Controls.Add(checkbox);
                row.Cells.Add(cellCourseName);
                row.Cells.Add(cellCheckBox);
                TableGeneral.Rows.Add(row);
            }
            foreach (SOEN341_nobean.Class.Course course in preferencesList[2])
            {
                String chkText = course.getSubject() + " " + course.getCode();
                ChkLstTechnical.Items.Add(chkText);
                if (true)//change to check if course is in student preferences
                {
                    ChkLstTechnical.Items.FindByValue(chkText).Selected = true;
                    //ChkLstTechnical.SetItemCheckState(0, true); //using System.Windows.Forms(.dll)
                    
                }
                else
                {
                }
            }
            ChkLstTechnical.Enabled=false;
            ReloadChanges = false;
        }*/
    }
}