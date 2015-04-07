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

        private static User student;
        
        private DBHandler userHandler = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
                Global.Admin = Global.MainUser;
                if (Global.myConnection == null || Global.myConnection.State == System.Data.ConnectionState.Closed || Global.MainUser == null)
                    Response.Redirect("login.aspx");

                if (Global.Admin.getisAdmin() == false)
                    Response.Redirect("home.aspx");

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
                        if (tempStudent.getisAdmin())
                        {
                            error_IDStudent.Style["color"] = "red";
                            error_IDStudent.Text = String.Format("You have not the rights to log in as an administrator", studentIDTextBox.Text);
                            connectStudent.Visible = false;
                            connectStudent.Visible = false;
                        }
                        else if (tempStudent.getfirstName() != null && tempStudent.getlastName() != null)
                        {
                            student = tempStudent;
                            hiddenStudentID.Value = studentID;
                            error_IDStudent.Text = "Student found: ";
                            LabelStudentFound.Text = String.Format("<p>\r\n {0}, {1} </p>", student.getlastName(), student.getfirstName());
                            studentIDTextBox.Text = "";
                            connectStudent.Visible = true;
                            connectStudent.Visible = true;
                        }
                        else
                        {
                            error_IDStudent.Style["color"] = "red";
                            error_IDStudent.Text = String.Format("Student with ID {0} was not found", studentIDTextBox.Text);
                            connectStudent.Visible = false;
                            connectStudent.Visible = false;
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
            Global.MainUser = student;
            Response.Redirect("home.aspx");
        }

    
public  SOEN341_nobean.User _student { get; set; }}
}