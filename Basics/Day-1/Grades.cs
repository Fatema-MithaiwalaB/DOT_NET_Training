using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTasks
{
    public class Grades
    {
        //Write a program to assign grades based on a student's marks using the ternary operator.
        public void AssignGrades() {
            Console.WriteLine("Enter Marks between 0 to 100:");
            int marks = Convert.ToInt32(Console.ReadLine());
            string grade = (marks <= 100 && marks >= 90) ? "A" :
                            (marks < 90 && marks >= 70) ? "B" :
                            (marks < 70 && marks >= 50) ? "C" :
                            (marks < 50 && marks >= 40) ? "D" :
                            (marks < 40 && marks >= 35) ? "E" :
                            (marks < 35 && marks >= 0) ? "F" :
                            "not assigned as marks should be between 0 to 100!";
            Console.WriteLine($"The grades for the marks {marks} is {grade}");

        }
        
    }
}
