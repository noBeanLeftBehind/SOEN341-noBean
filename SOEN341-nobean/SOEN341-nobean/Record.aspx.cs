using SOEN341_nobean.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOEN341_nobean
{
	public partial class Record : System.Web.UI.Page
	{
		DBHandler DBHandler = new DBHandler();
		string netName = Global.MainUser.getUserID() + "";

		protected void Page_Load(object sender, EventArgs e)
		{
			//SqlConnection tempConnection = new SqlConnection();
			//tempConnection.ConnectionString = "Data Source=buax9l2psh.database.windows.net,1433;Initial Catalog=masterscheduler100_db;Persist Security Info=True;User ID=nobean;Password=Abc_12345";
			//Global.myConnection = tempConnection;

			if (Global.myConnection != null && Global.myConnection.State == ConnectionState.Open && Global.Admin != null && Global.MainUser != null)
			{
				if (!IsPostBack)
				{
					displayRecord();
					displayPassedCourses();
					displayRemainingCourses();
                    adminView();
				}
			}
			else if (Global.myConnection != null && Global.myConnection.State == ConnectionState.Open && Global.MainUser != null)
			{
				if (!IsPostBack)
				{
					displayRecord();
					displayPassedCourses();
					displayRemainingCourses();
				}
			}
			else
			{
				Response.Redirect("login.aspx");
			}

		}
		private void displayRecord()
		{
			CourseDirectory CourseDirectory = Global.CourseDirectory;

			TableCell cell = new TableCell();
			TableRow tRow = new TableRow();

			//Record Table
			cell.Text = "Name:   ";
			tRow.Cells.Add(cell);
			cell = new TableCell();
			cell.Text = Global.MainUser.getfirstName() + " " + Global.MainUser.getlastName();
			tRow.Cells.Add(cell);
			recordTable.Rows.Add(tRow);

			cell = new TableCell();
			tRow = new TableRow();
			cell.Text = "Student ID:   ";
			tRow.Cells.Add(cell);
			cell = new TableCell();
			cell.Text = Global.MainUser.getStudentID() + "";
			tRow.Cells.Add(cell);
			recordTable.Rows.Add(tRow);

			cell = new TableCell();
			tRow = new TableRow();
			cell.Text = "Netname:   ";
			tRow.Cells.Add(cell);
			cell = new TableCell();
			cell.Text = Global.MainUser.getnetName() + "";
			tRow.Cells.Add(cell);
			recordTable.Rows.Add(tRow);

			cell = new TableCell();
			tRow = new TableRow();
			cell.Text = "Email:   ";
			tRow.Cells.Add(cell);
			cell = new TableCell();
			cell.Text = Global.MainUser.getemail() + "";
			tRow.Cells.Add(cell);
			recordTable.Rows.Add(tRow);

			//courses taken

		}

		private void displayPassedCourses()
		{
			TableCell cell;
			TableRow tRow;

				try
				{
                    foreach (Course course in Global.Record.getCoursesTaken())
					{
						cell = new TableCell();
						tRow = new TableRow();
						cell.Text = course.getCourseName() + "    ";
						tRow.Cells.Add(cell);
						pCoursesTable.Rows.Add(tRow);
					}
				}
			catch(Exception e)
				{
				    cell = new TableCell();
				    tRow = new TableRow();
				    cell.Text = "No passed courses.";
				    tRow.Cells.Add(cell);
				    pCoursesTable.Rows.Add(tRow);
			}

		}

		private void displayRemainingCourses()
		{
			TableCell cell;
			TableRow tRow;

			foreach (Course course in Global.CourseDirectory.getAllCourses())
			{
                try
                {
                    foreach (Course pcourse in Global.Record.getCoursesTaken())
                    {
                        if (course.getCourseID() != pcourse.getCourseID())
                        {
                            cell = new TableCell();
                            tRow = new TableRow();
                            cell.Text = course.getCourseName() + "    ";
                            tRow.Cells.Add(cell);
                            rCoursesTable.Rows.Add(tRow);
                        }
                    }
                }
                catch(Exception e)
                {
                    cell = new TableCell();
                    tRow = new TableRow();
                    cell.Text = course.getCourseName() + "    ";
                    tRow.Cells.Add(cell);
                    rCoursesTable.Rows.Add(tRow);
                }
			}
		}


        private void adminView()
        {
            studentCourse.Visible = true;
            submitCourseButton.Visible = true;

        }

		private void editCoursesTaken()
		{

           Global.Record.addCourseTaken(DBHandler.getCourseByCourseName(studentCourse.Text));

		}
	}
}