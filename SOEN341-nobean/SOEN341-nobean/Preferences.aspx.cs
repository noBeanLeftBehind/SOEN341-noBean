using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SOEN341_nobean
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DivCoursesBasicSci.InnerHtml = "page load working!!!!!";
            displayCoursePrefBasicSci();
        }

        private void displayCoursePrefBasicSci()
        {
           // SOEN341_nobean.Class.Global globalDB = new SOEN341_nobean.Class.Global();
            SOEN341_nobean.Class.Course[] basicSciCourses = new  SOEN341_nobean.Class.Course[2];//globalDB.coursesBasicSci;//*** basic sciences classes array of courses

            //Dynamically create table
            HtmlTable table = new HtmlTable();
            table.ID = "TableCoursesBasicSci";
            DivCoursesBasicSci.Controls.Add(table);

            Boolean[] basicSciCoursesBinary = new Boolean[2];
            basicSciCourses[0].setCourseName("testcoursename1");
            basicSciCourses[1].setCourseName("testcoursename2");
            basicSciCoursesBinary[0] = true;
            basicSciCoursesBinary[1] = false;

            for (int i = 0; i < basicSciCourses.Length; i++)
            {
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cellCourseName = new HtmlTableCell(basicSciCourses[i].getCourseName());
                HtmlTableCell cellCheckBox = new HtmlTableCell();
                CheckBox checkbox = new CheckBox();
                checkbox.ID = "basicSciCoursesBinary"+i;
                if(basicSciCoursesBinary[i]){
                    checkbox.Checked = true;
                }
                else
                {
                    checkbox.Checked = false;
                }
                row.Controls.Add(cellCourseName);
                row.Controls.Add(cellCheckBox);
                table.Controls.Add(row);     
            }
        }
    }
}