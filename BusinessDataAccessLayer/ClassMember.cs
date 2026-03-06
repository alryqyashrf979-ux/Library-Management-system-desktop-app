using BooksDataAccessLib;
using LibDataAceesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDataAccessLayer
{
    public class clsMember

    {
        enum enMode { AddMode = 1, EditMode = 2 };
        enMode Mode = enMode.AddMode;
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberCardID { get; set; }


        public string Email { get; set; }
        public string Occupation { get; set; }
        public DateTime Birthday { get; set; }
        public byte CountryID { get; set; }
        public string PicPath { get; set; }

         public bool IsDeleted { get; set; }
        public char Gender { get; set; }
        public clsMember() {
            MemberID = -1;
            MemberName = string.Empty;
            MemberCardID = string.Empty;
            Email = string.Empty;
            Occupation = string.Empty;
            Birthday = DateTime.MinValue;
            CountryID = 0;
            PicPath = string.Empty;
            Gender = '\0';
            IsDeleted = false;
            Mode = enMode.AddMode;

        }
        public clsMember(int memberID, string memberName, string memberCardId, string email,
            string occupation, DateTime birthday, byte countryId,string PicPath , char Gender , bool IsDeleted )
        {
            this.MemberID = memberID;
            this.MemberName = memberName;
            this.MemberCardID = memberCardId;
            this.Email = email;
            this.Occupation = occupation;
            this.Birthday = birthday;
            this.CountryID = countryId;
            this.PicPath = PicPath;
            this.IsDeleted = IsDeleted;
            this.Gender = Gender;
            Mode = enMode.EditMode;
        }

        static public clsMember Find(int ID)
        {
            string memberName = string.Empty;
            string memberCardID = string.Empty;
            string Email = string.Empty;
            string Occupation = string.Empty;
            DateTime birthday = DateTime.MinValue;
            string PicPath = string.Empty;
            char Gender = '\0';
            byte countryID = 0;
            bool isDeleted = false;
            if (ID <= 0) {
                return new clsMember();
            }
            else if (clsMemberDataAccess.Find(ID,ref memberName,ref memberCardID,ref Email,ref Occupation,ref birthday 
                ,ref countryID,ref PicPath,ref Gender,ref isDeleted))
            {
                return new clsMember(ID,memberName,memberCardID,Email,Occupation,birthday,countryID,PicPath,Gender,isDeleted);
            }
            else
                { return new clsMember(); }
        }
        static public clsMember Find(string MemberName)
        {
            int ID = -1;
            string memberCardID = string.Empty;
            string Email = string.Empty;
            string Occupation = string.Empty;
            DateTime birthday = DateTime.MinValue;
            string PicPath = string.Empty;
            byte countryID = 0 ;
            char Gender = '\0';
            bool isDeleted = false;
            if (MemberName == string.Empty)
            {
                return new clsMember();
            }
            else if (clsMemberDataAccess.Find(  MemberName,ref ID, ref memberCardID, ref Email, ref Occupation, ref birthday, ref countryID,ref PicPath,ref Gender , ref isDeleted))
            {
                return new clsMember(ID,  MemberName, memberCardID, Email, Occupation, birthday, countryID, PicPath,Gender, isDeleted);
            }
            else
            { return new clsMember(); }
        }
        static public clsMember FindByCardID(string MemberCardID)
        {
            int ID = -1;
            string memberCardID = string.Empty;
            string Email = string.Empty;
            string Occupation = string.Empty;
            DateTime birthday = DateTime.MinValue;
            string PicPath = string.Empty;
            byte countryID = 0;
            char Gender = '\0';
            bool IsDeleted = false;
            if (MemberCardID == string.Empty)
            {
                return new clsMember();
            }
            else if (clsMemberDataAccess.FindByCardID(ref MemberCardID, ref ID,  MemberCardID, ref Email, ref Occupation, ref birthday, ref countryID, ref PicPath, ref Gender,ref IsDeleted ))
            {
                return new clsMember(ID, MemberCardID, MemberCardID, Email, Occupation, birthday, countryID, PicPath, Gender, IsDeleted );
            }
            else
            { return new clsMember(); }
        }

        private bool _AddMember()
                {

                    MemberID = clsMemberDataAccess.AddMember(MemberName, MemberCardID, Email, Occupation, Birthday, CountryID,PicPath, Gender,IsDeleted);
                    return (MemberID > -1);
                }
        private bool _UpdateMember()
        {
            return clsMemberDataAccess.UpdateMember(MemberID,MemberName,MemberCardID,Email,Occupation,Birthday,CountryID, PicPath, Gender);
        }
        static public bool DeleteMember(int ID)
        {
            return clsMemberDataAccess.DeleteMember(ID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    {
                        if(_AddMember())
                        {
                            Mode = enMode.EditMode;
                            return true;
                            
                        }
                        return false;
                    }
                case enMode.EditMode:
                    {
                       if( _UpdateMember())
                        {
                            Mode = enMode.EditMode;
                            return true;
                        }
                        return false;
                       
                    }

            }
            return false;
        }

        static public DataTable GetAllMembers()
        {
          return clsMemberDataAccess.GetAllMembers();
        }
        //static public DataTable GetSortedMemberssByIDDesc()
        //{
        //    return clsMemberDataAccess.SortMembersByIDDesc();
        //}
        //static public DataTable GetSortedMemberssByIDAsc()
        //{
        //    return clsMemberDataAccess.SortMembersByIDAsc();
        //}
        //static public DataTable GetSortedMemberssByNameDesc()
        //{
        //    return clsMemberDataAccess.SortBooksByNameDesc();
        //}
        //static public DataTable GetSortedMemberssByNameAsc()
        //{
        //    return clsMemberDataAccess.SortMembersByNameAsc();
        //}
        static public bool DoesMemberExist(int ID)
        {
            return clsMemberDataAccess.DoesMemberExist(ID);
        }
        static public bool DoesMemberExist(string CardID)
        {
            return clsMemberDataAccess.DoesMemberExist(CardID);
        }
        static public DataTable SearchForMemberByID(int ID)
        {
            return clsMemberDataAccess.SearchMemberByID(ID);
        }
        static public DataTable SearchForMemberByName(string Name)
        {
            return clsMemberDataAccess.SearchMemberByName(Name);
        }
        static public DataTable SearchForMemberByEmail(string Email)
        {
            return clsMemberDataAccess.SearchMemberByEmail(Email);
        }
        static public DataTable SearchForMemberByOccupation(string OCC)
        {
            return clsMemberDataAccess.SearchMemberByOccupation(OCC);
        }
        static public DataTable SearchForMemberByCardID(string CardID)
        {
            return clsMemberDataAccess.SearchMemberByCardID(CardID);
        }
        static public DataTable SearchForMemberByCountryName(string CountryName)
        {
            return clsMemberDataAccess.SearchMemberByCountryName(CountryName);
        }

        static public DataTable GetAllCountries()
        {
            return clsMemberDataAccess.GetAllCountries();
        }
    }
}
