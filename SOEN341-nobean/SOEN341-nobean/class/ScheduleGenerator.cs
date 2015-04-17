using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOEN341_nobean.Class;

namespace SOEN341_nobean.Class
{
    public class ScheduleGenerator
    {
        Schedule studentSchedule = new Schedule();

         public static Schedule generate(SortedList<int, Course> priorityCourse, bool morning, bool night, bool mo, bool tu, bool we, bool th, bool fr)
        {
            List<semester> semesters = new List<semester>();

            Random rnd = new Random();
             
            while (priorityCourse.Count() > 0)
            {
                if (priorityCourse.Count() > 5)
                {
                    List<Course> one_semester_courses = new List<Course>();
                    //add 5 courses to be scheduled and returns one semester
                    for (int i = 0; i < 5; i++)
                    {
                        int k = i;
                        one_semester_courses.Add(priorityCourse.Values[0]);
                        priorityCourse.RemoveAt(0);
                    }
                    bool foundSemester = false;
                    while (!foundSemester)
                    {
                        semester bestSemester = generateOneSemester(one_semester_courses, morning, night, mo, tu, we, th, fr);

                        if (bestSemester != null)
                        {
                            semesters.Add(bestSemester);
                            Console.WriteLine("semester added");
                            Console.ReadLine();
                            foundSemester = true;
                        }
                        else
                        {
                            int random = rnd.Next(one_semester_courses.Count());
                            Course tempCourse = one_semester_courses[random];
                            one_semester_courses.RemoveAt(random);

                            //one_semester_courses.Add(priorityCourse.Values[0]);
                            //priorityCourse.RemoveAt(0);
                            priorityCourse.Add(tempCourse.getPriority(), tempCourse);
                            Console.WriteLine("semester returned null");

                        }
                    }
                }
                else
                {
                    Console.WriteLine("else is called");
                    List<Course> one_semester_courses = new List<Course>();
                    //add 5 courses to be scheduled and returns one semester
                    int num = priorityCourse.Count();
                    for (int i = 0; i < num; i++)
                    {
                        int k = i;
                        one_semester_courses.Add(priorityCourse.Values[0]);
                        Console.WriteLine(priorityCourse.Values[0].getCourseName());
                        priorityCourse.RemoveAt(0);
                    }

                 
                    bool foundSemester = false;
                    while (!foundSemester)
                    {
                        semester bestSemester = generateOneSemester(one_semester_courses, morning, night, mo, tu, we, th, fr);

                        if (bestSemester != null)
                        {
                            semesters.Add(bestSemester);
                            Console.WriteLine("semester added");
                            Console.ReadLine();
                            foundSemester = true;
                        }
                        else
                        {
                            int random = rnd.Next(one_semester_courses.Count());
                            Course tempCourse = one_semester_courses[random];
                            one_semester_courses.RemoveAt(random);

                            //one_semester_courses.Add(priorityCourse.Values[0]);
                            //priorityCourse.RemoveAt(0);
                            priorityCourse.Add(tempCourse.getPriority(), tempCourse);
                            Console.WriteLine("semester returned null");

                        }
                    }
                }
            }

            Schedule sched = new Schedule();
            sched.setSemester(semesters);

            return sched;
        }
        private static semester generateOneSemester(List<Course> one_semester_courses, bool morning, bool night, bool mo, bool tu, bool we, bool th, bool fr)
        {
            List<semester> tempSemesters = new List<semester>();
            Random rnd = new Random();
            int no_of_generations = 0;
            int repetitions = 0;
            while (no_of_generations < 50 && repetitions < 20000)
            {

                List<sectionSchedule> one_semester = new List<sectionSchedule>();

                for (int k = 0; k <= (one_semester_courses.Count()-1); k++)
                {
                    int i = k;
                    Course tempCourese = one_semester_courses[i];
                    Section tempLecture = null;
                    Section tempTutorial = null;
                    if (one_semester_courses[i].getLectures().Count() > 0)
                    {
                        tempLecture = one_semester_courses[i].getLectures()[rnd.Next(one_semester_courses[i].getLectures().Count())];

                        if (tempLecture.getTutorials().Count() > 0)
                            tempTutorial = tempLecture.getTutorials()[rnd.Next(tempLecture.getTutorials().Count())];
                    }
                    one_semester.Add(new sectionSchedule(tempCourese, tempLecture, tempTutorial));
                }


                repetitions++;
                bool works = true;
                for (int k = 0; k <= (one_semester.Count() -1) ; k++)
                {
                    int i = k;
                    for (int l = 0; l <= (one_semester.Count() - 1) && i != l; l++)
                    {
                        int j = l;
                        if (sectionOverLap(one_semester[i].getLecture(), one_semester[j].getLecture()) || sectionOverLap(one_semester[i].getTutorial(), one_semester[j].getTutorial()) ||
                            sectionOverLap(one_semester[i].getLecture(), one_semester[j].getTutorial()) || sectionOverLap(one_semester[i].getTutorial(), one_semester[j].getLecture()))
                        {
                            works = false; break;
                        }


                    }
                }

                if (works)
                {
                    semester temp = new semester();
                    foreach(sectionSchedule sect in one_semester)
                    {
                        temp.addLecture(sect.getLecture());
                        temp.addTutorials(sect.getTutorial());
                    }
                    tempSemesters.Add(temp);
                    no_of_generations++;
                }
              
            }

            int bestSemesterScore = 0;
            semester bestSemester = null;

            foreach (semester tempsemester in tempSemesters)
            {
                int semesterscore = 0;

               // Console.WriteLine("\n\nNew Semester\n\n");
                foreach(Section lec in tempsemester.getLectures())
                {
                    if (lec!= null)
                    {
                        semesterscore = semesterscore + getSectionScore(lec, morning, night, mo, tu, we, th, fr);
                    }
                }
                
                foreach(Section tut in tempsemester.getTuts())
                {
                    if (tut != null)
                    {
                        semesterscore = semesterscore + getSectionScore(tut, morning, night, mo, tu, we, th, fr);
                    }
                }
               
                //Console.WriteLine("\nnew semester score: ");
                //Console.WriteLine(semesterscore);
                if (semesterscore >= bestSemesterScore)
                {
                    bestSemesterScore = semesterscore;
                    bestSemester = tempsemester;
                }
            }

            return bestSemester;

        }




