using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEN341_nobean.Class
{
    public class CourseDirectory
    {
        List<Course> allCourses = new List<Course>();
        List<Course> electiveScience = new List<Course>();
        List<Course> electiveTechnical = new List<Course>();
        List<Course> electiveGeneral = new List<Course>();

        protected void addallCourses(Course cours)
        {
            allCourses.Add(cours);
        }

        protected void addelectiveScience(Course cours)
        {
            electiveScience.Add(cours);
        }

        protected void addelectiveTechnical(Course cours)
        {
            electiveTechnical.Add(cours);
        }

        protected void addelectiveGeneral(Course cours)
        {
            electiveGeneral.Add(cours);
        }


    }
}