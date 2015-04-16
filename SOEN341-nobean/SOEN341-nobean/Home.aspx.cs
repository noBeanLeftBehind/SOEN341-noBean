using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOEN341_nobean.Class;

namespace SOEN341_nobean
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           /* semester sem = new semester();
            sem.setSection(1);
            sem.setYear(2017);
            sem.addLecture(Global.CourseDirectory.getCourse("1").getLecture("16"));
           
           SOEN341_nobean.Class.Schedule sch = new Class.Schedule();
            sch.addASemester(sem);
            DBHandler db=new DBHandler();
            db.insertCourseSchedule(sch);
            foreach(Section tut in Global.CourseDirectory.getCourse("9").getLecture("24").getTutorials())
                TextBox1.Text += tut.getID();*/
            if (Global.MainUser == null)
                Response.Redirect("login.aspx");
            if (Global.MainUser.getisAdmin() == true)
                Response.Redirect("adminHome.aspx");
        }

       

        protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {
           

            
        }
    }
}