// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;
using Day_3;

public class Program
{
    public void fun1()
    {
        Console.WriteLine("Func1");
    }
    public void fun2()
    {
        Console.WriteLine("Func2");
    }

    public delegate void Del();
    public static void Main()
    {
        //delegators
        Program obj = new Program();
        Del del = new Del(obj.fun1);
        del();
        del();
        del += obj.fun2;
        del();
        del();
        //Each employee has the following properties: Name, Age, Department, and Salary
        List<EmployeeManagement> employees = new List<EmployeeManagement> {
        new EmployeeManagement { Name = "Fatema", Age = 21, Department = "HR", Salary = 50000 },
        new EmployeeManagement { Name = "Janvi", Age = 32, Department = "Sales", Salary = 30000 },
        new EmployeeManagement { Name = "Abhinav", Age = 35, Department = "HR", Salary = 20000 },
        new EmployeeManagement { Name = "Dipen", Age = 28, Department = "Sales", Salary = 35000 },
        new EmployeeManagement { Name = "Rishabh", Age = 29, Department = "IT", Salary = 45000 },
        new EmployeeManagement { Name = "Khusali", Age = 35, Department = "IT", Salary = 45000 },
        };

        //Displaying all employees 
        Console.WriteLine("Displaying all Employees:");
        employees.ForEach(emp => Console.WriteLine($"Name = {emp.Name}, Age = {emp.Age}, Department = {emp.Department}, Salary = {emp.Salary}"));

        //Filter the employees who are older than 30 years.
        var FilteredEmployees = employees.Where(emp => emp.Age > 30).ToList();
        Console.WriteLine("\n Displaying employees who are older than 30 years: ");

        FilteredEmployees.ForEach(emp=> Console.WriteLine($"Name = {emp.Name}, Age = {emp.Age}, Department = {emp.Department}, Salary = {emp.Salary}"));

        //Sort the employees by their Salary in descending order.
        var SortEmployees = employees.OrderByDescending(emp => emp.Salary).ToList();
        Console.WriteLine("\n Displaying employees by their Salary in descending order: ");

        SortEmployees.ForEach(emp=> Console.WriteLine($"Name = {emp.Name}, Age = {emp.Age}, Department = {emp.Department}, Salary = {emp.Salary}"));

        //Transform the list of employees into a list of employee names who are working in the "Sales" department.

        var SalesEmployees = employees.Where(emp => emp.Department == "Sales").ToList();
        Console.WriteLine("\n employee names who are working in the \"Sales\" departmen");

        SalesEmployees.ForEach(emp => Console.WriteLine($"Name = {emp.Name}, Age = {emp.Age}, Department = {emp.Department}, Salary = {emp.Salary}"));

    }
}
