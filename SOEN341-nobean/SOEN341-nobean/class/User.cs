using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SOEN341_nobean
{
    [Serializable]
    public class User
    {
        protected int UserID;
        protected int StudentID;
        //Schedule currentSchedule = new Schedule();
        //Record StudentRecord = new Record();
        protected String firstName;
        protected String lastName;
        protected String netName;
        protected String password;
        protected String email;
        protected Boolean isAdmin;
        public User() { }
        public User(int UserID, int studID, String first, String last, String net, String pass,String email, Boolean isAdmin)
        {
            this.UserID = UserID;
            this.StudentID = studID;
            this.firstName = first;
            this.lastName = last;
            this.netName = net;
            this.password = pass;
            this.email = email;
            this.isAdmin = isAdmin;
     }

        public int getUserID()
        {
            return UserID;
        }

        public void setUserID(int userid)
        {
            this.UserID = userid;
        }
        public int getStudentID(){
            return StudentID;
        }

        public void setStudentID(int id){
            this.StudentID = id;
        }

        public String getfirstName(){
            return firstName;
        }

        public void setfirstName(String first){
            this.firstName = first;
        }

        public String getlastName(){
            return lastName;
        }

        public void setlastName(String last) {
            this.lastName = last;
        }

        public String getnetName(){
            return netName;
        }

        public void setnetName(String net){
            this.netName = net;
        }

        public String getPassword()
        {
            return password;
        }

        public void setPassword(String pass)
        {
            this.password = pass;
        }

        public String getemail()
        {
            return email;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public Boolean getisAdmin()
        {
            return isAdmin;
        }
        public void setisAdmin(Boolean isadmin)
        {
            this.isAdmin = isadmin;
        }

    }
}