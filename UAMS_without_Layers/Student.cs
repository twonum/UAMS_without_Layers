using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5_lab_challange1
{

    public class Student
    {
        public string name;
        public int age;
        public double fsc_marks;
        public double ecat_marks;
        public double merit;
        public List<DegreeProgram> preferences;
        public List<Subject> regSubject;
        public DegreeProgram regDegree;
        public Student(string name, int age, double fscMarks, double ecatMarks, List<DegreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.fsc_marks = fscMarks;
            this.ecat_marks = ecatMarks;
            this.preferences = preferences;
            regSubject = new List<Subject>();
        }
        public void calculateMerit()
        {
            merit = (((fsc_marks / 1100) * 0.45f) + ((ecat_marks / 400) * 0.55f)) * 100;
        }
        public int getCreditHours()
        {
            int ch = 0;
            foreach (Subject item in regSubject)
            {
                ch += item.creditHours;
            }
            return ch;
        }
        public int calculateFee()
        {
            int fees = 0;
            foreach (Subject item in regSubject)
            {
                fees += item.subjectFees;
            }
            return fees;
        }
        public static void view_students()
        {
            foreach (Student student in Program.studentList)
            {
                if (student.regDegree != null)
                {
                    Console.WriteLine(student.name + " got admission in " + student.regDegree.degreeName);
                }
                else
                {
                    Console.WriteLine(student.name + " did not get admission in " + student.regDegree.degreeName);

                }
            }
            Console.ReadKey();
        }

        public bool reg_student_subject(Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null &&
            regDegree.isSubjectExists(s) && stCH +
            s.creditHours <= 9)
            {
                regSubject.Add(s);
                Console.WriteLine("Added");
                return true;
            }
            else
            {
                Console.WriteLine("A student cannot have more than 9 CH or Wrong Subject");
                return false;
            }
        }
        public static void view_fee()
        {
            foreach (Student item in Program.studentList)
            {
                Console.WriteLine(item.name + " has to Pay " + item.calculateFee() + "rs Fee");
                Console.ReadKey();
            }
        }
        public static List<Student> sort_students_acc_to_merit()
        {
            List<Student> myList = new List<Student>();
            foreach (Student student in Program.studentList)
            {
                student.calculateMerit();
            }
            myList = Program.studentList.OrderByDescending(o => o.merit).ToList();
            return myList;
        }
        public static void whom_to_give_admission(List<Student> myList)
        {
            foreach (Student student in myList)
            {
                foreach (DegreeProgram p in student.preferences)
                {
                    if (p.seats > 0 && student.regDegree == null)
                    {
                        student.regDegree = p;
                        int seats = p.seats;
                        seats--;
                        p.set_noOf_seats(seats);
                        break;
                    }
                }
            }
        }

    }



}