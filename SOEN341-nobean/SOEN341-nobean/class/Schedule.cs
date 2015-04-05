using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEN341_nobean.Class
{
    
    public class Schedule
    {
        private int credits;
        private List<semester> semesters;

        public Schedule()
        {
            this.semesters = new List<semester>();
        }

        public int getCredits()
        {
            return this.credits;
        }
        public void setCredits(int credits)
        {
            this.credits = credits;
        }

        public List<semester> getSemester()
        {
            return this.semesters;
        }

        public void setSemester(List<semester> semesters)
        {
            this.semesters = semesters;
        }

        public void addASemester(semester semester)
        {
            this.semesters.Add(semester);
        }

    }
}