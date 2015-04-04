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
    public partial class Regist : System.Web.UI.Page
    {
        DBHandler db = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            try
            {
                //Global.myConnection.Open();
                // string insertQuery = "insert into User (FirstName,LastName,Password,netName,email,SchoolID,isAdmin) values (@FirstName,@LastName,@Password,@netName,@email,@SchooldID,@isAdmin)";

                User temp = db.getUser(TextBoxNetN.Text.ToString());
                if (temp != null)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "myalert", "alert('Error. Netname is already in use!');", true);
                    return;
                }
                temp = db.getUserByEmail(TextBoxEmail.Text.ToString());
                if (temp != null)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "myalert", "alert('Error. Email is already in use!');", true);
                    return;
                }
                temp = db.getUserByID(TextBoxSchoolID.Text.ToString());
                if (temp != null)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "myalert", "alert('Error. School ID is already in use!');", true);
                    return;
                }



                string insertQuery = "insert into [dbo].[User] (FirstName,LastName,Password,netName,email,SchoolID,isAdmin) values (@FirstName,@LastName,@Password,@netName,@email,@SchoolID,@isAdmin)";


                SqlCommand com = new SqlCommand(insertQuery, Global.myConnection);

                com.Parameters.AddWithValue("@FirstName", TextBoxFN.Text);
                com.Parameters.AddWithValue("@LastName", TextBoxLN.Text);
                com.Parameters.AddWithValue("@Password", TextBoxPWD.Text);
                com.Parameters.AddWithValue("@netName", TextBoxNetN.Text);
                com.Parameters.AddWithValue("@email", TextBoxEmail.Text);
                com.Parameters.AddWithValue("@SchoolID", TextBoxSchoolID.Text);
                com.Parameters.AddWithValue("@isAdmin", RadioButtonList1.SelectedValue);

                dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    Response.Write("User already exists");
                }
                //com.ExecuteNonQuery();


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