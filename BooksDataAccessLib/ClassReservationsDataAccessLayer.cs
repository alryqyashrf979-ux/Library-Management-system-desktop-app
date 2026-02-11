using DataAccessLibSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDataAccessLib
{
    public class clsReservationsDataAccessLayer
    {
        static public bool Find(int Id, ref int MemberID, ref int BookID
        , ref DateTime ReservationDate)
        {
            string Query = "select * from Reservations where ReservationID =@Id";
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
                    ReservationDate = (DateTime)reader["ReservationDate"];
                    
                    return true;
                }

                return false;

            }
        }

        static public int AddReservation(int MemberID, int BookID, DateTime ReservationDate)
        {
            string Query = "INSERT INTO Reservations\r\n(\r\n " +
                "     MemberID,\r\n    BookID,\r\n    ReservationDate\r\n)\r\n" +
                "VALUES\r\n(\r\n" +
                "        @MemberID,\r\n    @BookID,\r\n    @ReservationDate\r\n);\r\n\r\nSELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
            
                command.Parameters.Add("@MemberID", System.Data.SqlDbType.Int).Value = MemberID;
                command.Parameters.Add("@BookID", System.Data.SqlDbType.Int).Value = BookID;
                command.Parameters.Add("@ReservationDate", System.Data.SqlDbType.SmallDateTime).Value = ReservationDate;

                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    return NewID;
                }
                return -1;
            }
        }

        static public bool UpdateReservation(int ID, int MemberID, int BookID, DateTime ReservationDate)
        {
            string Query = "Update Reservations " +
                "set MemberID =@MemberID ," +
                "BookID = @BookID," +
                "ReservationDate =@ReservationDate " +
                "where ReservationID =@ID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = ID;
                command.Parameters.Add("@MemberID", System.Data.SqlDbType.Int).Value = MemberID;
                command.Parameters.Add("@BookID", System.Data.SqlDbType.Int).Value = BookID;
                command.Parameters.Add("@ReservationDate", System.Data.SqlDbType.SmallDateTime).Value = ReservationDate;
                connection.Open();
                return (command.ExecuteNonQuery() > 0);
            }
        }
        static public bool DeleteReservation(int Id)
        {
            string Query = "Delete from Reservations where ReservationID =@Id ";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                connection.Open();
                return (command.ExecuteNonQuery() > 0);
            }
        }
        static public DataTable GetAllReservations()
        {
            DataTable dt = new DataTable();
            string Query = "Select * from Reservations ";
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
        static public bool DoesReservationExist(int ID)
        {
            string Query = "select ReservationID from Reservations where ReservationID =@ID";
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
