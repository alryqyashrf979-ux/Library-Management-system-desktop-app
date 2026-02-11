using BooksDataAccessLib;
using LibDataAceesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDataAccessLayer
{
    public class clsMember

    {
        enum enMode { AddMode = 1, EditMode = 2 };
        enMode Mode = enMode.AddMode;
        private int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberCardID { get; set; }


        public string Email { get; set; }
        public string Occupation { get; set; }
        public DateTime Birthday { get; set; }
        public int CountryID { get; set; }

        public clsMember() {
            MemberID = -1;
            MemberName = string.Empty;
            MemberCardID = string.Empty;
            Email = string.Empty;
            Occupation = string.Empty;
            Birthday = DateTime.MinValue;
            CountryID = -1;
            Mode = enMode.AddMode;
        }
        public clsMember(int memberID, string memberName, string memberCardId, string email, string occupation, DateTime birthday, int countryId)
        {
            this.MemberID = memberID;
            this.MemberName = memberName;
            this.MemberCardID = memberCardId;
            this.Email = email;
            this.Occupation = occupation;
            this.Birthday = birthday;
            this.CountryID = countryId;
            Mode = enMode.EditMode;
        }

        static public clsMember Find(int ID)
        {
            string memberName = string.Empty;
            string memberCardID = string.Empty;
            string Email = string.Empty;
            string Occupation = string.Empty;
            DateTime birthday = DateTime.MinValue;
            int countryID = -1;
            if (ID <= 0) {
                return new clsMember();
            }
            else if (clsMemberDataAccess.Find(ID,ref memberName,ref memberCardID,ref Email,ref Occupation,ref birthday,ref countryID))
            {
                return new clsMember(ID,memberName,memberCardID,Email,Occupation,birthday,countryID);
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
            int countryID = -1;
            if (MemberName == string.Empty)
            {
                return new clsMember();
            }
            else if (clsMemberDataAccess.Find(  MemberName,ref ID, ref memberCardID, ref Email, ref Occupation, ref birthday, ref countryID))
            {
                return new clsMember(ID,  MemberName, memberCardID, Email, Occupation, birthday, countryID);
            }
            else
            { return new clsMember(); }
        }


        private bool _AddMember()
                {

                    MemberID = clsMemberDataAccess.AddMember(MemberName, MemberCardID, Email, Occupation, Birthday, CountryID);
                    return (MemberID > -1);
                }
        private bool _UpdateMember()
        {
            return clsMemberDataAccess.UpdateMember(MemberID,MemberName,MemberCardID,Email,Occupation,Birthday,CountryID);
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
        static public DataTable GetSortedMemberssByIDDesc()
        {
            return clsMemberDataAccess.SortMembersByIDDesc();
        }
        static public DataTable GetSortedMemberssByIDAsc()
        {
            return clsMemberDataAccess.SortMembersByIDAsc();
        }
        static public DataTable GetSortedMemberssByNameDesc()
        {
            return clsMemberDataAccess.SortBooksByNameDesc();
        }
        static public DataTable GetSortedMemberssByNameAsc()
        {
            return clsMemberDataAccess.SortMembersByNameAsc();
        }
        static public bool DoesMemberExist(int ID)
        {
            return clsMemberDataAccess.DoesMemberExist(ID);
        }
    }
}
