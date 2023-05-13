using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5_lab_challange1
{
    public class Subject
    {
        public int code;
        public string type;
        public int creditHours;
        public int subjectFees;
        public Subject(int code, string type,
        int creditHours, int subjectFees)
        {
            this.code = code;
            this.type = type;
            this.creditHours = creditHours;
            this.subjectFees = subjectFees;
        }

        public int return_Code()
        {
            return code;
        }
        public static void register_subject(Student student)
        {
            Console.WriteLine("Enter the no of Subjects U want to Register: ");
            int counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("Enter the subject Code");
                int code = int.Parse(Console.ReadLine());
                bool flag = false;
                foreach (Subject sub in student.regDegree.subjects)
                {
                    if (code == sub.return_Code() && !(student.regSubject.Contains(sub)))
                    {
                        if (student.reg_student_subject(sub) == true)
                        {
                            flag = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Credit Hours of a Student should be less than \"9\" !!");
                            flag = true;
                            break;
                        }
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("InValid Course!!");
                    i--;
                }
            }
        }
        public static void viewSubjects(Student sub)
        {
            foreach (Subject subject in sub.regDegree.subjects)
            {
                Console.WriteLine(subject.type + "\t\t" + subject.code + "\t\t" + subject.subjectFees);
            }
        }
    }
}