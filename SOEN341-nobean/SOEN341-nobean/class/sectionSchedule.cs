using SOEN341_nobean.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEN341_nobean.Class
{
    public class sectionSchedule
    {

        protected int courseID;
        protected String code;
        protected String subject;
        protected String courseName;
        //protected int credits;
        protected String description;
        protected int priority;
        //protected List<Course> preRequisites = new List<Course>();
        protected Section lecture = new Section();
        protected Section tutorial = new Section();
        private Boolean isCore = false;
        private Boolean isScience = false;
        private Boolean isGeneral = false;
        private Boolean isTechnical = false;


          public sectionSchedule(Course course, Section lec, Section tut ) 
        {
            this.courseName = course.getCourseName();
            courseID = course.getCourseID();
            code = course.getCode();
            subject = course.getSubject();
       
            description = course.getDescription();
            
            priority = course.getPriority();
            isCore = course.isCoreCourse();
            isGeneral = course.isGeneralCourse();
            isTechnical = course.isTechnicalCourse();
            lecture = lec;
            tutorial = tut;

          
        }

          public Section getLecture() { return lecture; }
          public Section getTutorial() { return tutorial; }
        public int getCourseID()
        {
            return courseID;
        }
        public void setCourseID(int courseID)
        {
            this.courseID = courseID;
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
    }
}
