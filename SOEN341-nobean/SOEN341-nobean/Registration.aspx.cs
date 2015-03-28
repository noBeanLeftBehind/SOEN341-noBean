using SOEN341_nobean.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOEN341_nobean
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // below code checks if user already exists or not.
            if (IsPostBack)
            {
                Global.myConnection.Open();
                string checkuser = "select count(*) from User where netName='" + TextBoxNetN.Text + "'";
                SqlCommand com = new SqlCommand(checkuser, Global.myConnection);

                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                if (temp == 1)
                {
                    Response.Write("User already exists");
                }



            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Global.myConnection.Open();
                string insertQuery = "insert into User (FirstName,LastName,Password,netName,email,SchoolID,isAdmin) values (@FirstName,@LastName,@Password,@netName,@email,@SchooldID,@isAdmin)";
                SqlCommand com = new SqlCommand(insertQuery, Global.myConnection);
                com.Parameters.AddWithValue("@FirstName", TextBoxFN.Text);
                com.Parameters.AddWithValue("@LastName", TextBoxLN.Text);
                com.Parameters.AddWithValue("@Password", TextBoxPWD.Text);
                com.Parameters.AddWithValue("@netName", TextBoxNetN.Text);
                com.Parameters.AddWithValue("@email", TextBoxEmail.Text);
                com.Parameters.AddWithValue("@SchoolID", TextBoxSchoolID.Text);
                com.Parameters.AddWithValue("@isAdmin", RadioButtonList1.SelectedValue);

                com.ExecuteNonQuery();
                Response.Redirect("login.aspx");
                Response.Write("Registration is Successful");
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());

            }
        }

        protected void TextBoxFN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}