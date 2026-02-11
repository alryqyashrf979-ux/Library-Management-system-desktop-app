using DataAccessLibSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BooksDataAccessLib
{
    public class clsPhone_NumberDataAccessLib
    {
        static public bool Find(int PhoneId, ref int MemberID, ref string Phone_Number)
        {
            string Query = "select * from Phone_Numbers where Phone_NumberID =@PhoneId";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                connection.Open();
                command.Parameters.Add("@PhoneId", SqlDbType.Int).Value = PhoneId;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MemberID = (int)reader["MemberID"];
                    Phone_Number = (string)reader["Phone_Number"];
                    return true;
                }
                return false;

            }
        }

        static public int AddPhoneNumber(int MemberID, string Phone_Number)
        {
            string Query = "INSERT INTO Phone_Numbers\r\n(\r\n " +
                "     MemberID,\r\n   Phone_Number\r\n)\r\n" +
                "VALUES\r\n(\r\n" +
                "     @MemberID,\r\n    @Phone_Number\r\n   );\r\n\r\nSELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.Add("@MemberID", System.Data.SqlDbType.Int).Value = MemberID;
                command.Parameters.Add("@Phone_Number", System.Data.SqlDbType.NVarChar).Value = Phone_Number;
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    return NewID;
                }
                return -1;
            }
        }

        static public bool UpdatePhoneNummber(int ID, int MemberID, string Phone_Number)
        {
            string Query = "Update Phone_Numbers " +
                "set MemberID =@MemberID ," +
                "Phone_Number = @Phone_Number " +
                "where Phone_NumberID =@ID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = ID;
                command.Parameters.Add("@MemberID", System.Data.SqlDbType.Int).Value = MemberID;
                command.Parameters.Add("@Phone_Number", System.Data.SqlDbType.Int).Value = Phone_Number;
                connection.Open();
                return (command.ExecuteNonQuery() > 0);
            }
        }

        static public bool DeletePhoneNumber(int Id)
        {

            string Query = "Delete from Phone_Numbers where Phone_NumberID =@Id ";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                connection.Open();
                return (command.ExecuteNonQuery() > 0);
            }
        }

        static public DataTable GetAllPhone_Numbers()
        {
            DataTable dt = new DataTable();
            string Query = "Select * from Phone_Numbers ";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            return dt;
        }

        static public bool DoesPhoneNumberExist(int ID)
        {
            string Query = "select Phone_NumberID from Phone_Numbers where Phone_NumberID =@ID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                connection.Open();
                object Result = command.ExecuteScalar();
                return (Result != null ? true : false);
            }
        }

        static public bool DoesPhoneNumberExist(string PhoneNumber)
        {
            {
                string Query = "select FineID from Fines where Phone_Number like %" + PhoneNumber + "%;";
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    return (Command.ExecuteScalar() != null);
                }
            }
        }
    }
}
