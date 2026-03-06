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
            , ref DateTime BorrowingDate , ref DateTime ReturningDate)
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
                    ReturningDate = (DateTime)reader["ReturningDate"];
                    return true;
                }
                return false;

            }
        }
     
        static public int AddBorrowing(int MemberID, int BookID, bool status, DateTime BorrowingDate , DateTime ReturningDate)
        {
            string Query = "INSERT INTO BorrowingRecords\r\n(\r\n " +
                "   Status,\r\n    MemberID,\r\n    BookID,\r\n    BorrowingDate , ReturningDate\r\n)\r\n" +
                "VALUES\r\n(\r\n" +
                "    @status,\r\n    @MemberID,\r\n    @BookID,\r\n    @BorrowingDate , @ReturningDate\r\n);\r\n\r\nSELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@status", System.Data.SqlDbType.Bit).Value = status;
                command.Parameters.Add("@MemberID", System.Data.SqlDbType.Int).Value = MemberID;
                command.Parameters.Add("@BookID", System.Data.SqlDbType.Int).Value = BookID;
                command.Parameters.Add("@BorrowingDate", System.Data.SqlDbType.SmallDateTime).Value = BorrowingDate;
                command.Parameters.Add("@ReturningDate", System.Data.SqlDbType.SmallDateTime).Value = ReturningDate;
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    return NewID;
                }
                return -1;
            }
        }

        static public bool UpdateBorrowingRecord(int ID, int MemberID, int BookID, bool status, DateTime BorrowingDate , DateTime ReturningDate)
        {
            string Query = "Update BorrowingRecords " +
                "set MemberID =@MemberID ," +
                "BookID = @BookID," +
                "status =@status," +
                "BorrowingDate =@BorrowingDate ," +
                "ReturningDate =@ReturningDate " +
                "where ID =@ID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = ID;
                command.Parameters.Add("@MemberID", System.Data.SqlDbType.Int).Value = MemberID;
                command.Parameters.Add("@BookID", System.Data.SqlDbType.Int).Value = BookID;
                command.Parameters.Add("@status", System.Data.SqlDbType.Bit).Value = status;
                command.Parameters.Add("@BorrowingDate", System.Data.SqlDbType.SmallDateTime).Value = BorrowingDate;
                command.Parameters.Add("@ReturningDate", System.Data.SqlDbType.SmallDateTime).Value = ReturningDate;
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
            string Query = "select ID as Record_ID , Members.membercardID as Member_Card_ID ,members.Name as Member_Name, Books.ArabicName as Arabic_Book_Name , " +
"Books.EnglishName as English_Book_Name , BorrowingDate as Borrowing_Date , ReturningDate as Return_Before , " +
 "status as IsReturned from BorrowingRecords " +
"inner join Members on Members.MemberID = BorrowingRecords.MemberID " +
" inner join Books on Books.BookID = BorrowingRecords.BookID ";
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
        static public DataTable FilterAndSearchForRecord(int memberID , bool Status )
        {
            DataTable dt = new DataTable();
            string Query =
"SELECT  " +
    "ID AS Record_ID , " +
  "  Members.MemberCardID AS Member_Card_ID,           " +
  "  Members.Name AS Member_Name,                      " +
 "   Books.ArabicName AS Arabic_Book_Name,             " +
   " Books.EnglishName AS English_Book_Name,           " +
  "  BorrowingDate AS Borrowing_Date,                  " +
  "  ReturningDate AS Return_Before,                   " +
 "   Status AS IsReturned                              " +
" FROM BorrowingRecords                                " +
" INNER JOIN Members                                   " +
 "   ON Members.MemberID = BorrowingRecords.MemberID   " +
" INNER JOIN Books                                     " +
 "   ON Books.BookID = BorrowingRecords.BookID         " +
" WHERE Members.MemberID = @memberID and BorrowingRecords.Status = @Status;";
            

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@memberID",SqlDbType.Int).Value=memberID;
                command.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                    dt.Load(reader);
            }
            return dt;
        }
        static public DataTable SearchForRecord(int memberID)
        {
            DataTable dt = new DataTable();
            string Query =
"SELECT  " +
    "ID AS Record_ID , " +
  "  Members.MemberCardID AS Member_Card_ID,           " +
  "  Members.Name AS Member_Name,                      " +
 "   Books.ArabicName AS Arabic_Book_Name,             " +
   " Books.EnglishName AS English_Book_Name,           " +
  "  BorrowingDate AS Borrowing_Date,                  " +
  "  ReturningDate AS Return_Before,                   " +
 "   Status AS IsReturned                              " +
" FROM BorrowingRecords                                " +
" INNER JOIN Members                                   " +
 "   ON Members.MemberID = BorrowingRecords.MemberID   " +
" INNER JOIN Books                                     " +
 "   ON Books.BookID = BorrowingRecords.BookID         " +
" WHERE Members.MemberID = @memberID ;";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@memberID", SqlDbType.Int).Value = memberID;
              
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }
            return dt;
        }
        static public DataTable FilterRecordsByStatus(bool Status )
        {
            DataTable dt = new DataTable();
            string Query =
"SELECT  " +
    "ID AS Record_ID , " +
  "  Members.MemberCardID AS Member_Card_ID,           " +
  "  Members.Name AS Member_Name,                      " +
 "   Books.ArabicName AS Arabic_Book_Name,             " +
   " Books.EnglishName AS English_Book_Name,           " +
  "  BorrowingDate AS Borrowing_Date,                  " +
  "  ReturningDate AS Return_Before,                   " +
 "   Status AS IsReturned                              " +
" FROM BorrowingRecords                                " +
" INNER JOIN Members                                   " +
 "   ON Members.MemberID = BorrowingRecords.MemberID   " +
" INNER JOIN Books                                     " +
 "   ON Books.BookID = BorrowingRecords.BookID         " +
" WHERE BorrowingRecords.Status = @Status ;";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
              
                command.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }
            return dt;
        }

        //static public bool ReturnABook(int BorrowingRecordID,int BookID)
        //{
        //    bool Result = false;
        //    string Query1 = "update BorrowingRecords\r\nset status = 1\r\nwhere ID = @BorrowingRecordID";
        //    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
        //        using (SqlCommand Cmd = new SqlCommand(Query1,connection))
        //    {
        //        Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = BorrowingRecordID;
        //        connection.Open();
        //        Result = ( Convert.ToInt32(Cmd.ExecuteNonQuery()) >= 1 );

        //     }
        //    if (Result == false)
        //        return false;
        //    else
        //    {
        //        string Query2 = "update Books\r\nset Quantity = Quantity + 1 \r\nwhere BookID = @BookID";
        //        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
        //        using (SqlCommand Cmd = new SqlCommand(Query2, connection))
        //        {
        //            Cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = BorrowingRecordID;
        //            connection.Open();
        //            return (Convert.ToInt32(Cmd.ExecuteNonQuery()) >= 1) ;
        //        }
        //    }
        //}
    }
}

