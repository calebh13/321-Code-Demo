using System;
using System.Collections.Generic;

namespace _321_Code_Demo
{
    public class StudentGpaWorkflowManager
    {
        public double ExecuteGpaWorkflow(Student student)
        {
            ValidateStudent(student);
            return ComputeGpa(student.Grades);
        }

        private void ValidateStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Name))
                throw new ArgumentException("Student name is required.");
        }

        private double ComputeGpa(List<double> grades)
        {
            return grades.Count == 0 ? 0 : grades.Average() / 25.0;
        }


        private void LogWorkflow(string name, List<double> grades)
        {
            Console.WriteLine($"[LOG] Calculating GPA for {name} ({grades.Count} grades).");
        }
    }
}