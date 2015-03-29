using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOEN341_nobean.Class;
using System.Data;
namespace SOEN341_nobean
{

    /// <summary>
    /// after logging in and before going to the next page
    /// you have to save an object of the user in class Global + his preferences + record
    /// AND you have to create Course Directory object and save it also in Global 
    /// so everyone can have access to these while logging in and not let him wait at every page
    /// 
    /// second you have to have a button on the login page 'Sign Up' -> registration page.. this page makes you add data and sign up 
    /// you have to check that netname is not repeated in the database and email is a valid email and not repeated in the database
    /// after registration successfully you go back to login page
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        DBHandler db = new DBHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection tempConnection = new SqlConnection();
            try
            {
                tempConnection.ConnectionString = "Data Source=buax9l2psh.database.windows.net,1433;Initial Catalog=masterscheduler100_db;Persist Security Info=True;User ID=nobean;Password=Abc_12345";
                Global.myConnection = tempConnection;
                
                if(Global.myConnection != null && Global.myConnection.State == ConnectionState.Closed)
                       Global.myConnection.Open();

                TextBox3.Text = "Test User to login \nNetName: testnetname\nPass: 123test\n";
            }
            catch (Exception exp)
            {
                TextBox3.Text = TextBox3.Text + exp.ToString() + "\n";
                Console.WriteLine(exp.ToString());
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           Global.MainUser = db.getUser(TextBox1.Text.ToString());

        
                   

                   if (TextBox2.Text == Global.MainUser.getPassword())
                   {

                       Server.Transfer("Home.aspx");
                   }
                   else
                       Page.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('Invalid Login Credentials!');", true);
                       //TextBox3.Text = TextBox3.Text + "\n! \n";
                   
           // String myStringVariable = "hi";
          

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e) 
        {
           
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}