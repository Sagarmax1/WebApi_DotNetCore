using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi_DotNetCore.Modal;

namespace WebApi_DotNetCore.Repository.DataAccessLayer
{
    public class DepartmentDAL
    {
        string ConnectionString = "Server=localhost; user=root; password=Path@123; Database=employeedb";


        //public HttpResponseMessage getData1()
        //{
        //    DataTable table = new DataTable();
        //    //  string query = @" select DepartmentID ,DepartmentName from departments ";
        //    string query = "Usp_GetDipartment";

        //    // using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
        //    using (var con = new MySqlConnection(ConnectionString))
        //    using (var cmd = new MySqlCommand(query, con))
        //    using (var da = new MySqlDataAdapter(cmd))
        //    {
        //        //cmd.CommandType = CommandType.Text;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        da.Fill(table);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, table);
        //}


        
        public IEnumerable<Department> GetAll()
        {
            try
            {
                List<Department> department = new List<Department>();
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand("Usp_GetDipartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Department dep = new Department();

                        dep.DepartmentID = Convert.ToInt32(rdr["DepartmentID"]);
                        dep.DepartmentName = Convert.ToString(rdr["DepartmentName"]);

                        department.Add(dep);
                    }

                    con.Close();
                }

                return department;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string CreateDepartment(Department dep)
        {
            try
            {
                DataTable table = new DataTable();
                //  string query = @" insert into departments(DepartmentName) values('"+dep.DepartmentName + @"')";
                string query = "Usp_DipartmentInsert";

                //using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString))
                using (var con = new MySqlConnection(ConnectionString))
                //  using (MySqlConnection con = new MySqlConnection(ConnectionString))
                using (var cmd = new MySqlCommand(query, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    //cmd.CommandType = CommandType.Text;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("DepartmentName", dep.DepartmentName);
                    da.Fill(table);
                }
                return "Added Successfully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string EditDepartment(Department dep)
        {
            try
            {
                DataTable table = new DataTable();
                // string query = @" insert into departments(DepartmentName) values('"+dep.DepartmentName + @"')";
                string query = "Usp_Department_Update";

                // using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var con = new MySqlConnection(ConnectionString))
                using (var cmd = new MySqlCommand(query, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    // cmd.CommandType = CommandType.Text;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("d_DepartmentID", dep.DepartmentID);
                    cmd.Parameters.AddWithValue("d_DepartmentName", dep.DepartmentName);
                    da.Fill(table);
                }
                return "Updated Successfully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string DeleteDepartment(int id)
        {
            try
            {
                DataTable table = new DataTable();
                // string query = @" insert into departments(DepartmentName) values('"+dep.DepartmentName + @"')";
                string query = "Usp_Department_Delete";

                // using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var con = new MySqlConnection(ConnectionString))
                using (var cmd = new MySqlCommand(query, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    // cmd.CommandType = CommandType.Text;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("d_DepartmentID", id);
                    da.Fill(table);
                }
                return "Delete Successfully";
            }
            catch (Exception )
            {

                return "Failed to Delete";
            }
        }

    }
}
