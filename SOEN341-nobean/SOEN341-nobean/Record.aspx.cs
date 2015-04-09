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
		}

		private void displayPassedCourses()
		{
			TableCell cell;
			TableRow tRow;

            if (Global.Admin != null)
            {
                TableHeaderCell hCell = new TableHeaderCell();
                TableHeaderRow hRow = new TableHeaderRow();
                hCell.Text = "Class";
                hRow.Cells.Add(hCell);
                hCell = new TableHeaderCell();
                hCell.Text = "Course ID";
                hRow.Cells.Add(hCell);
                pCoursesTable.Rows.Add(hRow);
            }

				try
				{
                    foreach (int CourseID in DBHandler.getRecord(netName))
					{
						cell = new TableCell();
						tRow = new TableRow();
                        Course course = DBHandler.getCourse(CourseID.ToString());
						cell.Text = course.getCourseName() + "";
						tRow.Cells.Add(cell);
                        if (Global.Admin != null)
                        {
                            cell = new TableCell();
                            cell.Text = course.getCourseID() + "    ";
                            tRow.Cells.Add(cell);
                        }
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
            bool passed;
            Course course;
            if (Global.Admin != null)
            {
                TableHeaderCell hCell = new TableHeaderCell();
                TableHeaderRow hRow = new TableHeaderRow();
                hCell.Text = "Class";
                hRow.Cells.Add(hCell);
                hCell = new TableHeaderCell();
                hCell.Text = "Course ID";
                hRow.Cells.Add(hCell);
                rCoursesTable.Rows.Add(hRow);
            }

			foreach (int courseID1 in DBHandler.getCoreClasses())
			{
                passed = false;       
                try
                {
                    foreach (int courseID2 in DBHandler.getRecord(netName))
                    {
                        if (courseID1 == courseID2)
                        {
                            passed = true;
                        }
                    }
                    if (!passed)
                    {
                        course = DBHandler.getCourse(courseID1.ToString());
                        cell = new TableCell();
                        tRow = new TableRow();
                        cell.Text = course.getCourseName() + "    " ;
                        tRow.Cells.Add(cell);
                        if (Global.Admin != null)
                        {
                            cell = new TableCell();
                            cell.Text = course.getCourseID() + "    ";
                            tRow.Cells.Add(cell);
                        }
                        rCoursesTable.Rows.Add(tRow);
                    }
                }
                catch(Exception e)
                {
                    course = DBHandler.getCourse(courseID1.ToString());
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

        public void editCoursesTaken(object sender, EventArgs e)
		{
            DBHandler.insertUserRecord(netName, studentCourse.Text);
            Response.Redirect(Request.RawUrl);
		}
	}
}