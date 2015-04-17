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
        private List<Section> Lectures;
        private List<Section> Tutorials;
        private List<Section> Labs;
        private List<Course> onlineCourses;

        public semester()
        {
            this.Lectures = new List<Section>();
            this.Tutorials = new List<Section>();
            this.Labs = new List<Section>();
            this.onlineCourses = new List<Course>();
        }

        public void setSection(int sect){this.section = sect;}

        public void setYear(int yr){this.year = yr;}

        public int getSection()
        {
            return this.section;
        }

        public int getYear()
        {
            return this.year;
        }
        public void addLecture(Section lec)
        {
            this.Lectures.Add(lec);
        }

        public void addTutorials(Section tut)
        {
            this.Tutorials.Add(tut);
        }

        public void addLabs(Section lab)
        {
            this.Labs.Add(lab);
        }

        public void addLecture(List<Section> lec)
        {
            this.Lectures.Concat<Section>(lec);
        }

        public void addTutorials(List<Section> tut)
        {
            this.Tutorials.Concat<Section>(tut);
        }

        public void addLabs(List<Section> lab)
        {
            this.Labs.Concat<Section>(lab);
        }

        public List<Section> getLabs()
        {
            return this.Labs;
        }

        public List<Section> getTuts()
        {
            return this.Tutorials;
        }

        public List<Section> getLectures()
        {
            return this.Lectures;
        }

        public void addOnlineCourse(Course crs)
        {
            this.onlineCourses.Add(crs);
        }

        public List<Course> getOnlineCourses()
        {
            return this.onlineCourses;
        }
	}
}