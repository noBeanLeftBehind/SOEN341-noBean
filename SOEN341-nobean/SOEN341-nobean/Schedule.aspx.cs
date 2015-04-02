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
        //Semesters datatable
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Select source, either online db or local
            //Calendar may also be binded to an arraylist.  
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

        }

        /**
         * Test DB to create a schedule.
         */
        private DataTable makeTestDB()
        {
            dt = new DataTable();
            dt.Columns.Add("start", typeof(DateTime));
            dt.Columns.Add("end", typeof(DateTime));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("id", typeof(string));

            //My fall schedule 2015 :)
            makeRow(DayOfWeek.Thursday, 16, 45, 18, 05,  "COMP353 - Laboratory");
            makeRow(DayOfWeek.Thursday, 13, 15, 16, 00, "COMP353 - Lecture");
            makeRow(DayOfWeek.Thursday, 12, 15, 13, 05, "COMP535 - Tutorial");
            makeRow(DayOfWeek.Wednesday, 11, 45, 13, 00, "SOEN342 - Lecture");
            makeRow(DayOfWeek.Friday, 11, 45, 13, 00, "SOEN342 - Lecture");
            makeRow(DayOfWeek.Friday, 15, 45, 16, 35, "SOEN342 - Tutorial");
            makeRow(DayOfWeek.Wednesday, 13, 15, 14, 30, "SOEN343 - Lecture");
            makeRow(DayOfWeek.Friday, 13, 15, 14, 30, "SOEN343 - Lecture");
            makeRow(DayOfWeek.Friday, 14, 45, 15, 35, "SOEN343 - Tutorial");
            makeRow(DayOfWeek.Wednesday, 10, 15, 11, 30, "SOEN384 - Lecture");
            makeRow(DayOfWeek.Friday, 10, 15, 11, 30, "SOEN384 - Lecture");
            makeRow(DayOfWeek.Friday, 09, 15, 10, 05, "SOEN384 - Tutorial");
            return dt;
        }

        /*
         * Make a row for the selected course in semesters DataTable
         * */
        private void makeRow(DayOfWeek dayOfWeek, int startHour, int startMinute, int endHour, int endMinute, string name)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["start"] = weeklyDate(dayOfWeek, startHour, startMinute);
            dr["end"] = weeklyDate(dayOfWeek, endHour, endMinute);
            dr["name"] = name;
            dt.Rows.Add(dr);
        }

        /*
         * Get the date from the ongoing week. There's no need for recursion. Just load the appropriate date of the week. 
         * 
         * */
        private DateTime weeklyDate(DayOfWeek dayOfWeek, int hour, int minutes)
        {
            DateTime now = DateTime.Today;
            if (now.DayOfWeek == dayOfWeek)
                return new DateTime(now.Year, now.Month, now.Day, hour, minutes, 0);
            else if (now.DayOfWeek > dayOfWeek)
            {
                while (now.DayOfWeek != dayOfWeek)
                {
                    now = now.AddDays(-1);
                }
                return new DateTime(now.Year, now.Month, now.Day, hour, minutes, 0);
            }
            else if (now.DayOfWeek < dayOfWeek)
            {
                while (now.DayOfWeek != dayOfWeek)
                {
                    now = now.AddDays(1);
                }
                return new DateTime(now.Year, now.Month, now.Day, hour, minutes, 0);
            }
            return now;
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

        /**
         * You can customize CSS events here. All at once, or by their ID, name, etc. 
         */
        protected void DayPilotMonth1_BeforeEventRender(object sender, BeforeEventRenderEventArgs e)
        {
            //You can put event CSS here
            //e.CssClass = "";
       }
    }
}