using BusinessDataAccessLayer;
using LibBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_2
{
    public partial class Form1 : Form
    {
        enum enSearchForBook { ID = 0, English_Title = 1, Arabic_Title = 2, Category = 3 };
        enum enSearchForMember { MemberID = 0, Name = 1, CardID = 2, Email = 3, Occupation = 4, CountryName = 5 };
        enum enFilterRecordsBy { None = 0, Returned = 1, Not_Returned = 2 };
        enum enFilterReservationsBy { None = 0, Availible = 1, Not_Availible = 2 };
        enSearchForBook SearchMode = enSearchForBook.ID;
        enSearchForMember MemberSearchMode = enSearchForMember.MemberID;
        enFilterRecordsBy FilterBorrowingRecords = enFilterRecordsBy.None;
        enFilterReservationsBy FilterReservations = enFilterReservationsBy.None;
        public Form1()
        {
            InitializeComponent();
        }

        private void CheckZeroQuantityAndFillDGVForBooks(DataTable dt)
        {
            dgvBooks.DataSource = dt;
            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                if (Convert.ToInt32(row.Cells["Quantity"].Value) == 0)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckZeroQuantityAndFillDGVForBooks(clsBooks.GetBooksDataTable());
            dgvMembers.DataSource = clsMember.GetAllMembers();
            cbsearchMemberBy.SelectedIndex = 0;
            dgvBorrowingRecords.DataSource = clsBorrowingRecords.GetAllBorrowingRecords();
            cbSearchBy.SelectedIndex = 0;
            dgvReservations.DataSource = clsReservations.GetAllReservations();
            btnRefresh.Visible = false;
            pictureBox10.Visible = false;

        }

        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbSearchBy.SelectedIndex)
            {
                case 0:
                    {
                        SearchMode = enSearchForBook.ID;
                        break;
                    }
                case 1:
                    {
                        SearchMode = enSearchForBook.English_Title;
                        break;
                    }
                case 2:
                    {
                        SearchMode = enSearchForBook.Arabic_Title;
                        break;
                    }
                case 3:
                    {
                        SearchMode = enSearchForBook.Category;
                        break;
                    }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            btnRefresh.Visible = true;
            pictureBox10.Visible = true;
            switch (SearchMode)
            {
                case enSearchForBook.ID:
                    {
                        int.TryParse(txtSearch.Text, out int ID);
                        CheckZeroQuantityAndFillDGVForBooks(clsBooks.SearchBooksByID(ID));
                        //dgvBooks.DataSource = clsBooks.SearchBooksByID(ID);
                        break;
                    }
                case enSearchForBook.English_Title:
                    {
                        CheckZeroQuantityAndFillDGVForBooks(clsBooks.SearchBooksbyEnglishName(txtSearch.Text.Trim()));
                        // dgvBooks.DataSource = clsBooks.SearchBooksbyEnglishName(txtSearch.Text);
                        break;
                    }
                case enSearchForBook.Arabic_Title:
                    {
                        CheckZeroQuantityAndFillDGVForBooks(clsBooks.SearchBooksByArabicName(txtSearch.Text.Trim()));
                        //  dgvBooks.DataSource = clsBooks.SearchBooksByArabicName(txtSearch.Text);
                        break;
                    }
                case enSearchForBook.Category:
                    {
                        CheckZeroQuantityAndFillDGVForBooks(clsBooks.SearchBooksbyCategory(txtSearch.Text.Trim()));
                        // dgvBooks.DataSource = clsBooks.SearchBooksbyCategory(txtSearch.Text);
                        break;
                    }
                default:
                    break;
            }
        }
        private void Refresh()
        {
            CheckZeroQuantityAndFillDGVForBooks(clsBooks.GetBooksDataTable());
            cbSearchBy.SelectedIndex = 0;
            txtSearch.Text = string.Empty;
            btnRefresh.Visible = false;
            dgvMembers.DataSource = clsMember.GetAllMembers();
            dgvBorrowingRecords.DataSource = clsBorrowingRecords.GetAllBorrowingRecords();
            dgvReservations.DataSource = clsReservations.GetAllReservations();

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            frmAddBook FormAdd = new frmAddBook(-1);
            FormAdd.ShowDialog();
            CheckZeroQuantityAndFillDGVForBooks(clsBooks.GetBooksDataTable());


        }

        private void deleteBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Book ? ", " Warning . ", MessageBoxButtons.YesNo
                  , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsBooks.DeleteBook(Convert.ToInt32(dgvBooks.CurrentRow.Cells[0].Value)))
                {
                    CheckZeroQuantityAndFillDGVForBooks(clsBooks.GetBooksDataTable());
                    cbSearchBy.SelectedIndex = 0;
                    txtSearch.Text = string.Empty;
                    btnRefresh.Visible = false;
                    MessageBox.Show("Book has been deleted successfully . ", " Error ");
                }
                else
                {
                    MessageBox.Show("Book has not been deleted .", "Error");
                }
            }

        }

        private void editBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddBook FormAdd = new frmAddBook(Convert.ToInt32(dgvBooks.CurrentRow.Cells[0].Value));
            FormAdd.ShowDialog();
            CheckZeroQuantityAndFillDGVForBooks(clsBooks.GetBooksDataTable());
        }
        private void btnSearchmember_Click(object sender, EventArgs e)
        {
            btnMembersRefresh.Visible = true;
            pictureBox8.Visible = true;

            switch (MemberSearchMode)
            {
                case enSearchForMember.MemberID:
                    {
                        int.TryParse(txtSearchMember.Text, out int ID);
                        dgvMembers.DataSource = clsMember.SearchForMemberByID(ID);
                        break;
                    }
                case enSearchForMember.Name:
                    {
                        dgvMembers.DataSource = clsMember.SearchForMemberByName(txtSearchMember.Text.Trim());
                        break;
                    }
                case enSearchForMember.CardID:
                    {
                        dgvMembers.DataSource = clsMember.SearchForMemberByCardID(txtSearchMember.Text.Trim());
                        break;
                    }
                case enSearchForMember.Email:
                    {
                        dgvMembers.DataSource = clsMember.SearchForMemberByEmail(txtSearchMember.Text.Trim());
                        break;
                    }
                case enSearchForMember.Occupation:
                    {
                        dgvMembers.DataSource = clsMember.SearchForMemberByOccupation(txtSearchMember.Text.Trim());
                        break;
                    }
                case enSearchForMember.CountryName:
                    {
                        dgvMembers.DataSource = clsMember.SearchForMemberByCountryName(txtSearchMember.Text.Trim());
                        break;
                    }
                default:
                    break;
            }
        }

        private void cbsearchMemberBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbsearchMemberBy.SelectedIndex)
            {
                case 0:
                    {
                        MemberSearchMode = enSearchForMember.MemberID;
                        break;
                    }
                case 1:
                    {
                        MemberSearchMode = enSearchForMember.Name;
                        break;
                    }
                case 2:
                    {
                        MemberSearchMode = enSearchForMember.CardID;
                        break;
                    }
                case 3:
                    {
                        MemberSearchMode = enSearchForMember.Email;
                        break;
                    }
                case 4:
                    {
                        MemberSearchMode = enSearchForMember.Occupation;
                        break;
                    }
                case 5:
                    {
                        MemberSearchMode = enSearchForMember.CountryName;
                        break;
                    }
            }
        }

        private void btnMembersRefresh_Click(object sender, EventArgs e)
        {
            cbsearchMemberBy.SelectedIndex = 0;
            txtSearchMember.Text = string.Empty;
            txtSearchMember.Focus();
            btnMembersRefresh.Visible = false;
            pictureBox8.Visible = false;
            dgvMembers.DataSource = clsMember.GetAllMembers();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmAddMember frmAddMember = new FrmAddMember(-1);
            frmAddMember.ShowDialog();
            Refresh();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddMember frmAddMember = new FrmAddMember(Convert.ToInt32(dgvMembers.CurrentRow.Cells[0].Value));
            frmAddMember.ShowDialog();
            Refresh();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Member ? ", " Warning . ", MessageBoxButtons.YesNo
           , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int MemberID = Convert.ToInt32(dgvMembers.CurrentRow.Cells[0].Value);
                if (clsPhone_Numbers.DeleteAllPhoneNumbersFormember(MemberID))
                {
                    if (clsMember.DeleteMember(MemberID))
                    {
                        dgvMembers.DataSource = clsMember.GetAllMembers();
                        cbsearchMemberBy.SelectedIndex = 0;
                        txtSearchMember.Text = string.Empty;
                        txtSearchMember.Focus();
                        btnMembersRefresh.Visible = false;

                        MessageBox.Show("Member has been deleted successfully . ", " Error ");
                    }
                }

                else
                {
                    MessageBox.Show("Member has not been deleted .", "Error");
                }
            }
        }


        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMemberDetailsForm ShowMember = new ShowMemberDetailsForm(Convert.ToInt32(dgvMembers.CurrentRow.Cells[0].Value));
            ShowMember.ShowDialog();
            Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lendBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookID = Convert.ToInt32(dgvBooks.CurrentRow.Cells[0].Value);
            if (Convert.ToInt32(dgvBooks.CurrentRow.Cells[5].Value) == 0)
            {
                if (MessageBox.Show("Store is out of this book , would you love to reserve this book ? ", "Confirm.",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ReserveBook ReservationForm = new ReserveBook(BookID);
                    ReservationForm.ShowDialog();
                    Refresh();
                }
            }
            else
            {
                FrmLendBook frmLendBook = new FrmLendBook(BookID);
                frmLendBook.ShowDialog();
                Refresh();
            }
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvBorrowingRecords.CurrentRow.Cells[0].Value);
            if (!clsBorrowingRecords.DoesRecordExist(ID))
            {
                MessageBox.Show("This record is not found . ", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                clsBorrowingRecords Record = clsBorrowingRecords.Find(ID);
                if (Record.Status)
                {
                    MessageBox.Show("Book was already returned . ", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    Record.Status = true;
                    clsBooks Book = clsBooks.FindBook(Record.BookID);
                    if (Book.BookArabicName != string.Empty)
                    {
                        Book.Quantity++;
                        if (MessageBox.Show("Are you sure you want to return this book ?", "Confirm .", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (Book.Save())
                            {
                                if (Record.Save())
                                {
                                    MessageBox.Show("Book was returned . ", "Confirm .", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Refresh();
                                }
                                else
                                {
                                    MessageBox.Show("Book was not returned . ", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                                MessageBox.Show("Book was not returned . ", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Book was not returned . ", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void tabPage3_Enter(object sender, EventArgs e)
        {
            btnRefrshBorrowingRecordTable.Visible = false;
            cbFilterBorrowingREcords.SelectedIndex = 0;
            pictureBox13.Visible = false;
        }

        private void btnSearchmemberByCardIDForBorrowingRecord_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSerachByMemberCardID.Text.Trim()))
            {
                if (clsMember.DoesMemberExist(txtSerachByMemberCardID.Text.Trim()))
                {
                    clsMember Member = clsMember.FindByCardID(txtSerachByMemberCardID.Text.Trim());
                    switch (FilterBorrowingRecords)
                    {
                        case enFilterRecordsBy.None:
                            {
                                dgvBorrowingRecords.DataSource = clsBorrowingRecords.searchForRecordsByMemberID(Member.MemberID);
                                break;
                            }
                        case enFilterRecordsBy.Returned:
                            {
                                dgvBorrowingRecords.DataSource = clsBorrowingRecords.searchForRecordsByMemberID(Member.MemberID, true);
                                break;
                            }
                        case enFilterRecordsBy.Not_Returned:
                            {
                                dgvBorrowingRecords.DataSource = clsBorrowingRecords.searchForRecordsByMemberID(Member.MemberID, false);
                                break;
                            }
                    }
                }
                else
                {
                    MessageBox.Show("Member has no Borrowing records , please check member card ID and look up again ", "Error.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Search text box is empty , please insert member card ID and look up again ", "Error.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnRefrshBorrowingRecordTable.Visible = true;
        }

        private void btnRefrshBorrowingRecordTable_Click(object sender, EventArgs e)
        {
            dgvBorrowingRecords.DataSource = clsBorrowingRecords.GetAllBorrowingRecords();
            btnRefrshBorrowingRecordTable.Visible = false;
            txtSerachByMemberCardID.Text = string.Empty;
            cbFilterBorrowingREcords.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterBorrowingREcords.SelectedIndex)
            {
                case 0:
                    {
                        cbFilterBorrowingREcords.SelectedIndex = 0;
                        FilterBorrowingRecords = enFilterRecordsBy.None;
                        dgvBorrowingRecords.DataSource = clsBorrowingRecords.GetAllBorrowingRecords();
                        break;
                    }
                case 1:
                    {
                        cbFilterBorrowingREcords.SelectedIndex = 1;
                        FilterBorrowingRecords = enFilterRecordsBy.Returned;
                        dgvBorrowingRecords.DataSource = clsBorrowingRecords.FilterRecordsByStatus(true);
                        break;
                    }
                case 2:
                    {
                        cbFilterBorrowingREcords.SelectedIndex = 2;
                        FilterBorrowingRecords = enFilterRecordsBy.Not_Returned;
                        dgvBorrowingRecords.DataSource = clsBorrowingRecords.FilterRecordsByStatus(false);
                        break;
                    }
            }

        }

        private void txtSerachByMemberCardIDForBorrowingRecord_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchmemberByCardIDForBorrowingRecords_Click(object sender, EventArgs e)
        {
            btnRefrshBorrowingRecordTable.Visible = true;
            pictureBox13.Visible = true;
        }

        private void btnSearchReservations_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMemberCardIDReservations.Text.Trim()))
            {
                if (clsMember.DoesMemberExist(txtMemberCardIDReservations.Text.Trim()))
                {
                    clsMember Member = clsMember.FindByCardID(txtMemberCardIDReservations.Text.Trim());
                    switch (FilterReservations)
                    {
                        case enFilterReservationsBy.None:
                            {
                                dgvReservations.DataSource = clsReservations.SearchForReservationsByMemberID(Member.MemberID);
                                break;
                            }
                        case enFilterReservationsBy.Availible:
                            {
                                dgvReservations.DataSource = clsReservations.FilterAndSearchForReservationsByMemberID(Member.MemberID, true);
                                break;
                            }
                        case enFilterReservationsBy.Not_Availible:
                            {
                                dgvReservations.DataSource = clsReservations.FilterAndSearchForReservationsByMemberID(Member.MemberID, false);
                                break;
                            }
                    }
                    btnRefreshReservations.Visible = true ;
                    pictureBox15.Visible = true ;
                }
                else
                {
                    MessageBox.Show("Member has no reservation, please check member card ID and look up again ", "Error.",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnRefreshReservations.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Search text box is empty , please insert member card ID and look up again ", "Error.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
               

            }
        }

        private void btnRefrshBorrowingRecordTable_Click_1(object sender, EventArgs e)
        {

        }

        private void btnRefreshReservations_Click(object sender, EventArgs e)
        {
            dgvReservations.DataSource = clsReservations.GetAllReservations();
            btnRefreshReservations.Visible = false;
            txtMemberCardIDReservations.Text = string.Empty;
            cbFilterReservations.SelectedIndex = 0;
        }

        private void cbFilterReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterReservations.SelectedIndex)
            {
                case 0:
                    {
                        cbFilterReservations.SelectedIndex = 0;
                        FilterReservations = enFilterReservationsBy.None;
                        dgvReservations.DataSource = clsReservations.GetAllReservations();
                        break;
                    }
                case 1:
                    {
                        cbFilterReservations.SelectedIndex = 1;
                        FilterReservations = enFilterReservationsBy.Availible;
                        dgvReservations.DataSource = clsReservations.FilterReservationsByAvailibilty(true);
                        break;
                    }
                case 2:
                    {
                        cbFilterReservations.SelectedIndex = 2;
                        FilterReservations = enFilterReservationsBy.Not_Availible;
                        dgvReservations.DataSource = clsReservations.FilterReservationsByAvailibilty();
                        break;
                    }
            }
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            btnRefreshReservations.Visible = false;
            cbFilterReservations.SelectedIndex = 0;
            pictureBox15.Visible = false;
        }

        private int GetBookIDForLendingFromReservation()
        {
            int ReservationID = Convert.ToInt32(dgvReservations.CurrentRow.Cells[0].Value);
            clsReservations reservation = clsReservations.Find(ReservationID);
            return reservation.BookID;
        }
        private string GetMemberCardIDForLendingfromReservation()
        {
            return Convert.ToString(dgvReservations.CurrentRow.Cells[3].Value).Trim();
        }
 

        private void lendBookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(dgvReservations.CurrentRow.Cells[5].Value))
            {
                MessageBox.Show("this book is still inavailiable .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmLendBook LendBook = new FrmLendBook(GetBookIDForLendingFromReservation(),GetMemberCardIDForLendingfromReservation());
                LendBook.ShowDialog();
                Refresh();
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            btnSearchmember.BackgroundImage = null;
            pictureBox8.Visible = false;
        }
    }
}
    
  

