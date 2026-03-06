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
            , ref DateTime birthday, ref byte countryId, ref string PicPath, ref char Gender, ref bool IsDeleted)
        {
            string Query = "select * from Members where MemberID =@ID and IsDeleted = 0 ";
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
                    PicPath = (reader["PicPath"] == DBNull.Value) ? "" : (string)reader["PicPath"];
                    Gender =  ((string)reader["Gender"])[0];
                    IsDeleted = (bool)reader["IsDeleted"];
                    return true;
                }
                return false;

            }
        }
        static public bool Find(string memberName, ref int ID, ref string memberCardID, ref string email, ref string occupation
       , ref DateTime birthday, ref byte countryId,ref string PicPath ,ref char Gender , ref bool IsDeleted)
        {
            string Query = "select * from Members where Name =@memberName and IsDeleted = 0 ";
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
                    PicPath = (reader["PicPath"] == DBNull.Value) ? "" : (string)reader["PicPath"];
                    Gender = ((string)reader["Gender"])[0];
                    IsDeleted = (bool)reader["IsDeleted"];
                    return true;
                }
                return false;
            }
        }
        static public bool FindByCardID(ref string memberName, ref int ID, string memberCardID, ref string email, ref string occupation
  , ref DateTime birthday, ref byte countryId, ref string PicPath, ref char Gender , ref bool IsDeleted)
        {
            string Query = "select * from Members where MemberCardID like '%" +memberCardID+"%' and IsDeleted = 0 ";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
            
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ID = (int)reader["MemberID"];
                    memberCardID = (string)reader["MemberCardID"];
                    email = (string)reader["Email"];
                    occupation = (string)reader["occupation"];
                    birthday = (DateTime)reader["Birthday"];
                    countryId = (byte)reader["CountryID"];
                    PicPath = (reader["PicPath"] == DBNull.Value) ? "" : (string)reader["PicPath"];
                    Gender = ((string)reader["Gender"])[0];
                    IsDeleted = (bool)reader["IsDeleted"];
                    return true;
                }
                return false;
            }
        }
        static public int AddMember(string MemberName, string MemberCardID, string Email, string Occupation
            , DateTime Birthday, byte CountryId , string PicPath,char Gender,bool IsDeleted)
        {
            string Query = @"INSERT INTO Members
                 (Name, Email, Birthday, Occupation, MemberCardID, CountryId, PicPath,Gender , IsDeleted )
                 VALUES
                 (@MemberName, @Email, @Birthday, @Occupation, @MemberCardID, @CountryId, @PicPath,@Gender ,@IsDeleted);
                 SELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@MemberName", System.Data.SqlDbType.NVarChar).Value = MemberName;
                command.Parameters.Add("@MemberCardID", System.Data.SqlDbType.NVarChar).Value = MemberCardID;
                command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value = Email;
                command.Parameters.Add("@Birthday", System.Data.SqlDbType.SmallDateTime).Value = Birthday;
                command.Parameters.Add("@Occupation", System.Data.SqlDbType.NVarChar).Value = Occupation;
                command.Parameters.Add("@CountryId", System.Data.SqlDbType.TinyInt).Value = CountryId;
                command.Parameters.Add("@IsDeleted",System.Data.SqlDbType.Bit).Value = IsDeleted;

                if (Gender =='\0')
                {
                    command.Parameters.AddWithValue("@Gender", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Gender", PicPath);
                }

                command.Parameters.Add("@Gender", SqlDbType.Char).Value = Gender;
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
            , DateTime birthday, byte countryId ,string PicPath,char Gender)
        {
            string Query = "Update Members " +
                "set Name =@memberName ," +
                "MemberCardID = @memberCardID," +
                "Email =@email," +
                "Occupation =@occupation," +
                "Birthday=@birthday," +
                "CountryID=@countryId ," +
                "PicPath = @PicPath ," +
                "Gender = @Gender  " +
                "where MemberID =@ID ";
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
                if (PicPath == string.Empty)
                {
                    command.Parameters.AddWithValue("@PicPath", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@PicPath", PicPath);
                }

            
                
                    command.Parameters.Add("@Gender", SqlDbType.Char).Value= Gender;
               
                connection.Open();

                return (command.ExecuteNonQuery() > 0);
            }
        }

        static public bool DeleteMember(int memberId)
        {

            string Query = "update Members set IsDeleted = 1 where MemberID =@memberID ";
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
            string Query = "select MemberID ,Name ,Email,Birthday , Occupation , MemberCardID ,Countries.country   from Members inner join " +
                         "  Countries on Countries.CountryID = Members.CountryID " +
                         "where IsDeleted = 0 ";
                            
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

        //static public DataTable SortMembersByIDDesc()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
        //    string Query = "select * from Members " +
        //        "order by MemberID Desc";
        //    SqlCommand Command = new SqlCommand(Query, connection);
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader Reader = Command.ExecuteReader();
        //        if (Reader.HasRows)
        //        {
        //            dt.Load(Reader);
        //        }
        //        Reader.Close();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return dt;
        //}
        //static public DataTable SortMembersByIDAsc()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
        //    string Query = "select * from Members " +
        //        "order by MemberID Asc";
        //    SqlCommand Command = new SqlCommand(Query, connection);
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader Reader = Command.ExecuteReader();
        //        if (Reader.HasRows)
        //        {
        //            dt.Load(Reader);
        //        }
        //        Reader.Close();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return dt;
        //}
        //static public DataTable SortMembersByNameAsc()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
        //    string Query = "select * from Members " +
        //        "order by Name Asc";
        //    SqlCommand Command = new SqlCommand(Query, connection);
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader Reader = Command.ExecuteReader();
        //        if (Reader.HasRows)
        //        {
        //            dt.Load(Reader);
        //        }
        //        Reader.Close();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return dt;
        //}
        //static public DataTable SortBooksByNameDesc()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
        //    string Query = "select * from Members " +
        //        "order by Name Desc";
        //    SqlCommand Command = new SqlCommand(Query, connection);
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader Reader = Command.ExecuteReader();
        //        if (Reader.HasRows)
        //        {
        //            dt.Load(Reader);
        //        }
        //        Reader.Close();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return dt;
        //}
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
        static public DataTable SearchMemberByID(int ID)
        {
            {
                DataTable dt = new DataTable();
                string Query = "select MemberID ,Name ,Email,Birthday , Occupation , MemberCardID ,Countries.country   from Members inner join " +
                            "  Countries on Countries.CountryID = Members.CountryID"
                                + " where  Members.MemberID =@ID";
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        dt.Load(Reader);
                    }
                 
                }
                return dt;
            }
        }
        static public DataTable SearchMemberByName(string Name)
        {
            {
                DataTable dt = new DataTable();
                string Query = "select MemberID ,Name ,Email,Birthday , Occupation , MemberCardID ,Countries.country   from Members inner join " +
                         "  Countries on Countries.CountryID = Members.CountryID"
                             + " where  Members.Name like '%" + Name + "%' and IsDeleted = 0 ";
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    connection.Open();
                  
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        dt.Load(Reader);
                    }
                
                }
                return dt;
            }
        }
        static public DataTable SearchMemberByCardID(string CardID)
        {
            {
                DataTable dt = new DataTable();
                string Query = "select MemberID ,Name ,Email,Birthday , Occupation , MemberCardID ,Countries.country   from Members inner join " +
                            "  Countries on Countries.CountryID = Members.CountryID"
                                + " where  Members.MemberCardID = @CardID and IsDeleted = 0";
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@CardID", SqlDbType.NVarChar).Value = CardID;
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        dt.Load(Reader);
                    }
                 
                }
                return dt;
            }
        }
        static public DataTable SearchMemberByOccupation(string Occupation)
        {
            {
                DataTable dt = new DataTable();
                string Query = "select MemberID ,Name ,Email,Birthday , Occupation , MemberCardID ,Countries.country   from Members inner join " +
                          "  Countries on Countries.CountryID = Members.CountryID"
                              + " where  Members.Occupation like '%" + Occupation + "%' and IsDeleted =0 ";
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    connection.Open();
                   
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        dt.Load(Reader);
                    }
                  
                }
                return dt;
            }
        }
        static public DataTable SearchMemberByEmail(string Email)
        {
            {
                DataTable dt = new DataTable();
                string Query = "select MemberID ,Name ,Email,Birthday , Occupation , MemberCardID ,Countries.country   from Members inner join " +
                        "  Countries on Countries.CountryID = Members.CountryID"
                            + " where  Members.Email like '%"+Email+"%' and IsDeleted = 0 ";
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        dt.Load(Reader);
                    }
               
                }
                return dt;
            }
        }
        static public DataTable SearchMemberByCountryName(string Email)
        {
            {
                DataTable dt = new DataTable();
                string Query = "select MemberID ,Name ,Email,Birthday , Occupation , MemberCardID ,Countries.country   from Members inner join "+
                              "  Countries on Countries.CountryID = Members.CountryID"
                                  + " where Countries.country like '%"+Email+"%'and IsDeleted = 0 ";
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        dt.Load(Reader);
                    }
                }
                return dt;
            }
        }

        static public bool DoesMemberExist(string MemberCardID)
        {
            string Query = "select MemberID from Members where MemberCardID =@MemberCardID and IsDeleted = 0 ";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@MemberCardID", SqlDbType.NVarChar).Value = MemberCardID;
                connection.Open();
                object Result = command.ExecuteScalar();
                return (Result != null ? true : false);
            }
        }
       static public DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            string Query = "select country from countries ";
            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, conn))
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            return dt;
        }
    }
}
