namespace LINQ_Day_1
{
    //LINQ Day 1 Task
    //Select gets list of list while select many flattens the query and provides list.

    using System;


    public class EmployeeManagement
    {
        public static List<Employee> employees = new List<Employee>
    {
        new Employee(1, "Alice", "HR", 60000, new DateTime(2018, 5, 20)),
        new Employee(2, "Bob", "IT", 75000, new DateTime(2019, 7, 15)),
        new Employee(3, "Charlie", "Finance", 50000, new DateTime(2020, 3, 10)),
        new Employee(4, "David", "IT", 90000, new DateTime(2017, 6, 12)),
        new Employee(5, "Eve", "Marketing", 55000, new DateTime(2021, 8, 30)),
        new Employee(6, "Frank", "HR", 48000, new DateTime(2022, 1, 5)),
        new Employee(7, "Grace", "IT", 97000, new DateTime(2016, 2, 22)),
        new Employee(8, "Hank", "Finance", 52000, new DateTime(2019, 11, 3)),
        new Employee(9, "Ivy", "Marketing", 47000, new DateTime(2020, 4, 18)),
        new Employee(10, "Jack", "Sales", 68000, new DateTime(2018, 9, 7)),
        new Employee(11, "Karen", "HR", 51000, new DateTime(2015, 7, 9)),
        new Employee(12, "Leo", "IT", 62000, new DateTime(2023, 5, 19)),
        new Employee(13, "Mia", "Finance", 58000, new DateTime(2017, 10, 2)),
        new Employee(14, "Nathan", "Marketing", 60000, new DateTime(2021, 12, 5)),
        new Employee(15, "Olivia", "Sales", 75000, new DateTime(2016, 3, 14)),
        new Employee(16, "Peter", null, 50000, new DateTime(2019, 6, 25)),
        new Employee(17, "Quinn", "IT", 84000, new DateTime(2020, 7, 13)),
        new Employee(18, "Rachel", "Finance", 48000, new DateTime(2021, 10, 11)),
        new Employee(19, "Steve", "Sales", 56000, new DateTime(2019, 11, 20)),
        new Employee(20, "Tom", null, 45000, new DateTime(2022, 3, 28))
    };

        static EmployeeManagement()
        {
            Console.WriteLine("Welcome To Employee Management System");
            Console.WriteLine(".....................................");
        }

