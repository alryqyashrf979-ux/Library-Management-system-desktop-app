using BooksDataAccessLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDataAccessLayer
{
    public class clsFines
    {
        enum enMode { AddMode = 1, EditMode = 2 };
        enMode Mode = enMode.AddMode;
        private int FineID { set; get; }
        public bool IsPaid { set; get; }

        public int BorrowingID { set; get; }
        public string PaymentMethod { set; get; }
        public decimal PaymentAmount { set; get; } 

        public short LateDays { set; get; }

        public clsFines()
        {
            BorrowingID = -1;
            IsPaid = false;
      
            PaymentMethod = string.Empty;
            PaymentAmount = 0;
            LateDays = 0;
            Mode = enMode.AddMode;
        }
        public clsFines(int fineID, int BorrowingId, bool Ispaid, string PaymentMethod, decimal PaymentAmount , short LateDays)
        {
            this.FineID = fineID;
            this.IsPaid = Ispaid;
           
            this.BorrowingID = BorrowingId;
            this.PaymentAmount = PaymentAmount;
            this.LateDays = LateDays;
            this.PaymentMethod = PaymentMethod;
            Mode = enMode.EditMode;
        }

        private bool _AddFineRecord()
        {
            FineID = clsFinesDataAccess.AddFine( BorrowingID, IsPaid , PaymentAmount, LateDays);
            return FineID != -1;
        }
        private bool _UpdateFineRecord()
        {
            return clsFinesDataAccess.UpdateFineRecord(FineID, BorrowingID, IsPaid, PaymentMethod,PaymentAmount,LateDays);
        }
        static public clsFines FindByBorrowingID(int BorrowingID)
        {
          
            int FineID = -1;
            bool IsPaid = false;
            string PaymentMethod = string.Empty;
            decimal PaymentAmount = 0;
            short LateDays = 0;
          
            if (BorrowingID > 0)
            {
                if (clsFinesDataAccess.FindByBorrowingID( BorrowingID,ref FineID, ref IsPaid, ref PaymentMethod,ref PaymentAmount,ref LateDays))
                {
                    return new clsFines(FineID, BorrowingID, IsPaid, PaymentMethod,PaymentAmount,LateDays);
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

                        if (_AddFineRecord())
                        {
                            Mode = enMode.EditMode;
                            return true;
                        }
                        return false;
                    }
                case enMode.EditMode:
                    {
                        if (_UpdateFineRecord())
                        {
                            Mode = enMode.EditMode;
                            return true;
                        }
                        return false;
                    }

            }
            return false;
        }
        static public bool DeleteRecord(int ID)
        {
            return clsFinesDataAccess.DeleteFineRecord(ID);
        }
        static public DataTable GetAllFinesRecords()
        {
            return clsFinesDataAccess.GetAllFineRecords();

        }
        static public bool DoesRecordExist(int ID)
        {
            return clsFinesDataAccess.DoesFineRecordExist(ID);
        }

        static public void UpdateALlRecordsForPaymentsAndLateDays()
        {
            clsFinesDataAccess.UpdatePaymentsAndLateDaysForAllFines();

        }
       
    }
}
