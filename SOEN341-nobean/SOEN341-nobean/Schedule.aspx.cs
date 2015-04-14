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
using System.Diagnostics;

namespace SOEN341_nobean
{
    public partial class Schedule : System.Web.UI.Page
    {
        //Semesters datatable
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHandler db= new DBHandler();
            List<semester> semesters = db.getCourseSchedule(Global.MainUser.getUserID()+"");
            int counter = 0;
            //Select source, either online db or local
            //Calendar may also be binded to an arraylist.  
            // http://www.daypilot.org/demo/Lite/Calendar/BindingArrayList.aspx
            if(semesters.Count==0)
                sliderID.Controls.Add(new LiteralControl("<div style='text-align:center;'><p>Schedule Not Available</p></div>"));

            foreach(semester sem in semesters)
            {
                counter++;
                sliderID.Controls.Add(new LiteralControl("<div style='text-align:center;'><p>" + (sem.getSection() == 1 ? "Fall " : "Winter ") + sem.getYear() + "</p>"));
                DayPilotCalendar calendar=new DayPilotCalendar();
                calendar.ID = "DayPilotCalendar" + counter;
                calendar.Attributes.Add("TimeHeaderCellDuration", "15");
                calendar.Attributes.Add("ColumnWidthSpec", "fixed");
                calendar.Attributes.Add("ColumnWidth", "100");
                calendar.ViewType = DayPilot.Web.Ui.Enums.Calendar.ViewTypeEnum.WorkWeek;
                calendar.BusinessBeginsHour = 8;
                calendar.BusinessEndsHour = 24;
                calendar.DataSource = makeTestDB(sem);
                configureCalendar(calendar);
                sliderID.Controls.Add(calendar);
                sliderID.Controls.Add(new LiteralControl("</div>"));
            }
         
            
            //Bind the data once everything is loaded.
            if (!IsPostBack&&counter==semesters.Count)
            {
                foreach(Control cntrl in sliderID.Controls)
                    cntrl.DataBind();
            }

        }

        /**
         * Test DB to create a schedule.
         */
        private DataTable makeTestDB(semester sem)
        {
            dt = new DataTable();
            dt.Columns.Add("start", typeof(DateTime));
            dt.Columns.Add("end", typeof(DateTime));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("id", typeof(string));
          
           foreach(Section section in sem.getLectures())
            {
                if(section.getDay().Contains("Mo"))
                    makeRow(DayOfWeek.Monday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig()+" - Lecture "+section.getSectionName()+"\nStart: "+section.getStart().Substring(0,5)+" End: "+section.getEnd().Substring(0,5));
                if (section.getDay().Contains("Tu"))
                    makeRow(DayOfWeek.Tuesday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Lecture " + section.getSectionName() + "\nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
                if (section.getDay().Contains("We"))
                    makeRow(DayOfWeek.Wednesday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Lecture " + section.getSectionName() + "\nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
                if (section.getDay().Contains("Th"))
                    makeRow(DayOfWeek.Thursday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Lecture " + section.getSectionName() + "\nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
                if (section.getDay().Contains("Fr"))
                    makeRow(DayOfWeek.Friday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Lecture " + section.getSectionName() + "\nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
            }
            foreach (Section section in sem.getTuts())
            {
                if (section.getDay().Contains("Mo"))
                    makeRow(DayOfWeek.Monday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Tutorial  " + section.getSectionName() + " \nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
                if (section.getDay().Contains("Tu"))
                    makeRow(DayOfWeek.Tuesday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Tutorial  " + section.getSectionName() + " \nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
                if (section.getDay().Contains("We"))
                    makeRow(DayOfWeek.Wednesday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Tutorial  " + section.getSectionName() + " \nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
                if (section.getDay().Contains("Th"))
                    makeRow(DayOfWeek.Thursday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Tutorial  " + section.getSectionName() + " \nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
                if (section.getDay().Contains("Fr"))
                    makeRow(DayOfWeek.Friday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Tutorial  " + section.getSectionName() + " \nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
            }
            foreach (Section section in sem.getLabs())
            {
                if (section.getDay().Contains("Mo"))
                    makeRow(DayOfWeek.Monday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Lab  " + section.getSectionName() + "\nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
                if (section.getDay().Contains("Tu"))
                    makeRow(DayOfWeek.Tuesday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Lab  " + section.getSectionName() + "\nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
                if (section.getDay().Contains("We"))
                    makeRow(DayOfWeek.Wednesday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Lab  " + section.getSectionName() + "\nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
                if (section.getDay().Contains("Th"))
                    makeRow(DayOfWeek.Thursday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Lab  " + section.getSectionName() + "\nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
                if (section.getDay().Contains("Fr"))
                    makeRow(DayOfWeek.Friday, Convert.ToInt32(section.getStart().Substring(0, 2)), Convert.ToInt32(section.getStart().Substring(3, 2)), Convert.ToInt32(section.getEnd().Substring(0, 2)), Convert.ToInt32(section.getEnd().Substring(3, 2)), section.getCourseSig() + " - Lab  " + section.getSectionName() + "\nStart: " + section.getStart().Substring(0, 5) + " End: " + section.getEnd().Substring(0, 5));
            }
     
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