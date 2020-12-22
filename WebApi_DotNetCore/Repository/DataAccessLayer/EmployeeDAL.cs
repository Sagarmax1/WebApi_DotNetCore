using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApi_DotNetCore.Modal;

namespace WebApi_DotNetCore.Repository.DataAccessLayer
{
    public class EmployeeDAL
    {

        string ConnectionString = "Server=localhost; user=root; password=Path@123; Database=employeedb";

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                List<Employee> employee = new List<Employee>();
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("Usp_GetEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee emp = new Employee();

                        emp.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                        emp.EmployeeName = Convert.ToString(rdr["EmployeeName"]);
                        emp.Department = Convert.ToString(rdr["Department"]);
                        emp.MailID = Convert.ToString(rdr["MailID"]);
                        emp.DOJ = Convert.ToDateTime(rdr["DOJ"]);

                        employee.Add(emp);
                    }

                    con.Close();
                }

                return employee;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string CreateEmployee(Employee emp)
        {
            try
            {
                DataTable table = new DataTable();

                // string doj = emp.DOJ.ToString().Split('')[0];

                string query = @" insert into employees(EmployeeName,Department,MailID,DOJ)
                                  values('" + emp.EmployeeName + @"',
                                         '" + emp.Department + @"',
                                         '" + emp.MailID + @"',
                                         '" + Convert.ToDateTime(emp.DOJ).ToString("yyyy-MM-dd") + @"')";

                // string query = "Usp_EmployeeInsert";

                //  using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using (var con = new MySqlConnection(ConnectionString))
                using (var cmd = new MySqlCommand(query, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;

                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("EmployeeName",emp.EmployeeName);
                    //cmd.Parameters.AddWithValue("Department", emp.Department);
                    //cmd.Parameters.AddWithValue("MailID", emp.MailID);
                    //cmd.Parameters.AddWithValue("DOJ",);

                    da.Fill(table);
                }
                return "Added Successfully";
            }
            catch (Exception )
            {

                return "Failed to Add";
            }
        }

        public string EditEmployee(Employee emp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @" update employees set
                                  EmployeeName = '" + emp.EmployeeName + @"', 
                                  Department = '" + emp.Department + @"',
                                  MailID = '" + emp.MailID + @"',
                                  DOJ = '" + Convert.ToDateTime(emp.DOJ).ToString("yyyy-MM-dd") + @"'
                                  where EmployeeID = " + emp.EmployeeID + @"
                                ";


                //string query = "Usp_EmployeeInsert";

                // using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using (var con = new MySqlConnection(ConnectionString))
                using (var cmd = new MySqlCommand(query, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;

                    //cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("EmployeeName",emp.EmployeeName);
                    //cmd.Parameters.AddWithValue("Department", emp.Department);
                    //cmd.Parameters.AddWithValue("MailID", emp.MailID);
                    //cmd.Parameters.AddWithValue("DOJ",);

                    da.Fill(table);
                }
                return "Udpated Successfully";
            }
            catch (Exception )
            {

                return "Failed to Update";
            }
        }

        public string DeleteEmployee(int id)
        {
            try
            {
                DataTable table = new DataTable();

                //string query = @" delete from employees 
                //                  where EmployeeID = " + id;

                string query = "Usp_EmployeeDelete";

                // using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using (var con = new MySqlConnection(ConnectionString))
                using (var cmd = new MySqlCommand(query, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    // cmd.CommandType = CommandType.Text;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("e_EmployeeID", id);

                    da.Fill(table);
                }
                return "Delete Successfully";
            }
            catch (Exception)
            {

                return "Failed to Delete";
            }
        }


    }
}
