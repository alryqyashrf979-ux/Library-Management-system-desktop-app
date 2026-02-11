using BooksDataAccessLib;
using LibDataAceesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBusinessLayer
{
    public class clsBooks
    {
        enum enMode { AddMode = 1, EditMode = 2 };
        enMode Mode = enMode.EditMode;
        private int BookID;
        public string BookArabicName { set; get; }
        public string BookEnglishName { set; get; }

        public int Quantity { set; get; }
        public string BookDescription { set; get; }

        public string Category { set; get; }
        public string Author { set; get; }
        public DateTime PublicationDate { set; get; }


        public clsBooks()
        {
            BookID = -1;
            BookArabicName = string.Empty;
            BookEnglishName = string.Empty;
            BookDescription = string.Empty;
            Category = string.Empty;
            Author = string.Empty;
            PublicationDate = DateTime.Now;
            Quantity = 0;
            Mode = enMode.AddMode;
        }

        public clsBooks(int bookID, string ArabicName, string EnglishName, string Category, string Author, string BookDesciption, int Quantity, DateTime PublicationDate)
        {
            this.BookID = bookID;
            this.BookArabicName = ArabicName;
            this.BookEnglishName = EnglishName;
            this.BookDescription = BookDesciption;
            this.Category = Category;
            this.Author = Author;
            this.Quantity = Quantity;
            this.PublicationDate = PublicationDate;
            Mode = enMode.EditMode;

        }

        static public clsBooks FindBook(int ID)
        {

            string BookArabicName = string.Empty;
            string BookEnglishName = string.Empty;
            string BookDescription = string.Empty;
            string Category = string.Empty;
            string Author = string.Empty;
            DateTime PublicationDate = DateTime.Now;
            int Quantity = 0;
            if (ID <= 0)
            {
                return null;
            }
            else if (clsBooksDataAccess.FindBook(ID, ref BookArabicName, ref BookEnglishName, ref BookDescription, 
                ref Author, ref Category, ref PublicationDate, ref Quantity))
            {
                return new clsBooks(ID, BookArabicName, BookEnglishName, Category, Author, BookDescription, Quantity, PublicationDate);
            }
            else
                return null;
        }
        static public clsBooks FindBookByArabicName(string ArabicName)
        {
            int ID = -1;
            string BookEnglishName = string.Empty;
            string BookDescription = string.Empty;
            string Category = string.Empty;
            string Author = string.Empty;
            DateTime PublicationDate = DateTime.Now;
            int Quantity = 0;

            if (clsBooksDataAccess.FindBookByArabicName(ArabicName, ref ID, ref BookEnglishName, ref BookDescription, ref Author, ref Category, ref PublicationDate, ref Quantity))
            {
                return new clsBooks(ID, ArabicName, BookEnglishName, Category, Author, BookDescription, Quantity, PublicationDate);
            }
            return null;
        }
        static public clsBooks FindBookByEnglishName(string EnglishName)
        {
            int ID = -1;
            string BookArabicName = string.Empty;
            string BookDescription = string.Empty;
            string Category = string.Empty;
            string Author = string.Empty;
            DateTime PublicationDate = DateTime.Now;
            int Quantity = 0;

            if (clsBooksDataAccess.FindBookByEnglishName(ref BookArabicName, ref ID, EnglishName, ref BookDescription, ref Author, ref Category, ref PublicationDate, ref Quantity))
            {
                return new clsBooks(ID, BookArabicName, EnglishName, Category, Author, BookDescription, Quantity, PublicationDate);
            }
            return null;
        }
        private bool _AddBook()
        {
            BookID = clsBooksDataAccess.AddBook(BookArabicName, BookEnglishName, BookDescription, Author, Category, PublicationDate, Quantity);
            return (BookID > 0);

        }

        private bool _EditBook()
        {
            return (clsBooksDataAccess.UpdateBook(this.BookID, this.BookArabicName, this.BookEnglishName, this.BookDescription,
                this.Author, this.Category, this.PublicationDate, this.Quantity));
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    {
                        if (_AddBook())
                        {
                            Mode = enMode.EditMode;
                            return true;
                        }
                        return false;
                    }
                case enMode.EditMode:
                    {
                        if (_EditBook())
                        {
                            Mode = enMode.EditMode;
                            return true;
                        }
                        return false;

                    }
            }
            return false;


        }

        static public bool DeleteBook(int BookID)
        {
            return clsBooksDataAccess.DeleteBook(BookID);
        }

        static public DataTable GetBooksDataTable()
        {
            return clsBooksDataAccess.GetAllBooks();
        }
        static public DataTable GetSortedBooksByIDDesc()
        {
            return clsBooksDataAccess.SortBooksByBookIDDesc();
        }
        static public DataTable GetSortedBooksByIDAsc()
        {
            return clsBooksDataAccess.SortBooksByBookIDAsc();
        }
        static public DataTable GetSortedBooksByEnglishNameDesc()
        {
            return clsBooksDataAccess.SortBooksByEnglishTitleDesc();
        }
        static public DataTable GetSortedBooksByEnglishNameAsc()
        {
            return clsBooksDataAccess.SortBooksByEnglishTitleAsc();
        }
        static public DataTable GetSortedBooksByArabicNameDesc()
        {
            return clsBooksDataAccess.SortBooksByArabicTitleDesc();
        }
        static public DataTable GetSortedBooksByArabicNameAsc()
        {
            return clsBooksDataAccess.SortBooksByArabicTitleAsc();
        }
        static public bool DoesBookExist(int ID)
        {
            return clsBooksDataAccess.DoesBookExist(ID);
        }
    }
}