using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day_2
{
    public class Exam
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public string Subject { get; set; }
        public int Marks { get; set; }

        public Exam(int examId, int studentId, string subject, int marks)
        {
            ExamId = examId;
            StudentId = studentId;
            Subject = subject;
            Marks = marks;
        }
    }
}
