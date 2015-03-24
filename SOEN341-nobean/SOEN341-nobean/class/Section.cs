using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEN341_nobean.Class
{
    public class Section
    {
        int year;
        int semester;
        String classroom;
        Course associatedCourse;
        List<Section> subSections = new List<Section>();
        List<User> studentsRegistered = new List<User>();
        Enum type; 

        Section(int sem, int year, String classrm, Course associatedCourse)
        {
            this.semester = sem;
            this.year = year;
            this.classroom = classrm;
            this.associatedCourse = associatedCourse;
        }


        public void addsubSections(Section subsec)
        {
            subSections.Add(subsec);
        }

        public void addstudentsRegistered(User student)
        {
            studentsRegistered.Add(student);
        }
    }
}