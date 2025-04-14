using System.Collections.Generic;
using System.Linq;

namespace _321_Code_Demo
{
    public class GpaReportBuilder
    {
        public double BuildGpa(List<double> grades)
        {
            if (grades.Count == 0) return 0;
            return grades.Average() / 25.0;
        }
    }
}