using SOEN341_nobean.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace SOEN341_nobean
{
	public partial class Record : System.Web.UI.Page
	{
		DBHandler DBHandler = new DBHandler();
		string netName = Global.MainUser.getUserID() + "";
        static String err_msg = "";

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

				if(Global.ListCourseTaken.Count!=0)
				{
                    foreach (Course course in Global.ListCourseTaken)
					{
						cell = new TableCell();
						tRow = new TableRow();
                       // Course course = DBHandler.getCourse(CourseID.ToString());
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
                else
				{
				    cell = new TableCell();
				    tRow = new TableRow();
				    cell.Text = "No passed courses.";
				    tRow.Cells.Add(cell);
                    if (Global.Admin != null)
                    {
                        cell = new TableCell();
                        tRow.Cells.Add(cell);
                    }
				    pCoursesTable.Rows.Add(tRow);
			}

		}

		private void displayRemainingCourses()
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
                rCoursesTable.Rows.Add(hRow);
            }

			foreach (Course course in Global.ListCourseRemaining)
			{

                //course = DBHandler.getCourse(courseID1.ToString());
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


        private void adminView()
        {
            studentCourse.Visible = true;
            submitCourseButton.Visible = true;
            adminInstruction.Visible = true;
            if (!err_msg.Equals(""))
            {
                displayError(err_msg);
                err_msg = "";
            }
        }

        public void editCoursesTaken(object sender, EventArgs e)
		{
            String sCourse = studentCourse.Text;
            Regex sCourse_regex = new Regex(@"\d+$");
            Match match = sCourse_regex.Match(sCourse);
            if (!match.Success)
            {
                err_msg = "Invalid course id.";
                Response.Redirect(Request.RawUrl);
            }

            Course course = DBHandler.getCourse(studentCourse.Text);
            try
            {
                if (adminInstruction.SelectedValue == "add")
                    DBHandler.insertUserRecord(netName, course.getCourseID().ToString());
                else
                    DBHandler.removeUserRecord(netName, course.getCourseID().ToString());
            }
            catch (Exception)
            {
                if (adminInstruction.SelectedValue == "add")
                {
                    err_msg = "Error adding course to courses passed.";
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    err_msg = "Error removing course from courses passed.";
                    Response.Redirect(Request.RawUrl);
                }
            }

            if (adminInstruction.SelectedValue == "add")
            {
                addCourseTaken(course);
                removeCourseRemaining(course);
            }
            else
            {
                removeCourseTaken(course);
                addCourseRemaining(course);
            }

            Response.Redirect(Request.RawUrl);
		}

        public void addCourseTaken(Course course){
            if (Global.ListCourseTaken.Count == 0)
                Global.ListCourseTaken.Add(course);
            else
            {
                int index = 0;
                foreach (Course pCourse in Global.ListCourseTaken)
                {
                    if (pCourse.getCourseID() < course.getCourseID())
                        index++;
                    else
                        break;

                }
                Global.ListCourseTaken.Insert(index, course);
            }
        }

        public void removeCourseTaken(Course course)
        {
            if (Global.ListCourseTaken.Count == 0)
            {
                err_msg = "Cannot delete course: Passed courses is empty.";
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                int index = 0;
                foreach (Course pCourse in Global.ListCourseTaken)
                {
                    if (pCourse.getCourseID() == course.getCourseID())
                        break;
                    index++;
                }
                
                //course was not in courses passed, throw error display error dont remove
                if (index == Global.ListCourseTaken.Count)
                {
                    err_msg = "Cannot delete course: Course not present in passed courses.";
                    Response.Redirect(Request.RawUrl);
                }

                Global.ListCourseTaken.RemoveAt(index);
            }
        }

        public void addCourseRemaining(Course course)
        {
            if (Global.ListCourseRemaining.Count == 0)
                Global.ListCourseRemaining.Add(course);
            else
            {
                int index = 0;
                foreach (Course rCourse in Global.ListCourseRemaining)
                {
                    if (rCourse.getCourseID() < course.getCourseID())
                        index++;
                    else
                        break;
                }
                Global.ListCourseRemaining.Insert(index, course);
            }
        }

        public void removeCourseRemaining(Course course)
        {
            //add error clause
            if (Global.ListCourseRemaining.Count != 0)
            {
                int index = 0;
                foreach (Course rCourse in Global.ListCourseRemaining)
                {
                    if (rCourse.getCourseID() < course.getCourseID())
                        index++;
                    else
                        break;
                }
                Global.ListCourseRemaining.RemoveAt(index);
            }
        }

        private void displayError(String err)
        {
            error_record.Style["color"] = "red";
            error_record.Text = String.Format(err + "");
            error_record.Visible = true;
        }
	}
}