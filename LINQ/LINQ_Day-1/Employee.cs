using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day_1
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        private double salary;
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public DateTime JoiningDate { get; set; }


        public Employee(int id, string name, string department, double salary, DateTime joiningDate)
        {
            Id = id;
            Name = name;
            Department = department;
            Salary = salary;
            JoiningDate = joiningDate;
        }
    }

}
