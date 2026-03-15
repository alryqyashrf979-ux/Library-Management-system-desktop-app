using DataAccessLibSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BooksDataAccessLib
{
    public class clsReservationsDataAccessLayer
    {
        static public bool Find(int Id, ref int MemberID, ref int BookID
        , ref DateTime ReservationDate, ref bool Availibilty)
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
                    Availibilty = (bool)reader["Availibilty"];

                    return true;
                }
                return false;
            }
        }
        static public int AddReservation(int MemberID, int BookID, DateTime ReservationDate, bool Availibilty)
        {
            string Query = "INSERT INTO Reservations\r\n(\r\n " +
                "     MemberID,\r\n    BookID,\r\n    ReservationDate,\r\n Availibilty )\r\n" +
                "VALUES\r\n(\r\n" +
                "        @MemberID,\r\n    @BookID,\r\n    @ReservationDate ,\r\n @Availibilty );\r\n\r\nSELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@MemberID", System.Data.SqlDbType.Int).Value = MemberID;
                command.Parameters.Add("@BookID", System.Data.SqlDbType.Int).Value = BookID;
                command.Parameters.Add("@ReservationDate", System.Data.SqlDbType.SmallDateTime).Value = ReservationDate;
                command.Parameters.Add("@Availibilty", System.Data.SqlDbType.Bit).Value = Availibilty;
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    return NewID;
                }
                return -1;
            }
        }

        static public bool UpdateReservation(int ID, int MemberID, int BookID, DateTime ReservationDate, bool Availibilty)
        {
            string Query = "Update Reservations " +
                "set MemberID =@MemberID ," +
                "BookID = @BookID," +
                "ReservationDate =@ReservationDate  ," +
                "Availibilty = @Availibilty " +
                "where ReservationID =@ID ";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = ID;
                command.Parameters.Add("@MemberID", System.Data.SqlDbType.Int).Value = MemberID;
                command.Parameters.Add("@BookID", System.Data.SqlDbType.Int).Value = BookID;
                command.Parameters.Add("@ReservationDate", System.Data.SqlDbType.SmallDateTime).Value = ReservationDate;
                command.Parameters.Add("@Availibilty", System.Data.SqlDbType.Bit).Value = Availibilty;
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
            string Query = "select Reservations.ReservationID  as Reservation_ID ," +
                " Books.ArabicName as Book_Arabic_Name ,Books.EnglishName as Book_English_Name\r\n,Members.MemberCardID as Member_Card_ID" +
                " , Reservations.ReservationDate as Reservation_Date , reservations.Availibilty as Is_Availible \r\n" +
                "from Reservations inner join Books on Books.BookID = Reservations.BookID" +
                " \r\ninner join Members on Members.MemberID = Reservations.MemberID ";
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
        static public DataTable SearchForReservation(int memberID)
        {
            DataTable dt = new DataTable();
            string Query = "select Reservations.ReservationID  as Reservation_ID ," +
                                      " Books.ArabicName as Book_Arabic_Name ,Books.EnglishName as Book_English_Name\r\n,Members.MemberCardID as Member_Card_ID" +
                                      " , Reservations.ReservationDate as Reservation_Date , reservations.Availibilty as Is_Availible \r\n" +
                                      "from Reservations inner join Books on Books.BookID = Reservations.BookID" +
                                      " \r\ninner join Members on Members.MemberID = Reservations.MemberID " +
                                      "where Reservations.MemberID = @memberID";

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
        static public DataTable FilterAndSearchForReservationsByAvailibilty(int memberID, bool Availibilty)
        {
            DataTable dt = new DataTable();
            string Query = "select Reservations.ReservationID  as Reservation_ID ," +
                           " Books.ArabicName as Book_Arabic_Name ,Books.EnglishName as Book_English_Name\r\n,Members.MemberCardID as Member_Card_ID" +
                           " , Reservations.ReservationDate as Reservation_Date , reservations.Availibilty as Is_Availible \r\n" +
                           "from Reservations inner join Books on Books.BookID = Reservations.BookID" +
                           " \r\ninner join Members on Members.MemberID = Reservations.MemberID " +
                           "where Reservations.MemberID = @memberID and Reservations.Availibilty = @Availibilty ";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.Add("@memberID", SqlDbType.Int).Value = memberID;

                command.Parameters.Add("@Availibilty", SqlDbType.Bit).Value = Availibilty;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }
            return dt;
        }
        static public DataTable FilterByAvailibilty(bool Availibilty)
        {
            DataTable dt = new DataTable();
            string Query = "select Reservations.ReservationID  as Reservation_ID ," +
                           " Books.ArabicName as Book_Arabic_Name ,Books.EnglishName as Book_English_Name\r\n,Members.MemberCardID as Member_Card_ID" +
                           " , Reservations.ReservationDate as Reservation_Date , reservations.Availibilty as Is_Availible \r\n" +
                           "from Reservations inner join Books on Books.BookID = Reservations.BookID" +
                           " \r\ninner join Members on Members.MemberID = Reservations.MemberID " +
                           "where  Reservations.Availibilty = @Availibilty ";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {



                command.Parameters.Add("@Availibilty", SqlDbType.Bit).Value = Availibilty;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }
            return dt;
        }
        static public int Count()
        {
            string Query = "select count(*) from Reservations ";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand commmand = new SqlCommand(Query, connection))
            {
                connection.Open();
                object Result = commmand.ExecuteScalar();
                return (Result != null) ? Convert.ToInt32(Result) : 0;

            }
        }
        static public bool UpdateReservationAvailibilty()
        {
            string Query = "UPDATE R\r\nSET R.Availibilty = 1\r\nFROM Reservations R" +
                "\r\nINNER JOIN Books B ON R.BookID = B.BookID\r\nWHERE B.Quantity > 0;";
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand commmand = new SqlCommand(Query, conn))
            {
                conn.Open();
                return (bool)(commmand.ExecuteNonQuery() > 0);
            }

        }
    }
}
