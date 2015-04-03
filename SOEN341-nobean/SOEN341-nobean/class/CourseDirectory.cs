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

        public void addallCourses(Course cours)
        {
            allCourses.Add(cours);
        }

        public void addelectiveScience(Course cours)
        {
            electiveScience.Add(cours);
        }

        public void addelectiveTechnical(Course cours)
        {
            electiveTechnical.Add(cours);
        }

        public void addelectiveGeneral(Course cours)
        {
            electiveGeneral.Add(cours);
        }

        public List<Course> getAllCourses()
        {
            return allCourses;
        }

        public List<Course> getElectiveTechnical()
        {
            return electiveTechnical;
        }

        public List<Course> getElectiveGeneral()
        {
            return electiveGeneral;
        }

        public List<Course> getElectiveScience()
        {
            return electiveScience;
        }


    }
}