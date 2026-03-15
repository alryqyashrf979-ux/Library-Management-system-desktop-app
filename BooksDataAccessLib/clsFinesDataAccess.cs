using DataAccessLibSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BooksDataAccessLib
{
    public class clsFinesDataAccess
    {
        static public bool FindByBorrowingID(  int BorrowingID ,ref int FineID, ref bool IsPaid
      , ref string PaymentMethod , ref decimal PaymentAmount , ref short LateDays)
        {
            string Query = "select * from Fines where BorrowingID =@BorrowingID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                connection.Open();
                command.Parameters.Add("@BorrowingID", SqlDbType.Int).Value = BorrowingID;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    FineID = (int)reader["FineID"];
                    IsPaid = (bool)reader["IsPaid"];
                    PaymentMethod = (reader["PaymentMethod"] == DBNull.Value ? "" : (string)reader["PaymentMethod"]);
                    PaymentAmount = (decimal)reader["PaymentAmount"];
                    LateDays = (short)reader["LateDays"];

                    return true;
                }
                return false;

            }
        }

        static public int AddFine(int BorrowingID, bool IsPaid, decimal PaymentAmount ,short LateDays)
        {
            string Query = " INSERT INTO Fines (BorrowingID, IsPaid, PaymentAmount, LateDays)" +
                "Values (@BorrowingID , @IsPaid , @PaymentMethod ,@LateDays) ; select SCOPE_IDENTITY();" ;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@BorrowingID",SqlDbType.Int).Value = BorrowingID ;
                command.Parameters.Add("@IsPaid", SqlDbType.Bit).Value = IsPaid; 
                command.Parameters.Add("@PaymentAmount", SqlDbType.Decimal).Value = PaymentAmount;
                command.Parameters.Add("@LateDays", SqlDbType.SmallInt).Value = LateDays;
                connection.Open();
                return  (int)command.ExecuteScalar();
            }
        }
        static public bool UpdateFineRecord(int FineID, int BorrowingID, bool IsPaid, string PaymentMethod,decimal PaymentAmount, short LateDays)
        {
            string Query = "Update Fines " +
                "set BorrowingID = @BorrowingID," +
                "IsPaid =@IsPaid," +
                "PaymentMethod =@PaymentMethod ," +
                "PaymentAmount = @PaymentAmount ," +
                "LateDays = @LateDays " +
                " where FineID =@FineID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@FineID", System.Data.SqlDbType.Int).Value = FineID;
               
                command.Parameters.Add("@BorrowingID", System.Data.SqlDbType.Int).Value = BorrowingID;
                command.Parameters.Add("@IsPaid", System.Data.SqlDbType.Bit).Value = IsPaid;
                if (string.IsNullOrEmpty(PaymentMethod))
                    command.Parameters.Add("@PaymentMethod", System.Data.SqlDbType.NVarChar).Value = DBNull.Value;
                else
                    command.Parameters.Add("@PaymentMethod", System.Data.SqlDbType.NVarChar).Value = PaymentMethod;  
                command.Parameters.Add("@PaymentAmount", System.Data.SqlDbType.Decimal).Value = PaymentAmount;
                command.Parameters.Add("@LateDays", System.Data.SqlDbType.SmallInt).Value = LateDays;
                connection.Open();
                return (command.ExecuteNonQuery() > 0);
            }
        }

        static public bool DeleteFineRecord(int Id)
        {

            string Query = "Delete from Fines where FineID =@Id ";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                connection.Open();
                return (command.ExecuteNonQuery() > 0);
            }
        }

        static public DataTable GetAllFineRecords()
        {
            DataTable dt = new DataTable();
            string Query = "\r\nselect M.Name as Member_Name , M.MemberCardID ,B.ArabicName as Book_Arabic_Title , B.EnglishName Book_English_Title  ," +
                " \r\nBR.BorrowingDate , F.LateDays , F.PaymentAmount from Fines F\r\ninner join BorrowingRecords BR on F.BorrowingID = BR.ID" +
                "\r\ninner join Members M on M.MemberID = BR.MemberID\r\ninner join Books B on B.BookID = BR.BookID ";
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

        static public bool DoesFineRecordExist(int ID)
        {
            string Query = "select borrowingID from Fines where borrowingID =@ID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                connection.Open();
                object Result = command.ExecuteScalar();
                return (Result != null ? true : false);
            }
        }

        static public void UpdatePaymentsAndLateDaysForAllFines()
        {
            string Query = "UPDATE F\r\nSET LateDays = DATEDIFF(DAY, B.ReturningDate, GETDATE()),\r\n " +
                "   PaymentAmount = 5 * DATEDIFF(DAY, B.ReturningDate, GETDATE())\r\nFROM Fines F\r\n" +
                "INNER JOIN BorrowingRecords B \r\nON B.ID = F.BorrowingID;";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
                  command.ExecuteNonQuery() ;
            }
        }


    }
}
