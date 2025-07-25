using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    // Student class with properties
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double CGPA { get; set; }
    }

    // Main class
    class Program
    {
        // List to store students
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine("===== Student Management System =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Search Student by ID");
                Console.WriteLine("4. Delete Student by ID");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                bool valid = int.TryParse(Console.ReadLine(), out choice);
                if (!valid)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        ViewStudents();
                        break;
                    case 3:
                        SearchStudent();
                        break;
                    case 4:
                        DeleteStudent();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

            } while (choice != 5);
        }

        // Add student
        static void AddStudent()
        {
            Student student = new Student();

            Console.Write("Enter ID: ");
            student.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Department: ");
            student.Department = Console.ReadLine();

            Console.Write("Enter CGPA: ");
            student.CGPA = double.Parse(Console.ReadLine());

            students.Add(student);

            Console.WriteLine("Student added successfully.");
        }

        // View all students
        static void ViewStudents()
        {
            Console.WriteLine("\nAll Students:");
            Console.WriteLine("------------------------------------------");

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Dept: {student.Department}, CGPA: {student.CGPA}");
            }
        }

        // Search student
        static void SearchStudent()
        {
            Console.Write("Enter Student ID to search: ");
            int id = int.Parse(Console.ReadLine());

            var student = students.Find(s => s.Id == id);

            if (student != null)
            {
                Console.WriteLine($"Found: ID={student.Id}, Name={student.Name}, Dept={student.Department}, CGPA={student.CGPA}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        // Delete student
        static void DeleteStudent()
        {
            Console.Write("Enter Student ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var student = students.Find(s => s.Id == id);

            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}

