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
        //to change------------------------------------------------
        static Boolean ReloadChanges = true;//put in global.when logout, resets bool to true.
        //test netname
        String netName = "4";//get from global????
        //---------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            //testLabel.Text = "ReloadChange: "+ReloadChanges;
            if (ReloadChanges)
            {
                displayAllPreferences();
            }
                
        }
        public void editPreferences(object sender, EventArgs e)
        {
            if (!ChkLstTechnical.Enabled)
                ChkLstTechnical.Enabled = true;
            else
                ChkLstTechnical.Enabled = false;
        }
        private void savePreferences()
        {
            //CheckedListBox.CheckedItemCollection
            //get all checked items, find matching course and add them to DB
            ReloadChanges = true;
        }
        private void displayAllPreferences()
        {
            
            //--------------------------------------------
            /*Once list of all preferences is made
             * Display list of all preferences
             * then compare each item with user preferences
             * if match, then selected=true
             */
            //get list of all preferences of user
            List<List<SOEN341_nobean.Class.Course>> preferencesList = dbhandler.getPreferences(netName);
            //populate tables with course name+code and checkbox
            
            //**** do same as technical course 
            foreach (SOEN341_nobean.Class.Course course in preferencesList[0])
            {
                TableRow row = new TableRow();
                TableCell cellCourseName = new TableCell();
                TableCell cellCheckBox = new TableCell();
                CheckBox checkbox = new CheckBox();
                checkbox.ID = "Checkbox" + course.getSubject() + course.getCode();

                cellCourseName.Text = course.getSubject() + " " + course.getCode();
                if (true)//change to check if course is in student preferences
                {
                    checkbox.Checked = true;
                    //checkbox.Enabled = false;
                }
                else
                {
                    checkbox.Checked = false;
                    //checkbox.Enabled = false;
                }
                cellCheckBox.Controls.Add(checkbox);
                row.Cells.Add(cellCourseName);
                row.Cells.Add(cellCheckBox);
                TableScience.Rows.Add(row);
            }
            //**** do same as technical course 
            foreach (SOEN341_nobean.Class.Course course in preferencesList[1])
            {
                TableRow row = new TableRow();
                TableCell cellCourseName = new TableCell();
                TableCell cellCheckBox = new TableCell();
                CheckBox checkbox = new CheckBox();
                checkbox.ID = "Checkbox" + course.getSubject() + course.getCode();

                cellCourseName.Text = course.getSubject() + " " + course.getCode();
                if (true)//change to check if course is in student preferences
                {
                    checkbox.Checked = true;
                    //checkbox.Enabled = false;
                }
                else
                {
                    checkbox.Checked = false;
                    //checkbox.Enabled = false;
                }
                cellCheckBox.Controls.Add(checkbox);
                row.Cells.Add(cellCourseName);
                row.Cells.Add(cellCheckBox);
                TableGeneral.Rows.Add(row);
            }
            foreach (SOEN341_nobean.Class.Course course in preferencesList[2])
            {
                String chkText = course.getSubject() + " " + course.getCode();
                ChkLstTechnical.Items.Add(chkText);
                if (true)//change to check if course is in student preferences
                {
                    ChkLstTechnical.Items.FindByValue(chkText).Selected = true;
                    //ChkLstTechnical.SetItemCheckState(0, true); //using System.Windows.Forms(.dll)
                    
                }
                else
                {
                }
            }
            ChkLstTechnical.Enabled=false;
            ReloadChanges = false;
        }
    }
}