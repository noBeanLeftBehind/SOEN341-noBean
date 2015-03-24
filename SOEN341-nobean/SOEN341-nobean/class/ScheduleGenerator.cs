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

        public Schedule generate()
        {
            return studentSchedule;
        }
    }
}