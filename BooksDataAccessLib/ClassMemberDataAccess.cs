using DataAccessLibSettings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDataAccessLib
{
    public class clsMemberDataAccess
    {
        static public bool Find(int ID, ref string memberName, ref string memberCardID, ref string email, ref string occupation
            , ref DateTime birthday, ref int countryId)
        {
            string Query = "select * from Members where MemberID =@ID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                connection.Open();
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    memberName = (string)reader["Name"];
                    memberCardID = (string)reader["MemberCardID"];
                    email = (string)reader["Email"];
                    occupation = (string)reader["occupation"];
                    birthday = (DateTime)reader["Birthday"];
                    countryId = (byte)reader["CountryID"];
                    return true;
                }
                return false;

            }
        }
        static public bool Find(string memberName, ref int ID, ref string memberCardID, ref string email, ref string occupation
       , ref DateTime birthday, ref int countryId)
        {
            string Query = "select * from Members where Name =@memberName";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                connection.Open();
                command.Parameters.Add("@memberName", SqlDbType.NVarChar).Value = memberName;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ID = (int)reader["MemberID"];
                    memberCardID = (string)reader["MemberCardID"];
                    email = (string)reader["Email"];
                    occupation = (string)reader["occupation"];
                    birthday = (DateTime)reader["Birthday"];
                    countryId = (byte)reader["CountryID"];
                    return true;
                }
                return false;

            }
        }
        static public int AddMember(string MemberName, string MemberCardID, string Email, string Occupation
            , DateTime Birthday, int CountryId)
        {
            string Query = "insert into Members " +
                "values (@MemberName,@Email,@Birthday,@Occupation,@MemberCardID,@CountryId);" +
                "select Scope_Identity()";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@MemberName", System.Data.SqlDbType.NVarChar).Value = MemberName;
                command.Parameters.Add("@MemberCardID", System.Data.SqlDbType.NVarChar).Value = MemberCardID;
                command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value = Email;
                command.Parameters.Add("@Birthday", System.Data.SqlDbType.SmallDateTime).Value = Birthday;
                command.Parameters.Add("@Occupation", System.Data.SqlDbType.NVarChar).Value = Occupation;
                command.Parameters.Add("@CountryId", System.Data.SqlDbType.TinyInt).Value = CountryId;
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewID))
                {
                    return NewID;
                }
                return -1;
            }
        }

        static public bool UpdateMember(int ID, string memberName, string memberCardID, string email, string occupation
            , DateTime birthday, int countryId)
        {
            string Query = "Update Members " +
                "set Name =@memberName ," +
                "MemberCardID = @memberCardID," +
                "Email =@email," +
                "Occupation =@occupation," +
                "Birthday=@birthday," +
                "CountryID=@countryId " +
                "where MemberID =@ID";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = ID;
                command.Parameters.Add("@MemberName", System.Data.SqlDbType.NVarChar).Value = memberName;
                command.Parameters.Add("@MemberCardID", System.Data.SqlDbType.NVarChar).Value = memberCardID;
                command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value = email;
                command.Parameters.Add("@Birthday", System.Data.SqlDbType.SmallDateTime).Value = birthday;
                command.Parameters.Add("@Occupation", System.Data.SqlDbType.NVarChar).Value = occupation;
                command.Parameters.Add("@CountryId", System.Data.SqlDbType.TinyInt).Value = countryId;
                connection.Open();

                return (command.ExecuteNonQuery() > 0);
            }
        }

        static public bool DeleteMember(int memberId)
        {

            string Query = "Delete from Members where MemberID =@memberID ";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@memberID", SqlDbType.Int).Value = memberId;
                connection.Open();
                return (command.ExecuteNonQuery() > 0);
            }
        }

        static public DataTable GetAllMembers()
        {
            DataTable dt = new DataTable();
            string Query = "Select * from Members ";
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

        static public DataTable SortMembersByIDDesc()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select * from Members " +
                "order by MemberID Desc";
            SqlCommand Command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        static public DataTable SortMembersByIDAsc()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select * from Members " +
                "order by MemberID Asc";
            SqlCommand Command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        static public DataTable SortMembersByNameAsc()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select * from Members " +
                "order by Name Asc";
            SqlCommand Command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        static public DataTable SortBooksByNameDesc()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select * from Members " +
                "order by Name Desc";
            SqlCommand Command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        static public bool DoesMemberExist(int ID)
        {
            string Query = "select MemberID from Members where MemberID =@ID";
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
