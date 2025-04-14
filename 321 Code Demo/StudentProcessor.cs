using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _321_Code_Demo
{
    public class StudentProcessor
    {
        private readonly string _filePath;
        private XDocument _doc;
        private readonly StudentGpaWorkflowManager _workflow;

        public StudentProcessor(string filePath)
        {
            _filePath = filePath;
            _workflow = new StudentGpaWorkflowManager();
            _doc = new XDocument();
        }

        public void LoadStudents()
        {
            _doc = XDocument.Load(_filePath);
        }

        public void SaveStudents()
        {
            _doc.Save(_filePath);
            Console.WriteLine("Saved.");
        }

        public void AddStudent(string name)
        {
            var students = _doc.Element("Students");
            if (students != null && students.Elements("Student").Any(s => s.Attribute("name")!.Value == name))
            {
                Console.WriteLine("Student already exists.");
                return;
            }

            students!.Add(new XElement("Student",
                new XAttribute("name", name),
                new XElement("Assignment", new XAttribute("grade", "0"))));

            Console.WriteLine("Student added.");
        }

        public void RemoveStudent(string name)
        {
            var student = _doc.Descendants("Student").FirstOrDefault(s => s.Attribute("name")!.Value == name);

            if (student != null)
            {
                student.Remove();
                Console.WriteLine("Student removed.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void UpdateGrades(string name)
        {
            var student = _doc.Descendants("Student").FirstOrDefault(s => s.Attribute("name")!.Value == name);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            var assignments = student.Elements("Assignment").ToList();
            student.Elements("Assignment").Remove();

            Console.Write("How many assignments? ");
            if (!int.TryParse(Console.ReadLine(), out int count))
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Grade #{i + 1}: ");
                string? gradeInput = Console.ReadLine();

                if (double.TryParse(gradeInput, out double grade))
                {
                    student.Add(new XElement("Assignment", new XAttribute("grade", grade)));
                }
                else
                {
                    Console.WriteLine("Invalid input. Skipped.");
                }
            }

            Console.WriteLine("Grades updated.");
        }

        public void PrintGpas()
        {
            var students = _doc.Descendants("Student");

            foreach (var student in students)
            {
                string name = student.Attribute("name")!.Value;
                var grades = student.Elements("Assignment")
                                    .Select(a => double.Parse(a.Attribute("grade")!.Value))
                                    .ToList();

                double gpa = _workflow.ExecuteGpaWorkflow(name, grades);
                Console.WriteLine($"{name}'s GPA: {gpa:F2}");
            }
        }
    }
}