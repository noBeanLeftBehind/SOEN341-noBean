using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEN341_nobean.Class
{
    public class Section
    {
        int semester;
        String sectionName;
        String day;
        String startTime;
        String endTime; 
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
        public void setTime(String start, String end)
        {
            this.startTime = start;
            this.endTime = end;
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
        public List<Section> getTut()
        {
            return this.tutorial;
        }
        public List<Section> getLab()
        {
            return this.lab;
        }
    }
}