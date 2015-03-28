using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace SOEN341_nobean
{
    public partial class adminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SubmitIDButton.Click += new EventHandler(this.SubmitIDButton_Click);
        }

        private void SubmitIDButton_Click(object sender, EventArgs e)
        {
            String studentID = studentIDTextBox.Text;
            Regex ID_regex = new Regex(@"(\d{8})\b");
            Match match = ID_regex.Match(studentID);
            error_IDStudent.Style["color"] = "red";
            if (match.Success)
            {
                error_IDStudent.Style["color"] = "black";
                error_IDStudent.Text = "Searching for ID...";
            }
            else
                error_IDStudent.Text = "ERROR: Enter a 8 digit Student ID";
        }
    }
}