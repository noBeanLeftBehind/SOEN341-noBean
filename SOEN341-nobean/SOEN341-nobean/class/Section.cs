using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEN341_nobean.Class
{
    public class Section
    {
        int semester;
        private String courseSig;
        private String courseID;
        String sectionName;
        String day;
        String startTime;
        String endTime;
        DateTime start;
        DateTime end;
        List<Section> tutorial = new List<Section>();
        List<Section> lab = new List<Section>();
        //for internal use
        private String LecID;
        public void setId(String id)
        {
            this.LecID = id;
        }
        public String getID()
        {
            return this.LecID;
        }
        public Section()
        {
        }

        public DateTime getStartDateTime() { return start; }
        public DateTime getEndDateTime() { return end; }
        public void setStartDateTime(DateTime START) { start = START; }
        public void setEndDateTime(DateTime END) { end = END; }

        public void setSemester(int semester)
        {
            this.semester = semester;
        }
        public void setSectionName(String name)
        {
            this.sectionName = name;
        }
        public void setDay(String day)
        {
            this.day = day;
        }
        public void setTime(String START, String END)
        {
            this.startTime = START;
            this.start = Convert.ToDateTime(START);
            this.endTime = END;
            this.end = Convert.ToDateTime(END);
        }
        public void addTut(Section tut)
        {
            this.tutorial.Add(tut);
        }
        public void addLab(Section lab)
        {
            this.lab.Add(lab);
        }

        public int getSemester()
        {
            return this.semester;
        }
        public String getSectionName()
        {
            return this.sectionName;
        }
        public String getDay()
        {
            return this.day;
        }
        public String getStart()
        {
            return this.startTime;
        }
        public String getEnd()
        {
            return this.endTime;
        }
        public List<Section> getTutorials()
        {
            return this.tutorial;
        }
        public List<Section> getLabs()
        {
            return this.lab;
        }

        public Section getTut(String id)
        {
            Section tut = null;
            foreach (Section tuts in tutorial)
                if (tuts.getID() == id)
                    tut = tuts;

            return tut;
        }

        public Section getLab(String id)
        {
            Section lab = null;
            foreach (Section labs in this.lab)
                if (labs.getID() == id)
                    lab = labs;

            return lab;
        }

        public void setCourseSig(String sig)
        {
            this.courseSig = sig;
        }

        public String getCourseSig()
        {
            return this.courseSig;
        }

        public void setCourseID(String id)
        {
            this.courseID = id;
        }

        public String getCourseID()
        {
            return this.courseID;
        }
    }
}