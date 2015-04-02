using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEN341_nobean.Class
{
    
    public class Schedule
    {
        private int credits;
        private List<List<Course>> semesters;

        public Schedule()
        {
            this.semesters = new List<List<Course>>();
        }

        public int getCredits()
        {
            return this.credits;
        }
        public void setCredits(int credits)
        {
            this.credits = credits;
        }

        public List<List<Course>> getSemester()
        {
            return this.semesters;
        }

        public void setSemester(List<List<Course>> semesters)
        {
            this.semesters = semesters;
        }

        public void addASemester(List<Course> semester)
        {
            this.semesters.Add(semester);
        }

    }
}