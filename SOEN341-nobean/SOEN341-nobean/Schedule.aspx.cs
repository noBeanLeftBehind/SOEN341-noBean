using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOEN341_nobean.Class;

namespace SOEN341_nobean
{
    public partial class Schedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //5 hardcoded courses
                //If I do not make SOEN341_nobean.Class.Schedule();
                //then it will be automatically SOEN341_nobean.Schedule();... why no .Class?
                //I will not enter all courses as I need to enter all possible sections...I will just make it fit in the schedule, to see look and feel
                //var winter2016 = new SOEN341_nobean.Class.Schedule(); 
                //Course engr391 = new Course("ENGR", "391", "Numerical MethodCs", 3);
                //Course soen344 = new Course("SOEN", "344", "Architecture Design", 3);
                //Course soen345 = new Course("SOEN", "345", "Testing and verification", 3);
                //Course soen357 = new Course("SOEN", "357", "User Interface Design", 3);
                //Course soen390= new Course("SOEN", "390", "Software Team Project", 3);

                //creating the list of course to be added to the List<List<Course>> semesters
                //List<Course> winter2016Courses = new List<Course>(new Course[] { engr391, soen344, soen345, soen357, soen390 });
                //winter2016.addASemester(winter2016Courses);
                //makeAspTable(winter2016);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        /*
         * If DayPilot does not work, one may generate the schedule with asp:Table and generating TableRows programmatically
         * 
         * */
        private void makeAspTable(SOEN341_nobean.Class.Schedule schedule)
        {
            DateTime dt = DateTime.Parse("7/01/2016 07:00:00 AM");
            //This comparison should stop when the last class has finished.
            while(dt.Hour != 22)
            {
                TableRow row = new TableRow();
                TableCell time = new TableCell();
                TableCell monday = new TableCell();
                TableCell tuesday = new TableCell();
                TableCell wednesday = new TableCell();
                TableCell Thursday = new TableCell();
                TableCell Friday = new TableCell();
                time.Text = String.Format("{0:HH:mm}", dt);
                
                // I will enter manually courses in the schedule to see how it fits in it....
                //There should be if statement whether the course starts at this time, then row span.
                    //if(engr391.startTime()==dt)

                //adding all the cells
                row.Cells.Add(time);
                row.Cells.Add(monday);
                row.Cells.Add(time);
                row.Cells.Add(time);
                row.Cells.Add(time);
                //adding the row to the asp table
                winter2016Schedule.Rows.Add(row);
                //adding 15 minutes for the next row
                dt = dt.AddMinutes(15);
            }
        }
    }
}