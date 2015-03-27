using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            studentIDTextBox.Text = "got it";
        }
    }
}