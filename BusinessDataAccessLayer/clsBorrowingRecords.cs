using BooksDataAccessLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDataAccessLayer
{
    public class clsBorrowingRecords
    {
        enum enMode { AddMode = 1, EditMode = 2 };
        enMode Mode = enMode.AddMode;
        private int BorrowingRecordID { set; get; }
        public bool Status { set; get; }
        public int MemberID { set; get; }
        public int BookID { set; get; }
        public DateTime BorrowingDate { set; get; }

        public clsBorrowingRecords()
        {
            BorrowingRecordID = -1;
            Status = false;
            MemberID = -1;
            BookID = -1;
            BorrowingDate = DateTime.MinValue;
            Mode = enMode.AddMode;
        }
        public clsBorrowingRecords(int ID, int MemberID, int BookID, bool Status, DateTime BorrowingDate)
        {
            this.BorrowingRecordID = ID;
            this.Status = Status;
            this.MemberID = MemberID;
            this.BookID = BookID;
            this.BorrowingDate = BorrowingDate;
            Mode = enMode.EditMode;
        }

        private bool _AddBorrowingRecord()
        {
         BorrowingRecordID= clsBorrowingRecordsDataAccess.AddBorrowing(MemberID,BookID,Status,BorrowingDate);
            return BorrowingRecordID!=-1;
        }
        private bool _UpdateBorrowingRecord() {
            return clsBorrowingRecordsDataAccess.UpdateBorrowingRecord(BorrowingRecordID, MemberID, BookID, Status, BorrowingDate);
        }
        static public clsBorrowingRecords Find(int ID)
        {
            int MemberID = -1;
            int BookID = -1;
            bool Status = false;
            DateTime BorrowingDate = DateTime.MinValue;
            if (ID > 0)
            {
                if (clsBorrowingRecordsDataAccess.Find(ID, ref MemberID, ref BookID, ref Status, ref BorrowingDate))
                {
                    return new clsBorrowingRecords(ID, MemberID, BookID, Status, BorrowingDate);
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

                        if (_AddBorrowingRecord())
                        {
                            Mode = enMode.EditMode;
                            return true;
                        }
                        return false;
                    }
                case enMode.EditMode:
                    {
                        if (_UpdateBorrowingRecord())
                        {
                            Mode = enMode.EditMode;
                            return true;
                        }
                        return false;
                    }

            }
            return false;
        }
        static public bool DeleteRecord(int ID )
        {
            return clsBorrowingRecordsDataAccess.DeleteBorrowingRecord(ID);
        }
        static public DataTable GetAllBorrowingRecords()
        {
           return clsBorrowingRecordsDataAccess.GetAllBorrowingRecords();

        }
        static public bool DoesRecordExist(int ID)
        {
            return clsBorrowingRecordsDataAccess.DoesBorrowingRecordExist(ID);
        }
    }
}
