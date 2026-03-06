using DataAccessLibSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibDataAceesLayer

{
    public class clsBooksDataAccess

    {
     
        static public bool FindBook(int BookID , ref string ArabicTitle , ref string EnglishTitle ,
            ref string Description , ref string Author , ref string Category , ref DateTime PublicationDate
            ,ref int Quantity,ref string Picture , ref bool IsDeleted)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select * from Books where BookID = @BookID and IsDeleted = 0 ;";
            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@BookID", BookID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    {
                        ArabicTitle = (string)reader["ArabicName"];
                        EnglishTitle = (string)reader["EnglishName"];
                        Description = (string)reader["Description"];
                        Author = (string)reader["Author"];
                        Category = (string)reader["Category"];
                        PublicationDate = (DateTime)reader["PublicationDate"];
                        Quantity = (short)reader["Quantity"];
                        Picture = (reader["Picture"] == DBNull.Value) ? "" : (string)reader["Picture"];
                        IsDeleted = (bool)reader["IsDeleted"];
                    }
                }
                result = true;
                reader.Close();
            }
            catch (Exception e)
            {
                result = false;
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        static public int AddBook(string ArabicTitle,string EnglishTitle, string Description,string Author,string Category,DateTime PublicationDate
            ,int  Quantity,string Picture,bool IsDeleted)
        {  
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "insert into Books\r\nvalues (@ArabicTitle,@EnglishTitle,@Category,@PublicationDate,@Quantity,@Author,@Description,@Picture,@IsDeleted);" +
                "select Scope_Identity()";
            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@ArabicTitle", ArabicTitle);
            command.Parameters.AddWithValue("@EnglishTitle", EnglishTitle);
            command.Parameters.AddWithValue("@Category", Category);
            command.Parameters.Add("@PublicationDate", SqlDbType.DateTime2).Value = PublicationDate;
            command.Parameters.AddWithValue("@Quantity", Quantity);
            command.Parameters.AddWithValue("@Author", Author);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = IsDeleted;
            if (Picture==string.Empty)
            {
                command.Parameters.AddWithValue("@Picture", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Picture",Picture);
            }
                try
                {
                    connection.Open();

                    object NewID = command.ExecuteScalar();
                    if (NewID != null && int.TryParse(NewID.ToString(), out int NewRecord))
                    {

                        return NewRecord;
                    }
                    return -1;
                }
                catch (Exception)
                {
                    return -1;
                }
                finally
                {
                    connection.Close();
                }
            
        }

        static public bool UpdateBook( int BookID , string ArabicTitle, string EnglishTitle, string Description, string Author, string Category, DateTime PublicationDate
            , int Quantity,string Picture,bool IsDeleted)
        {
          
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string Query = "Update Books \r\n" +
                "set Author = @Author, " +
                "ArabicName = @ArabicTitle," +
                "EnglishName = @EnglishTitle," +
                "Description = @Description," +
                "Category = @Category," +
                "PublicationDate = @PublicationDate," +
                "Quantity = @Quantity ," +
                "Picture = @Picture ," +
                "IsDeleted =@IsDeleted " +
                "\r\nwhere BookID = @BookID ";
            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.Add("@BookID",SqlDbType.Int).Value = BookID;
            command.Parameters.Add("@ArabicTitle", SqlDbType.NVarChar).Value = ArabicTitle;
            command.Parameters.Add("@EnglishTitle", SqlDbType.NVarChar).Value = EnglishTitle;
            command.Parameters.Add("@Category", SqlDbType.NVarChar).Value = Category;
            command.Parameters.Add("@PublicationDate", SqlDbType.DateTime2).Value = PublicationDate;
            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;
            command.Parameters.Add("@Author", SqlDbType.NVarChar).Value = Author;
            command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description;
            command.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = IsDeleted;
            if (Picture == string.Empty)
            {

                command.Parameters.Add("@Picture", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                command.Parameters.Add("@Picture", SqlDbType.NVarChar).Value = Picture;
            }
                try
                {
                    connection.Open();
                    int AffectedRows = command.ExecuteNonQuery();
                    if (AffectedRows > 0)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
                return false;
            }
        static public bool DeleteBook(int BookID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "Update Books set IsDeleted = 1  where BookID = @BookID ";
            SqlCommand command = new SqlCommand(Query, connection);
            

            command.Parameters.Add("@BookID",SqlDbType.Int).Value=BookID;
            try
            {
                connection.Open();
                int AffectedRows = command.ExecuteNonQuery();
                if (AffectedRows > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { connection.Close(); };
        }
        static public bool FindBookByArabicName(string ArabicTitle ,ref int BookID, ref string EnglishTitle,
      ref string Description, ref string Author, ref string Category, ref DateTime PublicationDate, ref int Quantity
            ,ref string Picture , ref bool IsDeleted )
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select * from Books where ArabicName like '%"+ArabicTitle+"%' and IsDeleted = 0" ;
            SqlCommand command = new SqlCommand(Query, connection);
            //command.Parameters.Add("@ArabicTitle", SqlDbType.NVarChar).Value = ArabicTitle;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    {
                        BookID = (int)reader["BookID"];
                        ArabicTitle = (string)reader["ArabicName"];
                        EnglishTitle = (string)reader["EnglishName"];
                        Description = (string)reader["Description"];
                        Author = (string)reader["Author"];
                        Category = (string)reader["Category"];
                        PublicationDate = (DateTime)reader["PublicationDate"];
                        Quantity = (short)reader["Quantity"];
                        Picture = (reader["Picture"] == DBNull.Value) ? "" : (string)reader["Picture"];
                        IsDeleted = (bool)reader["IsDeleted"];
                    }
                }
                result = true;
                reader.Close();
            }
            catch (Exception e)
            {
                result = false;
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        static public bool FindBookByEnglishName(ref string ArabicTitle, ref int BookID, string EnglishTitle,
  ref string Description, ref string Author, ref string Category, ref DateTime PublicationDate, ref int Quantity
            ,ref string Picture , ref bool IsDeleted)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select * from Books where EnglishName like '%" + EnglishTitle + "%' and IsDeleted = 0 ";
            SqlCommand command = new SqlCommand(Query, connection);
            //command.Parameters.Add("@ArabicTitle", SqlDbType.NVarChar).Value = ArabicTitle;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    {
                        BookID = (int)reader["BookID"];
                        ArabicTitle = (string)reader["ArabicName"];
                        EnglishTitle = (string)reader["EnglishName"];
                        Description = (string)reader["Description"];
                        Author = (string)reader["Author"];
                        Category = (string)reader["Category"];
                        PublicationDate = (DateTime)reader["PublicationDate"];
                        Quantity = (short)reader["Quantity"];
                        Picture = (reader["Picture"] != DBNull.Value) ? "" : (string)reader["Picture"];
                        IsDeleted = (bool)reader["IsDeleted"];
                    }
                }
                result = true;
                reader.Close();
            }
            catch (Exception e)
            {
                result = false;
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        static public DataTable GetAllBooks()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "Select BookID ,ArabicName, EnglishName, Category, PublicationDate, Quantity, Author, Description from Books where IsDeleted = 0";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)

                {
                    dt.Load(reader);
                }


            }
            catch (Exception e)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;

        }
        static public DataTable SortBooksByBookIDDesc()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select BookID , ArabicName, EnglishName, Category, PublicationDate, Quantity, Author, Description from Books where IsDeleted = 0 " +
                "order by BookID Desc";
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
        static public DataTable SortBooksByBookIDAsc()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select BookID ,ArabicName, EnglishName, Category, PublicationDate, Quantity, Author, Description from Books where IsDeleted = 0 " +
                "order by BookID Asc";
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
        static public DataTable SortBooksByEnglishTitleDesc()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select BookID ,ArabicName, EnglishName, Category, PublicationDate, Quantity, Author, Description from Books where IsDeleted = 0 " +
                "order by EnglishName Desc";
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
        static public DataTable SortBooksByEnglishTitleAsc()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select BookID ,ArabicName, EnglishName, Category, PublicationDate, Quantity, Author, Description from Books where IsDeleted = 0 " +
                "order by EnglishName Asc";
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
        static public DataTable SortBooksByArabicTitleAsc()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select BookID ,ArabicName, EnglishName, Category, PublicationDate, Quantity, Author, Description from Books where IsDeleted = 0 " +
                "order by ArabicName Asc";
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
        static public DataTable SortBooksByArabicTitleDesc()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select BookID ,ArabicName, EnglishName, Category, PublicationDate, Quantity, Author, Description from Books where IsDeleted = 0 " +
                "order by ArabicName Desc";
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
        static public bool DoesBookExist(int ID)
        {
            string Query = "select BookID from Books where BookID =@ID and IsDeleted = 0 ";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                connection.Open();
                object Result = command.ExecuteScalar();
                return (Result != null ? true : false);
            }
        }
        static public DataTable SearchBooksByBookID(int BookID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select BookID ,ArabicName, EnglishName, Category, PublicationDate, Quantity, Author, Description from Books where IsDeleted = 0 " +
                "and BookID =@BookID ";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.Add("@BookID",SqlDbType.Int).Value = BookID; 
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
        static public DataTable SearchBooksByEnglishTitle(string EnglishTitle)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select BookID ,ArabicName, EnglishName, Category, PublicationDate, Quantity, Author, Description from Books where IsDeleted = 0 " +
                "and EnglishName like '%"+EnglishTitle+"%'";
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

        static public DataTable SearchBooksByArabicTitle(string ArabicTitle)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select  BookID ,ArabicName, EnglishName, Category, PublicationDate, Quantity, Author, Description  from Books where IsDeleted = 0 " +
                "and ArabicName like '%" + ArabicTitle + "%'";
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

        static public DataTable SearchBooksByCategory(string Category)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select BookID, ArabicName, EnglishName, Category, PublicationDate, Quantity, Author, Description from Books where IsDeleted = 0 " +
                "and Category like '%" + Category + "%'";
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

        static public DataTable EmptyBooksTable()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "select BookID, ArabicName, EnglishName, Category, PublicationDate, Quantity, Author, Description From Books where BookID = NULL;";
            SqlCommand Command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader != null)
                {
                    dt.Load(reader);
                }
                reader.Close();
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

    }
}


