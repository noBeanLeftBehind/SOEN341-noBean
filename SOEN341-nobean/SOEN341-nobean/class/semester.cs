using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEN341_nobean.Class
{
	public class semester
	{
        private int section;
        private int year;
        private List<Course> courses;

        public semester()
        {
            this.courses = new List<Course>();
        }

        public void setSection(int sect){this.section = sect;}

        public void setYear(int yr){this.year = yr;}

        public void setCourses(List<Course> course) { this.courses = course; }
	}
}