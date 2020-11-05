using System;
using System.Data.SqlClient;

namespace EmployeePayrollService
{
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source=DESKTOP-1KFT47J\SQLEXPRESS;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (this.connection)
                {
                    string query = "Select * from employee_payroll";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            model.EmployeeID = dr.GetInt32(0);
                            model.EmployeeName = dr.GetString(1);
                            model.BasicPay = dr.GetDecimal(2);
                            model.StartDate = dr.GetDateTime(3);
                            model.Gender = Convert.ToChar(dr.GetString(4));
                            model.PhoneNumber = dr.GetString(5);
                            model.Address = dr.GetString(6);
                            model.Department = dr.GetString(7);
                            model.Deductions = dr.GetDecimal(8);
                            model.TaxablePay = dr.GetDecimal(9);
                            model.Tax = dr.GetDecimal(10);
                            model.NetPay = dr.GetDecimal(11);
                            Console.WriteLine(model.EmployeeName + " " + model.BasicPay + " " + model.StartDate + " " + model.Gender + " " + model.PhoneNumber + " " + model.Address + " " + model.Department + " " + model.Deductions + " " + model.TaxablePay + " " + model.Tax + " " + model.NetPay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
