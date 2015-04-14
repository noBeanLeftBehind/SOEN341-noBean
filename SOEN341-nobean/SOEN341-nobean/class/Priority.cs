using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace SOEN341_nobean.Class
{
    public class CourseSequence
    {
        //SortedSet<Course> prioritizedCourse;  
        SortedList<int, Course> prioritizedCourse;
     
        int index = 0;
        int numberofcourses = 0;

        public CourseSequence()
        {
            prioritizedCourse = new SortedList<int, Course>(new DuplicateKeyComparer<int>());
        }

        public void removeTakenCourse(){
        }


        public void addCourse(int priority, Course coursename)
        {
                if (!prioritizedCourse.ContainsValue(coursename))
                {
                    numberofcourses++;
                    prioritizedCourse.Add(priority, coursename);
                }
        }
    
        public Course getCourseBefore(Course coursename)
        {
            int index1 = prioritizedCourse.IndexOfValue(coursename);
            return prioritizedCourse.Values[index1 - 1];
        }

        public Course getCourseAfter(Course coursename)
        {
            int index1 = prioritizedCourse.IndexOfValue(coursename);
            return prioritizedCourse.Values[index1 + 1];
        }

        public Course getnext()
        {
            return prioritizedCourse.Values[index++];
        }

        public Course getprevious()
        {
            if (index != 0) { }
            return prioritizedCourse.Values[index];
        }


        public Course getCurrentCourse()
        {
            return prioritizedCourse.Values[index];
        }

        public int getCurrentPriority()
        {
            return prioritizedCourse.Keys[index];
        }

        public Boolean hasnext()
        {
            return index != numberofcourses;
        }

        public void removeCourse(Course coursename)
        {
            numberofcourses--;
            prioritizedCourse.RemoveAt(prioritizedCourse.IndexOfValue(coursename));
        }




    }
}