        public void EmployeeManagementQuery()
        {
            Console.WriteLine("\nLINQ Queries (Using Method & Query syntax)\n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");


            //Retrieve employees with a salary greater than 50,000 using both query syntax and method syntax.

            //Method Syntax
            Console.WriteLine("\nRetrieve employees with a salary greater than 50,000 using both query syntax and method syntax.");
            var filteredEmployeesMethod = employees.Where(emp => emp.Salary > 50000);

            Console.WriteLine("\nUsing Method Syntax:");
            foreach(var emp in filteredEmployeesMethod)
            {
                Console.WriteLine($"Id : {emp.Id} Name: {emp.Name} Department : {emp.Department} Salary : {emp.Salary} Joining Date : {emp.JoiningDate}");
            }

            //Query syntax
            var filteredEmployeesQuery = from emp in employees where emp.Salary > 50000 select emp;

            Console.WriteLine("\nUsing Query Syntax:");
            foreach(var emp in filteredEmployeesQuery)
            {
                Console.WriteLine($"Id : {emp.Id} Name: {emp.Name} Department : {emp.Department} Salary : {emp.Salary} Joining Date : {emp.JoiningDate}");
            }




            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------\n");

            //Retrieve employee names and salaries sorted by Department and then by Salary (descending)
            Console.WriteLine("Retrieve employee names and salaries sorted by Department and then by Salary (descending).\r\n");
            var sortedEmployees = employees.OrderBy(emp => emp.Department).ThenByDescending(emp => emp.Salary).Select(emp => new { emp.Name, emp.Department, emp.Salary });
            foreach (var emp in sortedEmployees)
            {
                Console.WriteLine(emp);
            }

            //Query Syntax
            var sortedEmployeesQry = from emp in employees
                                     orderby emp.Department, emp.Salary descending
                                     select new { emp.Name, emp.Department, emp.Salary };
            Console.WriteLine("\nusing Query Syntax\n");
            foreach (var emp in sortedEmployeesQry)
            {
                Console.WriteLine(emp);
            }


            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------\n");

            Console.WriteLine("Use Select to display employee names along with their joining year.\r\n");
            var EmployeesJoining = employees.Select(emp => new { emp.Name, emp.JoiningDate });
            foreach (var emp in EmployeesJoining)
            {
                Console.WriteLine(emp);
            }

            //Query Syntax 
            Console.WriteLine("\nusing Query Syntax\n");
            var EmployeesJoiningQry = from emp in employees
                                      select new { emp.Name, emp.JoiningDate };
            foreach (var emp in EmployeesJoiningQry)
            {
                Console.WriteLine(emp);
            }


            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------\n");

            Console.WriteLine("Find the total, minimum, and average salary of employees.\r\n");
            var totalSalary = employees.Sum(emp => emp.Salary);
            var MinimumSalary = employees.Min(emp => emp.Salary);
            var AverageSalary = employees.Average(emp => emp.Salary);
            Console.WriteLine($"Total salary: {totalSalary} , Minimum Salary ; {MinimumSalary} , Average Salary : {AverageSalary} ");

            //Query Syntax 
            Console.WriteLine("\nusing Query Syntax\n");
            var totalSalaryQry = (from emp in employees
                                  select emp.Salary).Sum();
            var MinimumSalaryQry = (from emp in employees
                                    select emp.Salary).Min();
            var AverageSalaryQry = (from emp in employees
                                    select emp.Salary).Average(); ;
            Console.WriteLine($"Total salary: {totalSalaryQry} , Minimum Salary ; {MinimumSalaryQry} , Average Salary : {AverageSalaryQry} ");



            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------\n");

            Console.WriteLine("Group employees by department and display all names in each department.\n");
            var GroupByDepartment = employees.GroupBy(emp => emp.Department);
            foreach (var group in GroupByDepartment)
            {
                Console.WriteLine($"Department : {group.Key}, Total employees in {group.Key} department :{group.Count()}");
                foreach (var emp in group)
                {
                    Console.WriteLine(emp.Name);
                }
            }

            //Query Syntax 
            Console.WriteLine("\nusing Query Syntax\n");
            var GroupByDepartmentQry = from emp in employees
                                       group emp by emp.Department;

            foreach (var group in GroupByDepartmentQry)
            {
                Console.WriteLine($"Department : {group.Key}, Total employees in {group.Key} department :{group.Count()}");
                foreach (var emp in group)
                {
                    Console.WriteLine(emp.Name);
                }
            }


            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------\n");

            Console.WriteLine("Find the department with the highest average salary.\n");
            var HighestAvegSalaryDept = employees.Where(emp => emp.Department != null).GroupBy(emp => emp.Department).Select(emp => new
            {
                Department = emp.Key,
                EmpAvgSalary = emp.Average(sal => sal.Salary)
            }).OrderByDescending(emp => emp.EmpAvgSalary).FirstOrDefault();

            Console.WriteLine($"Department with Highest Salary is  {HighestAvegSalaryDept.Department} with salary : {HighestAvegSalaryDept.EmpAvgSalary}");


            //Query Syntax 
            Console.WriteLine("\nusing Query Syntax\n");
            var HighestAvegSalaryDeptQry = (from emp in employees
                                            where emp.Department != null
                                            group emp by emp.Department into empgroup
                                            select new
                                            {
                                                Department = empgroup.Key,
                                                Salary = empgroup.Average(sal => sal.Salary)
                                            } into empselect
                                            orderby empselect.Salary descending
                                            select empselect).FirstOrDefault();

            Console.WriteLine($"Department with Highest Salary is  {HighestAvegSalaryDeptQry.Department} with salary : {HighestAvegSalaryDeptQry.Salary}");

            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------\n");

            Console.WriteLine("Retrieve employees who joined after 2020.\n");
            var EmployeeJoin2020 = employees.Where(emp => emp.JoiningDate > new DateTime(2020, 12, 31));
            foreach(var emp in EmployeeJoin2020)
            {
                Console.WriteLine($"Id : {emp.Id} Name: {emp.Name}  Joining Date : {emp.JoiningDate}");
            }

            //Query Syntax 
            Console.WriteLine("\nusing Query Syntax\n");
            var EmployeeJoin2020Qry = (from emp in employees
                                       where emp.JoiningDate > new DateTime(2020, 12, 31)
                                       select new { emp.Id, emp.Name, emp.JoiningDate });
            foreach(var emp in EmployeeJoin2020)
            {
                Console.WriteLine(emp);
            }


            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------\n");

            Console.WriteLine("Find the oldest and newest employee based on joining date.\n");
            var OldestEmp = employees.OrderBy(emp => emp.JoiningDate).FirstOrDefault();
            var NewestEmp = employees.OrderByDescending(emp => emp.JoiningDate).FirstOrDefault();

            Console.WriteLine($"\nOldest Employee of the Company : {OldestEmp.Name} with Joining Date : {OldestEmp.JoiningDate}");

            Console.WriteLine($"\nNewest Employee of the Company : {NewestEmp.Name} with Joining Date : {NewestEmp.JoiningDate}");

            //Query Syntax 
            Console.WriteLine("\nusing Query Syntax\n");
            var OldestEmpQry = (from emp in employees
                                orderby emp.JoiningDate
                                select emp).FirstOrDefault();

            var NewestEmpQry = (from emp in employees
                                orderby emp.JoiningDate descending
                                select emp).FirstOrDefault();

            Console.WriteLine($"\nOldest Employee of the Company : {OldestEmpQry.Name} with Joining Date : {OldestEmpQry.JoiningDate}");

            Console.WriteLine($"\nNewest Employee of the Company : {NewestEmpQry.Name} with Joining Date : {NewestEmpQry.JoiningDate}");



            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------\n");

            Console.WriteLine("Find the total salary paid in each department.\n");

            var SalaryByDept = employees.Where(emp => emp.Department != null).GroupBy(emp => emp.Department).Select(group => new { Department = group.Key, Salary = group.Sum(emp => emp.Salary) });

            foreach (var emp in SalaryByDept)
            {
                Console.WriteLine($"Department : {emp.Department} Total Salary : {emp.Salary}");
            }
            //Query Syntax 
            Console.WriteLine("\nusing Query Syntax\n");
            var SalaryByDeptQry = from emp in employees
                                  where emp.Department != null
                                  group emp by emp.Department into empgroup
                                  select new
                                  {
                                      Department = empgroup.Key,
                                      Salary = empgroup.Sum(emp => emp.Salary)
                                  };
            foreach (var emp in SalaryByDeptQry)
            {
                Console.WriteLine($"Department : {emp.Department} Total Salary : {emp.Salary}");
            }


            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------\n");

            Console.WriteLine("Get employees who have no department assigned (handling nullable values).\r\n");

            var EmpNoDepartment = employees.Where(emp => emp.Department == null);
            foreach(var emp in EmpNoDepartment)
            {
                Console.WriteLine(emp.Name);
            }
            //Query Syntax 
            Console.WriteLine("\nusing Query Syntax\n");
            var EmpNoDepartmentQry = (from emp in employees
                                      where emp.Department == null
                                      select emp);
            foreach(var emp in EmpNoDepartmentQry)
            {
                Console.WriteLine(emp.Name);
            }


            Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------\n");
        }

    }

}
