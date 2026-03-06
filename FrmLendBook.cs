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
    public partial class FrmLendBook : Form
    {
        int _MemberID =-1;
        string _MemberCardID = string.Empty;
        bool Deos_Member_Exist = false;
        clsBooks Book = new clsBooks();
        public FrmLendBook(int BookID , string MemberCardID="")
        {
            InitializeComponent();
            Book = clsBooks.FindBook(BookID);
            _MemberCardID=MemberCardID;
         
        }
        private void btnSearchMemberForLend_Click(object sender, EventArgs e)
        {
            if (clsMember.DoesMemberExist(txtSearchMemberForLend.Text.Trim()))
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
        private void FrmLendBook_Load(object sender, EventArgs e)
        {
            LbLendBookID.Text = Book.BookID.ToString();
            LbLendArabicName.Text = Book.BookArabicName;
            LBEnglishName.Text = Book.BookEnglishName;
            txtSearchMemberForLend.Text = _MemberCardID.Trim();

        }
        private void txtSearchMemberForLend_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchMemberForLend.Text.Trim()))
            {
                e.Cancel = true;
                txtSearchMemberForLend.Focus();
                errorProvider1.SetError(txtSearchMemberForLend, "This field should not be empty .");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSearchMemberForLend, "");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _MemberID = Convert.ToInt32(clsMember.SearchForMemberByCardID(txtSearchMemberForLend.Text.Trim()).Rows[0][0]);


            if (!Deos_Member_Exist)
            {
                MessageBox.Show("Member does not exist .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmShowMemberForLendingPurpose ShowMemBer = new FrmShowMemberForLendingPurpose(_MemberID);
                ShowMemBer.ShowDialog();
                if (MessageBox.Show("Are you sure you want to lend previous member ?", "Confirm.", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)
                     == DialogResult.OK)
                {
                    clsBorrowingRecords record = new clsBorrowingRecords();
                    record.Status = false;
                    record.ReturningDate = dateTimePicker1.Value;
                    record.BorrowingDate = DateTime.Now;
                    record.BookID = Book.BookID;
                    record.MemberID = _MemberID;
                    Book.Quantity--;
                    if (record.Save() && Book.Save())
                    {
                        MessageBox.Show("Book was lent successfully .", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                        MessageBox.Show("Book was not lent .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