        private static int getSectionScore(Section section, bool morning, bool night, bool mo, bool tu, bool we, bool th, bool fr)
        {
            string temptime = "12:00:00";
            //DateTime temp = new DateTime("12:00:00");
            int score = 0;
            if(section != null)
            {
                if (section.getDay().Contains("Mo"))
                {
                    if (mo)
                        score++;
                }
                if (section.getDay().Contains("Tu"))
                {
                    if (tu)
                        score++;
                }
                if (section.getDay().Contains("We"))
                {
                    if (we)
                        score++;
                }
                if (section.getDay().Contains("Th"))
                {
                    if (th)
                        score++;
                }
                if (section.getDay().Contains("Fr"))
                {
                    if (fr)
                        score++;
                }
                if(DateTime.Compare( section.getEndDateTime(), Convert.ToDateTime(temptime)) < 0  )
                {
                    if (morning)
                        score++;
                }
                else
                {
                    if (night)
                        score++;
                }
                if (DateTime.Compare(section.getStartDateTime(), Convert.ToDateTime(temptime)) < 0)
                {
                    if (morning)
                        score++;
                }
                else
                {
                    if (night)
                        score++;
                }

            }
           // Console.WriteLine(score);
            return score;
        }


        private static bool sectionOverLap(Section first, Section second)
        {
            
            if (first != null && second != null)
            {
                bool samedays = false;
                if (first.getDay().Contains("Mo") && second.getDay().Contains("Mo"))
                { samedays = true;  }
                if (first.getDay().Contains("Tu") && second.getDay().Contains("Tu"))
                { samedays = true; }
                if (first.getDay().Contains("We") && second.getDay().Contains("We"))
                { samedays = true; }
                if (first.getDay().Contains("Th") && second.getDay().Contains("Th"))
                { samedays = true;  }
                if (first.getDay().Contains("Fr") && second.getDay().Contains("Fr"))
                { samedays = true;  }

                if (samedays)
                {
                    if (DateTime.Compare(first.getStartDateTime(), second.getEndDateTime()) <= 0 && DateTime.Compare(second.getStartDateTime(), first.getEndDateTime()) <= 0)
                    {  return true; }
                    else
                    {  return false; }
                }
                else
                    return false;
            }
            else
                return false;

        }
    }
}

