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
    public partial class frmAddBook : Form
    {
        enum enMode { Add =1,Update =2 };
        enMode Mode = enMode.Add;
        clsBooks Book = null;
        int _BooKID = 0;
        string _PicPath = string.Empty;
        public frmAddBook(int BookID)
        {
            InitializeComponent();
            if (BookID > 0)
            {
                Mode = enMode.Update;
                Book= clsBooks.FindBook(BookID);
                _BooKID = BookID;
            }
            else
            {
                Mode = enMode.Add;
                Book = new clsBooks();
            }
        }
      private void _Load_Object_To_Form()
        {
            LBMode.Text = "Edit Book ...";
            LbBookID.Text = _BooKID.ToString();
            txtArabicName.Text = Book.BookArabicName;
            txtEnglishName.Text = Book.BookEnglishName;
            txtCategory.Text = Book.Category;
            maskedTextBox1.Text = Book.PublicationDate.ToString();
            txtAuthor.Text = Book.Author;
            txtDescriptionBox.Text = Book.BookDescription;
            txtQuantity.Text = Book.Quantity.ToString();
            if (Book.PicturePath != string.Empty)
            {

                pictureBox1.Load(Book.PicturePath);
            }
            else
            {
                LLBRemoveImage.Visible = false;
            }
            }
           
        private void frmAddBook_Load(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        LLBRemoveImage.Visible = false;
                        break;
                    }
                    case enMode.Update:
                    {
                        _Load_Object_To_Form();
                        break;
                    }
            }
        }

    private void SaveContentToObject()
        {
            Book.BookArabicName = txtArabicName.Text;
            Book.BookEnglishName = txtEnglishName.Text;
            var IsValidDate = DateTime.TryParse(maskedTextBox1.Text, out DateTime Dt);
            if (IsValidDate)
                Book.PublicationDate = Dt;
            else
                MessageBox.Show("Operation was canceled");
            Book.BookDescription = txtDescriptionBox.Text;
            Book.Category = txtCategory.Text;
            Book.Author = txtAuthor.Text;
            Book.PicturePath = _PicPath;
            Book.BookDescription = txtDescriptionBox.Text;
            Book.Quantity =Convert.ToInt32( txtQuantity.Text);
        }

      private void Validate_TextBox(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                e.Cancel = true;
                ((TextBox)sender).Focus();
                errorProvider1.SetError((TextBox)sender, "This field should not be empty.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError((TextBox)sender, "");
            }
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if ((maskedTextBox1.Text)== "   /   /")
            {
                e.Cancel = true;
                maskedTextBox1.Focus();
                errorProvider1.SetError(maskedTextBox1, "This field should not be empty.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(maskedTextBox1, "");
            }
        }

        private void LLBSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\ALSAKHRA PC\Pictures\Saved Pictures";
            openFileDialog1.Title = "Choose an image ";
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                _PicPath = openFileDialog1.FileName;
            }
        }

   

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        SaveContentToObject();
                        if (Book.Save())
                        {
                            MessageBox.Show("Book was added successfully .", "Confirm.",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Mode = enMode.Update;
                            LbBookID.Text = Book.BookID.ToString();
                            LBMode.Text = "\"Edit Book\"";
                            LLBRemoveImage.Visible = true;

                        }
                        else
                        {
                            MessageBox.Show("Book was not added  .", "Confirm.",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case enMode.Update:
                    {
                        SaveContentToObject();
                        if (Book.Save())
                        {
                            MessageBox.Show("Book info was Updated successfully .", "Confirm.",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LBMode.Text = "\"Edit Book\"";
                        }
                        else
                        {
                            MessageBox.Show("Book was not edited  .", "Confirm.",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
            }
        }

        private void LLBRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _PicPath = "";
            pictureBox1.Image = Properties.Resources.Book;
        }
    }
}
