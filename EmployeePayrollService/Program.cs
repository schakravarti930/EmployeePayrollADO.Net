using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeRepo repo = new EmployeeRepo();
            repo.GetAllEmployee();
        }
    }
}
