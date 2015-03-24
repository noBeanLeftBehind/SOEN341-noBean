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
    }
}