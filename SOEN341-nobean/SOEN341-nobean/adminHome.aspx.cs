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
        User student;
        DBHandler userHandler = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            SubmitIDButton.Click += new EventHandler(this.SubmitIDButton_Click);
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

                SqlConnection tempConnection = new SqlConnection();
                try
                {
                    //connecting to the db.
                    tempConnection.ConnectionString = "Data Source=buax9l2psh.database.windows.net,1433;Initial Catalog=masterscheduler100_db;Persist Security Info=True;User ID=nobean;Password=Abc_12345";
                    Global.myConnection = tempConnection;
                    if (Global.myConnection != null && Global.myConnection.State == System.Data.ConnectionState.Closed)
                        Global.myConnection.Open();


                    student = userHandler.getUserByID(studentID);
                    if (student.getfirstName()!=null && student.getlastName()!=null)
                    {
                        error_IDStudent.Text = "Student found: ";
                        LabelStudentFound.Text = String.Format("<p>\r\n {0}, {1} </p><p>\r\n <a href='#'>Connect as {2}</a></p>", student.getlastName(), student.getfirstName(), student.getStudentID());
                        studentIDTextBox.Text = "";
                    }
                    else
                    {
                        error_IDStudent.Style["color"] = "red";
                        error_IDStudent.Text = String.Format("Student with ID {0} was not found", studentIDTextBox.Text);
                    }
                    Global.myConnection.Close();
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
    }
}