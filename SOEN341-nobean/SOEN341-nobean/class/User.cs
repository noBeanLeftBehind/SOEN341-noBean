using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SOEN341_nobean
{
    public class User
    {
        protected int StudentID;
        //Schedule currentSchedule = new Schedule();
        //Record StudentRecord = new Record();
        protected String firstName;
        protected String lastName;
        protected String netName;
        protected String password;
        protected Boolean isAdmin;

        User(int studID, String first, String last, String net, String pass, Boolean isAdmin){
            this.StudentID = studID;
            this.firstName = first;
            this.lastName = last;
            this.netName = net;
            this.password = pass;
            this.isAdmin = isAdmin;
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


    }
}