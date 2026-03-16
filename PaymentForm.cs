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
    public partial class PaymentForm : Form
    {
        clsFines Fine = null;
        clsMember Member =null;
        clsBooks Book = null;
        clsBorrowingRecords Record = null;

        public PaymentForm(int BorrowingID)
        {
            InitializeComponent();
            Fine= clsFines.FindByBorrowingID(BorrowingID);
            Record = clsBorrowingRecords.Find(BorrowingID);
            Member = clsMember.Find(Record.MemberID);
            Book = clsBooks.FindBook(Record.BookID);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            LbBookArabic.Text = Book.BookArabicName.ToString();
            LbEnglishName.Text = Book.BookEnglishName.ToString();
            LBLateDays.Text = Fine.LateDays.ToString();
            LBMemberName.Text = Member.MemberName.ToString();
            FineAmount.Text = Fine.PaymentAmount.ToString();
            cbPaymentMethods.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fine.PaymentMethod = cbPaymentMethods.SelectedItem.ToString();
            Fine.IsPaid = true;
            if(!Fine.Save())
            {
                MessageBox.Show("Something went wrong . ", "Error .", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Fine was paid successfully . ", "Error .", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            Close();
        }
    }
}
