﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day_2
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }

        public Student(int studentId, string name, string course)
        {
            StudentId = studentId;
            Name = name;
            Course = course;
        }
    }
}
