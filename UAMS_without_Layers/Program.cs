using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EZInput;
using static week5_lab_challange1.DegreeProgram;
using static week5_lab_challange1.Student;
using static week5_lab_challange1.Subject;

namespace week5_lab_challange1
{
    class Program
    {


        public static List<Student> studentList = new List<Student>();
        static List<DegreeProgram> programList = new List<DegreeProgram>();
        public static void Main(string[] args)
        {
            string option;
            do
            {
                option = Menu();
                Console.Clear();
                if (option == "1")
                {
                    if (programList.Count > 0)
                    {
                        Student s = takeInputForStudent();

                    }
                    else
                    {
                        Console.WriteLine("Add DegreeProgram fisrt ! ...");
                        Console.ReadKey();
                    }
                }
                else if (option == "2")
                {
                    DegreeProgram degree = takeInputForDegree();
                    programList.Add(degree);
                }
                else if (option == "3")
                {
                    Console.Clear();
                    List<Student> sorted_Students_List = new List<Student>();
                    sorted_Students_List = Student.sort_students_acc_to_merit();
                    Student.whom_to_give_admission(sorted_Students_List);
                    Student.view_students();
                }
                else if (option == "4")
                {
                    Console.Clear();
                    Registered_Students(DegreeProgram.Students);
                    Console.ReadKey();
                }
                else if (option == "5")
                {
                    Console.Clear();
                    specificStudents(programList);
                }
                else if (option == "6")
                {
                    Console.Clear();
                    Console.Write("Enter Student name: ");
                    string name = Console.ReadLine();
                    Student student = DegreeProgram.Students.Find(e => e.name == name);
                    if (student != null)
                    {
                        Subject.viewSubjects(student);
                        Subject.register_subject(student);

                    }
                }
                else if (option == "7")
                {
                    Student.view_fee();
                }
                Console.Clear();

            } while (option != "8");
            Console.Write("Thank You for using UMS...! ");
            Console.ReadKey();
        }
        static string Menu()
        {
            Console.Clear();
            print_header();
            Console.WriteLine("\n1)Add Student");
            Console.WriteLine("2)Add Degree Program");
            Console.WriteLine("3)Generate Merit List");
            Console.WriteLine("4)View Registered Students");
            Console.WriteLine("5)View Students of Specific Program");
            Console.WriteLine("6)Register Subjects for a Specific Student");
            Console.WriteLine("7)Calculate Fees for all Registered Students");
            Console.WriteLine("8)Exit");
            Console.Write("Option--> ");
            string option = Console.ReadLine();
            return option;
        }
        static void print_header()
        {
            Console.Clear();
            Console.WriteLine("******************************************************");
            Console.WriteLine("                         UAMS                         ");
            Console.WriteLine("******************************************************");
        }

        public static DegreeProgram takeInputForDegree()
        {
            Console.WriteLine("Enter Degree Name: ");
            string degree_name = Console.ReadLine();
            Console.WriteLine("Enter Duration: ");
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Seats for this Degree: ");
            int seats = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter No of Subjects Offered in the Degree: ");
            int no_of_subjects = int.Parse(Console.ReadLine());

            DegreeProgram obj = new DegreeProgram(degree_name, duration, no_of_subjects);
            for (int i = 0; i < no_of_subjects; i++)
            {
                Subject sub = InputForSubject();
                obj.subjects.Add(sub);
            }
            return obj;
        }
        public static Student takeInputForStudent()
        {
            Console.Clear();
            Console.WriteLine("Enter Student Name: ");
            string student_name = Console.ReadLine();
            Console.WriteLine("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Fsc Marks: ");
            int fsc_marks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ecat Marks: ");
            int ecat_marks = int.Parse(Console.ReadLine());

            Console.WriteLine("Available Degree Programs:");
            for (int i = 0; i < programList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {programList[i].degreeName}");
            }

            Console.WriteLine("Enter Preferences to Select : ");
            int no_of_preferences = int.Parse(Console.ReadLine());
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            for (int i = 0; i < no_of_preferences; i++)
            {
                Console.WriteLine($"Enter Preference no { i + 1}:");
                string name_of_preference = Console.ReadLine();

                DegreeProgram degree_name = programList.Find(d => d.degreeName == name_of_preference);
                if (degree_name != null)
                {
                    preferences.Add(degree_name);
                }
                else
                {
                    Console.WriteLine("In Degree programs \'" + name_of_preference + "\' not found!");
                }

            }
            Student s = new Student(student_name, age, fsc_marks, ecat_marks, preferences);
            foreach (DegreeProgram degree in preferences)
            {
                if (degree.seats > 0)
                {
                    degree.Add_Student(s);
                    studentList.Add(s);
                }
            }
            return s;

        }

        static void specificStudents(List<DegreeProgram> programs)
        {
            Console.WriteLine("Enter Degree Name: ");
            string name = Console.ReadLine();
            DegreeProgram degree = programs.Find(e => e.degreeName == name);
            if (degree != null)
            {
                Console.WriteLine("Name\t\tAge\t\tFsc Marks\t\tEcat Marks");
                foreach (Student student in degree.view_enrolled_students())
                {
                    Console.WriteLine(student.name + "\t" + student.age + "\t" + student.fsc_marks + "\t" + student.ecat_marks);
                }
            }
            Console.ReadKey();
        }

        static Subject InputForSubject()
        {
            Console.WriteLine("Enter Subject Code: ");
            int code = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Subject Type: ");
            string type = (Console.ReadLine());
            Console.WriteLine("Enter Credit Hours for this Subject: ");
            int credit_hours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Fees for this Subject: ");
            int fee = int.Parse(Console.ReadLine());
            Subject obj = new Subject(code, type, credit_hours, fee);
            return obj;
        }

        static void Registered_Students(List<Student> students)
        {
            Console.WriteLine("Name\t\tAge\t\tFsc Marks\t\tEcat Marks");
            foreach (Student student in students)
            {
                Console.WriteLine(student.name + "\t" + student.age + "\t" + student.fsc_marks + "\t" + student.ecat_marks);
            }
            Console.ReadKey();
        }
    }
}