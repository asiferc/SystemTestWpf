using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SystemTestWpf.Model;

namespace SystemTestWpf.DataAccessLayer
{
    public class DatabaseLayer
    {
        public static List<User> GetEmployeeFromDatabase()
        {
            try
            {
                DataTable dt = GetDataFromDb();
                var Employee = new List<User>();
                foreach (DataRow row in dt.Rows)
                {
                    var obj = new User()
                    {
                        EmployeeID = (int)row["EmployeeID"],
                        FirstName = (string)row["FirstName"],
                        LastName = (string)row["LastName"],
                        DOB = (DateTime)row["BirthDate"],
                        Address = (string)row["Address"]
                    };
                    Employee.Add(obj);
                }
                return Employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static DataTable GetDataFromDb()
        {
            DataTable dt = new DataTable();
            try
            {
                string constring = @"data source =DESKTOP-L245TTP;
            initial catalog = northwnd; persist security info = True;
            Integrated Security = SSPI;";
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        internal static void InsertEmployee(User employee)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[8];
                MyParams[0] = new SqlParameter("@ID", employee.EmployeeID);
                MyParams[1] = new SqlParameter("@FirstName", employee.FirstName);
                MyParams[2] = new SqlParameter("@LastName", employee.LastName);
                MyParams[4] = new SqlParameter("@DOB", employee.DOB);
                MyParams[7] = new SqlParameter("@Address", employee.Address);
                //SqlHelper.ExecuteNonQuery(AppConstants.getConnectionString(), CommandType.StoredProcedure, "[dbo].[uspInsertUser]", MyParams);
                MessageBox.Show("Data Saved Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        internal static void UpdateEmployee(User employee)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[8];
                MyParams[0] = new SqlParameter("@ID", employee.EmployeeID);
                MyParams[1] = new SqlParameter("@FirstName", employee.FirstName);
                MyParams[2] = new SqlParameter("@LastName", employee.LastName);
                MyParams[4] = new SqlParameter("@DOB", employee.DOB);
                MyParams[7] = new SqlParameter("@Address", employee.Address);
                //SqlHelper.ExecuteNonQuery(AppConstants.getConnectionString(), CommandType.StoredProcedure, "[dbo].[uspInsertUser]", MyParams);
                MessageBox.Show("Data Updated Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        internal static void DeleteEmployee(User employee)
        {
            try
            {
                SqlParameter[] MyParams = new SqlParameter[1];
                MyParams[0] = new SqlParameter("@ID", employee.EmployeeID);
                //SqlHelper.ExecuteNonQuery(AppConstants.getConnectionString(), CommandType.StoredProcedure, "[dbo].[uspDeletetUser]", MyParams);
                MessageBox.Show("Data Deleted Successfully.");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        
    }
}
