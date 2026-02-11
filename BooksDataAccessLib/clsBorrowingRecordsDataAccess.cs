using DataAccessLibSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BooksDataAccessLib
{
    public class clsBorrowingRecordsDataAccess
    {
        static public bool Find(int Id, ref int MemberID, ref int  BookID, ref bool status
            , ref DateTime BorrowingDate)
        {
            string Query = "select * from BorrowingRecords where ID =@Id";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                connection.Open();
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MemberID = (int)reader["MemberID"];
                    BookID = (int)reader["BookID"];
                    BorrowingDate = (DateTime)reader["BorrowingDate"];
                    status = (bool)reader["status"];
                   
                    return true;
                }
                return false;

            }
        }
     
        static public int AddBorrowing(int MemberID, int BookID, bool status, DateTime BorrowingDate)
        {
            string Query = "INSERT INTO BorrowingRecords\r\n(\r\n " +
                "   Status,\r\n    MemberID,\r\n    BookID,\r\n    BorrowingDate\r\n)\r\n" +
                "VALUES\r\n(\r\n" +
                "    @status,\r\n    @MemberID,\r\n    @BookID,\r\n    @BorrowingDate\r\n);\r\n\r\nSELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@status", System.Data.SqlDbType.Bit).Value = status;
                command.Parameters.Add("@MemberID", System.Data.SqlDbType.Int).Value = MemberID;
                command.Parameters.Add("@BookID", System.Data.SqlDbType.Int).Value = BookID;
                command.Parameters.Add("@BorrowingDate", System.Data.SqlDbType.SmallDateTime).Value = BorrowingDate;
            
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    return NewID;
                }
                return -1;
            }
        }

        static public bool UpdateBorrowingRecord(int ID, int MemberID, int BookID, bool status, DateTime BorrowingDate)
        {
            string Query = "Update BorrowingRecords " +
                "set MemberID =@MemberID ," +
                "BookID = @BookID," +
                "status =@status," +
                "BorrowingDate =@BorrowingDate " +
                "where ID =@ID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = ID;
                command.Parameters.Add("@MemberID", System.Data.SqlDbType.Int).Value = MemberID;
                command.Parameters.Add("@BookID", System.Data.SqlDbType.Int).Value = BookID;
                command.Parameters.Add("@status", System.Data.SqlDbType.Bit).Value = status;
                command.Parameters.Add("@BorrowingDate", System.Data.SqlDbType.SmallDateTime).Value = BorrowingDate;
                connection.Open();
                return (command.ExecuteNonQuery() > 0);
            }
        }

        static public bool DeleteBorrowingRecord(int Id)
        {

            string Query = "Delete from BorrowingRecords where ID =@Id ";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                connection.Open();
                return (command.ExecuteNonQuery() > 0);
            }
        }

        static public DataTable GetAllBorrowingRecords()
        {
            DataTable dt = new DataTable();
            string Query = "Select * from BorrowingRecords ";
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

        static public bool DoesBorrowingRecordExist(int ID)
        {
            string Query = "select ID from BorrowingRecords where ID =@ID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query,connection))
            {
                command.Parameters.Add("@ID",SqlDbType.Int).Value = ID;
                connection.Open();
                object Result = command.ExecuteScalar();
                return (Result != null ? true : false); 
                    
            }
        }

      
    }
}

