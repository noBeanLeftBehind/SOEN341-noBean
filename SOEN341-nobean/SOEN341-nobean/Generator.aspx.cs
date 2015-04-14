using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOEN341_nobean.Class;


namespace SOEN341_nobean
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<Course> passedCourse = Global.ListCourseTaken;
        List<Course> preferenceList = Global.ListPreferences;
        List<Course> remainingCourse = Global.ListCourseRemaining;
        CourseDirectory cd = Global.CourseDirectory;
        CourseSequence cs = new CourseSequence(); //creates a sequence using the user preferences and remaining courses

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {                    
                    CreateCourseSequence();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
 
        }

        public void CreateCourseSequence() //WithUserPreferenceAndRemainingCore
        {
            foreach (Course cours in remainingCourse) 
            {
                cs.addCourse(cours.getPriority(), cours); //Adding All remaining core classes into priority list
            }

            foreach (Course cours in preferenceList)
            {
                cs.addCourse(cours.getPriority(), cours); //Adding All preference courses into priority list
            }
        }

      
    }
}