using BooksDataAccessLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDataAccessLayer
{
    public  class clsPhone_Numbers
    {
        enum enMode { AddMode = 1, EditMode = 2 };
        enMode Mode = enMode.AddMode;
        private int PhoneNumberID { set; get; }

        public int MemberID { set; get; }
        public string PhoneNumber { set; get; }

        public clsPhone_Numbers()
        {
            PhoneNumberID = -1;
            MemberID = -1;
            PhoneNumber = string.Empty;
            Mode = enMode.AddMode;
        }
        public clsPhone_Numbers(int ID, int MemberID, string phoneNumber)
        {
            this.PhoneNumberID = ID;

            this.MemberID = MemberID;
            this.PhoneNumber = phoneNumber;
        
            Mode = enMode.EditMode;
        }

        private bool _AddPhoneNumber()
        {
            PhoneNumberID = clsPhone_NumberDataAccessLib.AddPhoneNumber(MemberID, PhoneNumber);
            return PhoneNumberID != -1;
        }
        private bool _UpdatePhoneNumber()
        {
            return clsPhone_NumberDataAccessLib.UpdatePhoneNummber(PhoneNumberID, MemberID,PhoneNumber);
        }
        static public clsPhone_Numbers Find(int ID)
        {
            int MemberID = -1;
           string PhoneNumber = string.Empty;
           
            if (ID > 0)
            {
                if (clsPhone_NumberDataAccessLib.Find(ID, ref MemberID, ref PhoneNumber))
                {
                    return new clsPhone_Numbers(ID, MemberID, PhoneNumber);
                }
            }
            return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    {
                        if (_AddPhoneNumber())
                        {
                            Mode = enMode.EditMode;
                            return true;
                        }
                        return false;
                    }
                case enMode.EditMode:
                    {
                        if (_UpdatePhoneNumber())
                        {
                            Mode = enMode.EditMode;
                            return true;
                        }
                        return false;
                    }

            }
            return false;
        }
        static public bool DeletePhoneNumber(int ID)
        {
            return clsPhone_NumberDataAccessLib.DeletePhoneNumber(ID);
        }
        static public DataTable GetAllPhoneNumbers()
        {
            return clsPhone_NumberDataAccessLib.GetAllPhone_Numbers();
        }
        static public bool DoesPhoneNumberExist(int ID)
        {
            return clsPhone_NumberDataAccessLib.DoesPhoneNumberExist(ID);
        }

        static public bool DoesPhoneNumberExist(string PhoneNumber)
        {
            return clsPhone_NumberDataAccessLib.DoesPhoneNumberExist(PhoneNumber);
        }
    }
}
