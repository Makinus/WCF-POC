using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DeparmentCRUD
{
    public class DepartmentService : IDepartmentService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        public string InsertORUpdateDepartmentDetails(DeparmentDetails deparmentDetails)
        {
            string Message;
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT Count(*) FROM DepartmentDetails where DepartmentCode= '" + deparmentDetails.DepartmentCode + "' AND DepartmentId != " + deparmentDetails.DepartmentId + " ", con);
                int transactionCount = Convert.ToInt32(comm.ExecuteScalar());
                if (transactionCount > 0)
                {
                    Message = deparmentDetails.DepartmentCode + " already exists";
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("sp_AddorUpdateDepartmentDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentId", deparmentDetails.DepartmentId);
                    cmd.Parameters.AddWithValue("@DepartmentCode", deparmentDetails.DepartmentCode);
                    cmd.Parameters.AddWithValue("@DepartmentName", deparmentDetails.DepartmentName);
                    cmd.Parameters.AddWithValue("@IsActive", deparmentDetails.IsActive);
                    cmd.ExecuteNonQuery();
                    Message = deparmentDetails.DepartmentCode + " details updated successfully";
                }
                con.Close();
            }
            catch(Exception ex)
            {
                Message = "Details not updated successfully : " + ex.ToString();
            }
            return Message;
        }
        public List<DeparmentDetails> GetDepartments()
        {
            List<DeparmentDetails> deparmentDetails = new List<DeparmentDetails>();
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_GetDepartmentDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DepartmentCode", "");
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DeparmentDetails deparmentDetail = new DeparmentDetails();
                        deparmentDetail.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                        deparmentDetail.DepartmentCode = Convert.ToString(reader["DepartmentCode"]);
                        deparmentDetail.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                        deparmentDetail.IsActive = Convert.ToInt32(reader["IsActive"]);
                        deparmentDetails.Add(deparmentDetail);
                    }
                    return deparmentDetails.ToList();
                }
            }
            catch(Exception ex)
            {
                return deparmentDetails;
            }
            
        }
        public DeparmentDetails GetDepartmentByID(string departmentCode)
        {
            DeparmentDetails deparmentDetails = new DeparmentDetails();
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_GetDepartmentDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DepartmentCode", departmentCode);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        deparmentDetails.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                        deparmentDetails.DepartmentCode = Convert.ToString(reader["DepartmentCode"]);
                        deparmentDetails.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                        deparmentDetails.IsActive = Convert.ToInt32(reader["IsActive"]);
                    }
                }
                return deparmentDetails;
            }
            catch(Exception ex)
            {
                return deparmentDetails;
            }
        }

        public List<DeparmentDetails> GetDepartmentBySearch(string searchValue)
        {
            List<DeparmentDetails> deparmentDetailsBySearch = new List<DeparmentDetails>();
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_GetDepartmentDetailsBySearch", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SearchValue", searchValue);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DeparmentDetails deparmentDetail = new DeparmentDetails();
                        deparmentDetail.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                        deparmentDetail.DepartmentCode = Convert.ToString(reader["DepartmentCode"]);
                        deparmentDetail.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                        deparmentDetail.IsActive = Convert.ToInt32(reader["IsActive"]);
                        deparmentDetailsBySearch.Add(deparmentDetail);
                    }
                    return deparmentDetailsBySearch.ToList();
                }
            }
            catch(Exception ex)
            {
                return deparmentDetailsBySearch;
            }
        }
    }
}

