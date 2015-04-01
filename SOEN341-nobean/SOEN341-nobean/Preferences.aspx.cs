using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SOEN341_nobean
{
    public partial class Preferences : System.Web.UI.Page
    {
        SOEN341_nobean.Class.DBHandler dbhandler = new SOEN341_nobean.Class.DBHandler();
        //test netname
        String netName = "4";//get from global????
        protected void Page_Load(object sender, EventArgs e)
        {
            displayCoursePrefBasicSci();
            displayAllPreferences();
        }


        private void displayAllPreferences()
        {
            String allPrefs = "";
            List<List<SOEN341_nobean.Class.Course>> preferencesList = dbhandler.getPreferences(netName);
            //display science
            allPrefs += "Size of technical list: "+preferencesList[2].Count+" (should be 3)";
            allPrefs += "Science Electives<br>";
            int i;
            for (i = 0; i < preferencesList[0].Count; i++)
            {
                allPrefs += preferencesList[0][i].getCourseName()+"<br>";
            }
            //display general
            allPrefs += "<br><br>General Electives<br>";
            for (i = 0; i < preferencesList[1].Count; i++)
            {
                allPrefs += preferencesList[1][i].getCourseName() + "<br>";
            }
            //display technical
            allPrefs += "<br><br>Technical Electives<br>";
            for (i = 0; i < preferencesList[2].Count; i++)
            {
                allPrefs += preferencesList[2][i].getCourseName() + "<br>";
            }
            testGetPrefDB.Text = allPrefs;
        }
        private void displayCoursePrefBasicSci()
        {
            //SOEN341_nobean.Class.Global globalDB = new SOEN341_nobean.Class.Global();
            SOEN341_nobean.Class.Course[] basicSciCourses = new  SOEN341_nobean.Class.Course[2];//globalDB.coursesBasicSci;//*** basic sciences classes array of courses

            //test data
            Boolean[] basicSciCoursesBinary = new Boolean[2];
            basicSciCourses[0] = new SOEN341_nobean.Class.Course();
            basicSciCourses[0].setCourseName("testcourse1");
            basicSciCourses[1] = new SOEN341_nobean.Class.Course();
            basicSciCourses[1].setCourseName("testcourse2");
            basicSciCoursesBinary[0] = true;
            basicSciCoursesBinary[1] = false;
            //--

            for (int i = 0; i < basicSciCourses.Length; i++)
            {
                TableRow row = new TableRow();
                TableCell cellCourseName = new TableCell();
                cellCourseName.Text = basicSciCourses[i].getCourseName();
                TableCell cellCheckBox = new TableCell();
                CheckBox checkbox = new CheckBox();
                checkbox.ID = "basicSciCoursesBinary"+i;
                //adding table elements to the table
                cellCheckBox.Controls.Add(checkbox);
                row.Cells.Add(cellCourseName);
                row.Cells.Add(cellCheckBox);
                TableCoursesBasicSci.Rows.Add(row);   
                if(basicSciCoursesBinary[i]){
                    checkbox.Checked = true;
                }
                else
                {
                    checkbox.Checked = false;
                }
                
                
                  
            }
        }
    }
}