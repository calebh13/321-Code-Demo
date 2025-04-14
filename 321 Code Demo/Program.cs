using System;

namespace _321_Code_Demo
{
    class Program
    {
        static void Main()
        {
            var processor = new StudentProcessor("student_assignments.xml");
            processor.LoadStudents();

            while (true)
            {
                Console.WriteLine("\n1. Add Student\n2. Remove Student\n3. Update Grades\n4. View GPA\n5. Save\n6. Exit");
                Console.Write("Choose: ");
                var input = Console.ReadLine();
                string? name = null;

                switch (input)
                {
                    case "1":
                        Console.Write("Student name: ");
                        name = Console.ReadLine();
                        if (name != null) processor.AddStudent(name);
                        break;
                    case "2":
                        Console.Write("Student name: ");
                        name = Console.ReadLine();
                        if (name != null) processor.RemoveStudent(name);
                        break;
                    case "3":
                        Console.Write("Student name: ");
                        name = Console.ReadLine();
                        if (name != null) processor.UpdateGrades(name);
                        break;
                    case "4":
                        processor.PrintGpas();
                        break;
                    case "5":
                        processor.SaveStudents();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
        }
    }
}