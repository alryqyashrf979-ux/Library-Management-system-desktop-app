using BusinessDataAccessLayer;
using LibBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_2
{
    public partial class ReserveBook : Form
    {
        int _MemberID = -1;
        bool Deos_Member_Exist = false;
        clsBooks Book = new clsBooks();
        public ReserveBook(int BookID)
        {
            InitializeComponent();
           Book = clsBooks.FindBook(BookID);
            
        }

        private void ReserveBook_Load(object sender, EventArgs e)
        {
            LbReserveBookID.Text = Book.BookID.ToString();
            LbReserveArabicName.Text = Book.BookArabicName;
            LBReserveEnglishName.Text = Book.BookEnglishName;
        }

        private void btnSearchMemberForReserve_Click(object sender, EventArgs e)
        {
            if (clsMember.DoesMemberExist(txtSearchMemberForReserve.Text.Trim()))
            {
                Deos_Member_Exist = true;
                MessageBox.Show("Member exists .", "Confirm .", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Deos_Member_Exist = false;
                MessageBox.Show("Member does not exist .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GBBookInfo_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearchMemberForReserve_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchMemberForReserve.Text.Trim()))
            {
                e.Cancel = true;
                txtSearchMemberForReserve.Focus();
                errorProvider1.SetError(txtSearchMemberForReserve, "This field should not be empty .");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSearchMemberForReserve, "");
            }
        }

        private void btnConfirmReserve_Click(object sender, EventArgs e)
        {
            _MemberID = Convert.ToInt32(clsMember.SearchForMemberByCardID(txtSearchMemberForReserve.Text.Trim()).Rows[0][0]);
            if (!Deos_Member_Exist)
            {
                MessageBox.Show("Member does not exist .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmShowMemberForLendingPurpose ShowMemBer = new FrmShowMemberForLendingPurpose(_MemberID);
                ShowMemBer.ShowDialog();
                if (MessageBox.Show("Are you sure you want to reserve the book for the previous member ?", "Confirm.", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                     == DialogResult.OK)
                {
                    clsReservations reservation = new clsReservations();
                    reservation.ReservationDate = DateTime.Now;
                    reservation.MemberID = _MemberID;
                    reservation.BookID = Book.BookID;
                    reservation.Availibilty = (Book.Quantity > 0) ;

                    if (reservation.Save())
                    {
                        MessageBox.Show("Book was reserved successfully .", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                        MessageBox.Show("Book was not reserved .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
