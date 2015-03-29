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
        DBHandler db = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            // below code checks if user already exists or not.
            if (IsPostBack)
            {
                /*Global.myConnection.Open();
                string checkuser = "select count(*) from User where netName='" + TextBoxNetN.Text + "'";
                SqlCommand com = new SqlCommand(checkuser, Global.myConnection);

                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                if (temp == 1)
                {
                    Response.Write("User already exists");
                } */



            }
        }

    
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            try
            {
                //Global.myConnection.Open();
               // string insertQuery = "insert into User (FirstName,LastName,Password,netName,email,SchoolID,isAdmin) values (@FirstName,@LastName,@Password,@netName,@email,@SchooldID,@isAdmin)";
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
                if(dr.HasRows)
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
/*
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
        DBHandler db = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            // below code checks if user already exists or not.
            if (IsPostBack)
            {
                /*
                //Global.myConnection.Open();
                string checkuser = "select * from [dbo].[User] where netName='" + TextBoxNetN.Text + "'";
                SqlCommand com = new SqlCommand(checkuser, Global.myConnection);
                SqlDataReader myReader = null;
                myReader = com.ExecuteReader();

                if (myReader != null)
                {
                    
                }
                else
                    while (myReader.Read()) ;
                 




            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User temp = db.getUser(TextBoxNetN.Text);
            if (temp != null)
            {
                Response.Write("User already exists");

            }
            else
            {
                try
                {

                    //Global.myConnection.Open();
                    string insertQuery = "insert into [dbo].[User] (FirstName,LastName,Password,netName,email,SchoolID,isAdmin) values (@FirstName,@LastName,@Password,@netName,@email,@SchoolID,@isAdmin)";
                    SqlCommand com2 = new SqlCommand(insertQuery, Global.myConnection);
                    com2.Parameters.AddWithValue("@FirstName", TextBoxFN.Text);
                    com2.Parameters.AddWithValue("@LastName", TextBoxLN.Text);
                    com2.Parameters.AddWithValue("@Password", TextBoxPWD.Text);
                    com2.Parameters.AddWithValue("@netName", TextBoxNetN.Text);
                    com2.Parameters.AddWithValue("@email", TextBoxEmail.Text);
                    com2.Parameters.AddWithValue("@SchoolID", Convert.ToInt32(TextBoxSchoolID.Text));
                    bool isAdmin = false;
                    if (Convert.ToInt32(RadioButtonList1.SelectedValue) == 1)
                    {
                        isAdmin = true;

                    }

                    com2.Parameters.AddWithValue("@isAdmin", isAdmin);

                    com2.ExecuteNonQuery();
                    Response.Redirect("login.aspx");
                    Response.Write("Registration is Successful");


                }
                catch (Exception ex)
                {
                    Response.Write("Error:" + ex.ToString());

                }
            }
        }

        protected void TextBoxFN_TextChanged(object sender, EventArgs e)
        {

        }
    }
} */