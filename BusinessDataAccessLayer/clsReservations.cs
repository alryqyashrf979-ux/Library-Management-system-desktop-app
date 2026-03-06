using BooksDataAccessLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDataAccessLayer
{
    public class clsReservations

    {
        enum enMode { AddMode = 1, EditMode = 2 };
        enMode Mode = enMode.AddMode;
        private int ReservationID { set; get; }
     
        public int MemberID { set; get; }
        public int BookID { set; get; }
        public DateTime ReservationDate { set; get; }

      public  bool Availibilty { set; get; }
        public clsReservations()
        {
            ReservationID = -1;
            MemberID = -1;
            BookID = -1;
            ReservationDate = DateTime.MinValue;
            Availibilty = false;
            Mode = enMode.AddMode;
        }
        public clsReservations(int ID, int MemberID, int BookID, DateTime ReservationDate, bool Availibilty)
        {
            this.ReservationID = ID;
        
            this.MemberID = MemberID;
            this.BookID = BookID;
            this.ReservationDate = ReservationDate;
            this.Availibilty = Availibilty;

            Mode = enMode.EditMode;
        }

        private bool _AddReservation()
        {
            ReservationID = clsReservationsDataAccessLayer.AddReservation(MemberID, BookID, ReservationDate, Availibilty);
            return ReservationID != -1;
        }
        private bool _UpdateReservation()
        {
            return clsReservationsDataAccessLayer.UpdateReservation(ReservationID, MemberID, BookID, ReservationDate, Availibilty);
        }
        static public clsReservations Find(int ID)
        {
            int MemberID = -1;
            int BookID = -1;
            DateTime ReservationDate = DateTime.Now;
            bool Availibilty = false;
            if (ID > 0)
            {
                if (clsReservationsDataAccessLayer.Find(ID, ref MemberID, ref BookID,ref ReservationDate,ref Availibilty))
                {
                    return new clsReservations(ID, MemberID, BookID, ReservationDate, Availibilty);
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
                        if (_AddReservation())
                        {
                            Mode = enMode.EditMode;
                            return true;
                        }
                        return false;
                    }
                case enMode.EditMode:
                    {
                        if (_UpdateReservation())
                        {
                            Mode = enMode.EditMode;
                            return true;
                        }
                        return false;
                    }

            }
            return false;
        }
        static public bool DeleteReservation(int ID)
        {
            return clsReservationsDataAccessLayer.DeleteReservation(ID);
        }
        static public DataTable GetAllReservations()
        {
            return clsReservationsDataAccessLayer.GetAllReservations();

        }
        static public bool DoesReservationExist(int ID)
        {
            return clsReservationsDataAccessLayer.DoesReservationExist(ID);
        }
        static public DataTable SearchForReservationsByMemberID(int MemberID)
        {
            return clsReservationsDataAccessLayer.SearchForReservation(MemberID);
        }
        static public DataTable FilterAndSearchForReservationsByMemberID(int MemberID,bool Availibilty)
        {
            return clsReservationsDataAccessLayer.FilterAndSearchForReservationsByAvailibilty(MemberID,Availibilty);
        }
        static public DataTable FilterReservationsByAvailibilty(bool Availibilty = false)
        {
            return clsReservationsDataAccessLayer.FilterByAvailibilty(Availibilty);
        }
    }
}

