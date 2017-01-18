using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static DevIQ.NewInCSharpSixDemo.Demos.Student;

namespace DevIQ.NewInCSharpSixDemo.Demos
{
    public class StudentRecords
    {
        private Dictionary<int, Student> studentDictionary = 
            new Dictionary<int, Student> 
            { 
                [DefaultStudent.StudentId] = DefaultStudent 
            };
        public void EnrollNewStudent(Student student)
        {
            studentDictionary.Add(student.StudentId, student);
        }

        public string GetStudentNameById(int studentId)
        {
            return studentDictionary?[studentId]?.FullName ?? NotFoundName;
        }

        public Student GetStudentById(int studentId)
        {
            if (studentDictionary.ContainsKey(studentId))
            {
                return studentDictionary[studentId] ?? DefaultStudent;
            }
            return DefaultStudent;
        }

        public List<Student> GetAllStudents()
        {
            return studentDictionary.Select(s => s.Value).Except(new [] {DefaultStudent}).ToList();
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }

        public static Student DefaultStudent = new Student { StudentId = 0, FullName = "Default Student" };
        public static string NotFoundName = "Student Name Not Found";
    }

    public class InLineCodeImprovements
    {
        public static void RunDemo()
        {
            var studentRecords = new StudentRecords();

            studentRecords.EnrollNewStudent(new Student{ StudentId = 1, FullName = "Brendan Enrick" });
            studentRecords.EnrollNewStudent(new Student{ StudentId = 2, FullName = "Steve Smith" });
            studentRecords.EnrollNewStudent(new Student{ StudentId = 3 });

            WriteLine("Students Enrolled:\n");
            foreach (var student in studentRecords.GetAllStudents())
            {
                WriteLine($"{student.StudentId} - {studentRecords.GetStudentNameById(student.StudentId)}");
            }
            var missingStudent = studentRecords.GetStudentById(4);
            WriteLine($"{missingStudent.StudentId} - {studentRecords.GetStudentNameById(missingStudent.StudentId)}");
            WriteLine("\n");
        }
    }
}