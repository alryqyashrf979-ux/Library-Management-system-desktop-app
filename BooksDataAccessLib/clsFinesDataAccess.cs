using DataAccessLibSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDataAccessLib
{
    public class clsFinesDataAccess
    {
        static public bool Find(int fineID, ref int MemberID, ref int BorrowingID, ref bool IsPaid
      , ref string PaymentMethod , ref decimal PaymentAmount , ref short LateDays)
        {
            string Query = "select * from Fines where FineID =@fineID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                connection.Open();
                command.Parameters.Add("@fineID", SqlDbType.Int).Value = fineID;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MemberID = (int)reader["MemberID"];
                    BorrowingID = (int)reader["BorrowingID"];
                    IsPaid = (bool)reader["IsPaid"];
                    PaymentMethod = (reader["PaymentMethod"] == DBNull.Value ? "" : (string)reader["PaymentMethod"]);
                    PaymentAmount = (decimal)reader["PaymentAmount"];
                    LateDays = (short)reader["LateDays"];

                    return true;
                }
                return false;

            }
        }

        static public int AddFine(int MemberID, int BorrowingID, bool IsPaid, string PaymentMethod , decimal PaymentAmount,short LateDays)
        {
            string Query = "INSERT INTO Fines \r\n(\r\n " +
                "   MemberID,\r\n    BorrowingID,\r\n    IsPaid,\r\n    PaymentMethod, PaymentAmount , LateDays\r\n)\r\n" +
                "VALUES\r\n(\r\n" +
                "    @MemberID,\r\n    @BorrowingID,\r\n    @IsPaid,\r\n    @PaymentMethod , @PaymentAmount ,@LateDays\r\n);\r\n\r\nSELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@IsPaid", System.Data.SqlDbType.Bit).Value = IsPaid;
                command.Parameters.Add("@MemberID", System.Data.SqlDbType.Int).Value = MemberID;
                command.Parameters.Add("@BorrowingID", System.Data.SqlDbType.Int).Value = BorrowingID;
                if(string.IsNullOrEmpty(PaymentMethod))
                    command.Parameters.Add("@PaymentMethod", System.Data.SqlDbType.NVarChar).Value = DBNull.Value;
                else
                    command.Parameters.Add("@PaymentMethod", System.Data.SqlDbType.NVarChar).Value = PaymentMethod;
                command.Parameters.Add("@LateDays", System.Data.SqlDbType.SmallInt).Value = LateDays;
                command.Parameters.Add("@PaymentAmount",SqlDbType.Decimal).Value = PaymentAmount;
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    return NewID;
                }
                return -1;
            }
        }

        static public bool UpdateFineRecord(int FineID,int MemberID, int BorrowingID, bool IsPaid, string PaymentMethod,decimal PaymentAmount, short LateDays)
        {
            string Query = "Update Fines " +
                "set MemberID =@MemberID ," +
                "BorrowingID = @BorrowingID," +
                "IsPaid =@IsPaid," +
                "PaymentMethod =@PaymentMethod ," +
                "PaymentAmount = @PaymentAmount ," +
                "LateDays = @LateDays " +
                " where FineID =@FineID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@FineID", System.Data.SqlDbType.Int).Value = FineID;
                command.Parameters.Add("@MemberID", System.Data.SqlDbType.Int).Value = MemberID;
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
            string Query = "Select * from Fines ";
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
            string Query = "select FineID from Fines where FineID =@ID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                connection.Open();
                object Result = command.ExecuteScalar();
                return (Result != null ? true : false);

            }
        }

    }
}
