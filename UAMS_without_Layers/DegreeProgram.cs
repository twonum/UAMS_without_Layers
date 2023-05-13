using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5_lab_challange1
{
    public class DegreeProgram
    {
        public string degreeName;
        public float degreeDuration;
        public int seats;
        public int no_of_subject_offered;
        public List<Subject> subjects;

        public DegreeProgram(string degreeName, float degreeDuration, int seats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.seats = seats;
            subjects = new List<Subject>();
        }
        public void set_noOf_seats(int seats)
        {
            this.seats = seats;
        }

        public static List<Student> Students = new List<Student>();

        public List<Student> view_enrolled_students()
        {
            List<Student> enrolled_Students = new List<Student>();
            foreach (Student student in Students)
            {
                if (student.regDegree == this)
                {
                    enrolled_Students.Add(student);
                }
            }
            return enrolled_Students;
        }

        public int calculateCreditHours()
        {
            int ch = 0;
            foreach (Subject item in subjects)
            {
                ch += item.creditHours;

            }
            return ch;
        }
        public bool isSubjectExists(Subject sub)
        {
            Subject s = subjects.Find(e => e.type == sub.type);
            if (s != null)
            {
                return true;
            }

            return false;
        }
        public void AddSubject(Subject sub)
        {
            int creditHours = calculateCreditHours();
            if (creditHours + sub.creditHours
            <= 20)
            {
                if (!isSubjectExists(sub))
                {
                    subjects.Add(sub);
                    Console.WriteLine("Subject Added.");
                }
                else
                {
                    Console.WriteLine("Subject Already exists! ");
                }
            }
            else
            {
                Console.WriteLine("20 Credit Hours limit exceeded !");
            }
        }

        public void Add_Student(Student student)
        {
            student.regDegree = this;
            Students.Add(student);
        }

        public List<Subject> view_Subjects()
        {
            return subjects;
        }

    }
}