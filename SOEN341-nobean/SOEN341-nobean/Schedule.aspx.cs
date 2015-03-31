using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOEN341_nobean.Class;
using System.Data;
using DayPilot.Web.Ui.Events.Calendar;
using DayPilot.Web.Ui; 

namespace SOEN341_nobean
{
    public partial class Schedule : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Select source, either online db or local
            //Calendar may also be binded to an arraylist. May be simpler. 
            // http://www.daypilot.org/demo/Lite/Calendar/BindingArrayList.aspx
            DayPilotCalendar1.DataSource = makeTestDB();
            DayPilotCalendar2.DataSource = makeTestDB();

            //configure the look and feel of calendar
            configureCalendar(DayPilotCalendar1);
            configureCalendar(DayPilotCalendar2);
            
            //Bind the data once everything is loaded.
            if (!IsPostBack)
                DayPilotCalendar1.DataBind();
                DayPilotCalendar2.DataBind();
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

        /**
         * I think we need to make events recursive so that after one week they don't disappear. But I dont know how yet.
         * We can load values from the db here and create a local db to hold the data. Else we can connect directly with a db table, I think. 
         * Creating multiple schedule could be done with multiple calendars or one calendar that we update with the date. 
         * like fall2015 - sept/dec events winter2016 - jan/april events, ...
         */
        private DataTable makeTestDB()
        {
            dt = new DataTable();
            dt.Columns.Add("start", typeof(DateTime));
            dt.Columns.Add("end", typeof(DateTime));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("id", typeof(string));

            DataRow dr;
            dr = dt.NewRow();
            dr["id"] = 0;
            dr["start"] = Convert.ToDateTime("8:45").AddDays(1);
            dr["end"] = Convert.ToDateTime("10:00").AddDays(1);
            dr["name"] = "ENGR391 - Lecture";
            dt.Rows.Add(dr);

            DataRow ds;
            ds = dt.NewRow();
            ds["id"] = 0;
            ds["start"] = Convert.ToDateTime("8:45").AddDays(3);
            ds["end"] = Convert.ToDateTime("12:00").AddDays(3);
            ds["name"] = "SOEN357 - Lecture";
            dt.Rows.Add(ds);
            // ...

            return dt;
        }

        /**
         * Configure your calendar here, you can apply css and names of columns for your events in calendar.
         */
        private void configureCalendar(DayPilotCalendar DayPilotCalendar1)
        {
            DayPilotCalendar1.HeaderDateFormat = "dddd";
            DayPilotCalendar1.DataStartField = "start";
            DayPilotCalendar1.DataEndField = "end";
            DayPilotCalendar1.DataTextField = "name";
            DayPilotCalendar1.DataIdField = "id";
            //DayPilotCalendar1.CssClass = "";
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
                TableCell thursday = new TableCell();
                TableCell friday = new TableCell();
                time.Text = String.Format("{0:HH:mm}", dt);
                
                // I will enter manually courses in the schedule to see how it fits in it....
                //There should be if statement whether the course starts at this time, then row span.
                    //if(engr391.startTime()==dt)

                //adding all the cells
                row.Cells.Add(time);
                row.Cells.Add(monday);
                row.Cells.Add(tuesday);
                row.Cells.Add(wednesday);
                row.Cells.Add(thursday);
                row.Cells.Add(friday);
                //adding the row to the asp table
                winter2016Schedule.Rows.Add(row);
                //adding 15 minutes for the next row
                dt = dt.AddMinutes(15);
            }
        }

        /**
         * You can customize CSS events here. All at once, or by their ID, name, etc. 
         */
        protected void DayPilotMonth1_BeforeEventRender(object sender, BeforeEventRenderEventArgs e)
        {
            //You can put event CSS here
            e.ToolTip="ENGR391 - Lecture";
            //e.CssClass = "";
       }
    }
}