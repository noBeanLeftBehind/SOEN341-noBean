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
        private User student;
        private DBHandler userHandler = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
                if (Global.myConnection == null || Global.myConnection.State == System.Data.ConnectionState.Closed || Global.MainUser == null)
                    Response.Redirect("login.aspx");

                if (Global.MainUser.getisAdmin() == false)
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
                        student = userHandler.getUserByID(studentID);
                        if (student.getfirstName() != null && student.getlastName() != null)
                        {
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
            }

        }

        protected void connectStudent_Click1(object sender, EventArgs e)
        {
            Global.MainUser = userHandler.getUserByID(hiddenStudentID.Value);
            Response.Redirect("home.aspx");
        }

    }
}