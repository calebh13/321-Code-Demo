﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _321_Code_Demo
{
    public class Student
    {
        public string Name;
        public List<double> Grades;

        public Student()
        {
            Name = string.Empty;
            Grades = new List<double>();
        }

        public Student(string name, List<double> grades)
        {
            Name = name;
            Grades = grades;
        }
    }
}
