using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SOEN341_nobean.Class
{
    public class Course
    {
        protected int courseID;
        protected String code;
        protected String subject;
        protected String courseName;
        //protected int credits;
        protected String description;
        protected int priority;
        //protected List<Course> preRequisites = new List<Course>();
        protected List<Section> lecture = new List<Section>();
        Record studentRecord = new Record();
        private Boolean isCore = false;
        private Boolean isScience = false;
        private Boolean isGeneral = false;
        private Boolean isTechnical = false;

        public Course(String name, String code, String description) //int credits)
        {
            this.courseName = name;
            this.code = code;
            this.description = description;
           // this.credits = credits;
        }
        public Course(){}
        public int getCourseID()
        {
            return courseID;
        }
        public void setCourseID(int courseID)
        {
            this.courseID = courseID;
        }
        //protected void addpreRequisites(Course pre)
        //{
        //    preRequisites.Add(pre);
        //}
        public void addLecture(Section sec)
        {
            lecture.Add(sec);
        }

        public List<Section> getLectures()
        {
            return lecture;
        }
        public String getCourseName()
        {
            return courseName;
        }

        public void setCourseName(String name)
        {
            this.courseName = name;
        }

        //public int getCredits()
        //{
        //    return credits;
        //}

        //public void setCredits(int credits)
        //{
        //    this.credits = credits;
        //}

        public String getCode()
        {
            return code;
        }

        public void setCode(String code)
        {
            this.code = code;
        }
        public String getSubject()
        {
            return subject;
        }
        public void setSubject(String subject)
        {
            this.subject = subject;
        }

        public String getDescription()
        {
            return description;
        }

        public void setDescription(String descp)
        {
            this.description = descp;
        }
        public void setPriority(int priority)
        {
            this.priority = priority;
        }
        public int getPriority()
        {
            return priority;
        }

        //public Boolean equals(Course cours)
        //{
        //    return (this.courseName == cours.courseName && this.code == cours.code && this.description == cours.description && this.credits == cours.credits);
        //}

        //public Boolean preReqs()
        //{
        //    foreach (Course i in preRequisites)
        //    {
        //        foreach (Course j in studentRecord.coursesTaken)
        //        {
        //            if (j == i)
        //                continue;
        //            else
        //                return false;
        //        }
        //    }
        //    return true;
        //}

        //checks if course is of a specified type
        public Boolean isCoreCourse()
        {
            return this.isCore;
        }
        public Boolean isScienceCourse()
        {
            return this.isScience;
        }
        public Boolean isGeneralCourse()
        {
            return this.isGeneral;
        }
        public Boolean isTechnicalCourse()
        {
            return this.isTechnical;
        }
        //sets course as a specific type
        public void setAsCore()
        {
            this.isCore = true;
            this.isScience = false;
            this.isGeneral = false;
            this.isTechnical = false;
        }
        public void setAsScience()
        {
            this.isCore = false;
            this.isScience = true;
            this.isGeneral = false;
            this.isTechnical = false;
        }
        public void setAsGeneral()
        {
            this.isCore = false;
            this.isScience = false;
            this.isGeneral = true;
            this.isTechnical = false;
        }
        public void setAsTechnical()
        {
            this.isCore = false;
            this.isScience = false;
            this.isGeneral = false;
            this.isTechnical = true;
        }
        

    }
}