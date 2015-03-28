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
        protected void Page_Load(object sender, EventArgs e)
        {
            displayCoursePrefBasicSci();
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