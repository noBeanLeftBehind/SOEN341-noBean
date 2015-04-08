using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOEN341_nobean.Class
{
    public class Record
    {
        int _GPA;
        int _creditsRequired;
        //protected Course[] coursesTaken;
        public List<Course> coursesTaken = new List<Course>();
        //protected Course[] sequence;
        public List<Course> sequence = new List<Course>();
       // protected Course[] electiveChoices;
        public List<Course> electiveChoices = new List<Course>();

        int GPA
        {
            get
            {
                return _GPA;
            }

            set
            {
                this._GPA = value;
            }
        }


        int creditsRequired
        {
            get
            {
                return _creditsRequired;
            }

            set
            {
                this._creditsRequired = value;
            }
        }

        public List<Course> getCoursesTaken()
        {
            return coursesTaken;
        }

        public void addCourseTaken (Course cours){
            coursesTaken.Add(cours);
        }

        public void addSequence(Course cours){
            sequence.Add(cours);
        }

        public void addelectiveChoices(Course cours){
            electiveChoices.Add(cours);
        }
    }
}