using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOEN341_nobean.Class;

namespace SOEN341_nobean
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Global.MainUser != null) && (Global.MainUser.getisAdmin()))
            {
                scheduleNavID.Style.Add("display", "none");
                accountNavID.Style.Add("display", "none");
            }

            if (Global.Admin != null && Global.Admin != Global.MainUser)
            {
                logoutAnchor.InnerHtml = "Administrator Home";
            }
            if (Request.QueryString["id"] == "logout")
            {
                if (Global.Admin != null && Global.MainUser != null && Global.Admin != Global.MainUser)
                {
                    Global.MainUser = Global.Admin;
                    Response.Redirect("home.aspx");
                }
                else if (Global.Admin == null && Global.MainUser != null)
                {
                    Global.MainUser = null;
                    Global.myConnection.Close();
                    Response.Redirect("login.aspx");
                }
                else if (Global.MainUser == Global.Admin)
                {
                    Global.MainUser = null;
                    Global.Admin = null;
                    Global.myConnection.Close();
                    Response.Redirect("login.aspx");
                }
            }
        }
    }
}