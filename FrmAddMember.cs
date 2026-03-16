using BusinessDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_2
{
    public partial class FrmAddMember : Form
    {
        enum enMemberFormMode { Add = 0, Update = 1 };
        enMemberFormMode memberFormMode = enMemberFormMode.Add;
        clsMember Member = null;
        int _Member_ID = -1;
        string PicPath = string.Empty;
        clsPhone_Numbers Phone_Number1 = new clsPhone_Numbers();
        clsPhone_Numbers Phone_Number2 = new clsPhone_Numbers();
        public FrmAddMember(int MemberID)
        {
            InitializeComponent();
            if (MemberID > 0)
            {
                memberFormMode = enMemberFormMode.Update;
                Member = clsMember.Find(MemberID);
                _Member_ID = MemberID;
                btnEditPhoneNumbers.Visible = true;
            }
            else
            {
                memberFormMode = enMemberFormMode.Add;
                Member = new clsMember();
                btnEditPhoneNumbers.Visible = false;
            }
        }
        private void Validate_TextBox(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                e.Cancel = true;
                ((TextBox)sender).Focus();
                MemberserrorProvider.SetError((TextBox)sender, "This field should not be empty.");
            }
            else
            {
                e.Cancel = false;
                MemberserrorProvider.SetError((TextBox)sender, "");
            }
        }
        private void _UploadDataFromObjectToForm()
        {
            comboBox1.SelectedIndex = Member.CountryID - 1;
            cbGender.SelectedIndex = 0;
            LBmemberMode.Text = "\"Edit Mode\"";
            LbMemberID.Text = _Member_ID.ToString();
            txtMemberName.Text = Member.MemberName;
            txtEmail.Text = Member.Email;
            txtmemberCardID.Text = Member.MemberCardID;
            txtOccupation.Text = Member.Occupation;
            mtbBirthdate.Text = Member.Birthday.ToString();
            label12.Visible = false;
            Ph1.Visible = false;
            Ph2.Visible = false;
            txtPhoneNumber1.Visible = false;
            txtPhoneNumber2.Visible = false;
            if (!string.IsNullOrEmpty(Member.PicPath))
            {
                pBMember.Load(Member.PicPath);
            }
        }
        public void EditPhoneNumbers()
        {
            label12.Visible = true;
            Ph1.Visible = true;
            Ph2.Visible = true;
            txtPhoneNumber1.Visible =true;
            txtPhoneNumber2.Visible =true;
            DataTable dt = clsPhone_Numbers.GetAllPhoneNumbersForASpecificMember(_Member_ID);
            if (dt.Rows.Count > 1)
            {
                txtPhoneNumber1.Text = dt.Rows[0][0].ToString();
                txtPhoneNumber2.Text = dt.Rows[1][0].ToString();
            }
            else
            {
                txtPhoneNumber1.Text = dt.Rows[0][0].ToString();
                Ph2.Enabled = false;
                txtPhoneNumber2.Enabled = false;
            }
           btnEditPhoneNumbers.Visible = false;
        }
        private void AddAllCountriesToComobox()
        {
            DataTable dt = clsMember.GetAllCountries();
            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row[0].ToString());
            }
        }
        private void FrmAddMember_Load(object sender, EventArgs e)
        {
            AddAllCountriesToComobox();
            switch (memberFormMode)
            {
                case enMemberFormMode.Update:
                    {
                        _UploadDataFromObjectToForm();
                        break;
                    }
                case enMemberFormMode.Add:
                    {
                        comboBox1.SelectedIndex = 0;
                        cbGender.SelectedIndex = 0;
                        LLBRemoveMemberImage.Visible = false;
                        break;
                    }
            }
        }
        private void _TransferDataFromFormToObject()
        {
            Member.MemberName = txtMemberName.Text.Trim();
            Member.Email = txtEmail.Text;
            Member.Occupation = txtOccupation.Text;
     Member.Gender= cbGender.Items[cbGender.SelectedIndex].ToString()[0];
          
                Member.MemberCardID = txtmemberCardID.Text.Trim();
          
            if (DateTime.TryParse(mtbBirthdate.Text.Trim(), out DateTime BirthDate))
            {
                Member.Birthday = BirthDate;
            }
            Member.PicPath = PicPath;
          Member.CountryID = (byte)(comboBox1.SelectedIndex + 1);
            //Member.Gender = 
       
        }

        private void LLBSetMemberImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Users\\ALSAKHRA PC\\Pictures\\Saved Pictures";
            openFileDialog1.Title = "Choose an Image :";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PicPath = openFileDialog1.FileName;
                pBMember.Load(PicPath);
                LLBRemoveMemberImage.Visible = true;
            }
        }
 
        private bool SaveMemberPhoneNumberInAddMode()
        {
           
            if (string.IsNullOrEmpty(txtPhoneNumber1.Text.Trim()))
            {
                MessageBox.Show("This phone number field should not be empty .", "Warning .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (clsPhone_Numbers.DoesPhoneNumberExist(txtPhoneNumber1.Text.Trim()))
            {
                MessageBox.Show("This phone number already exists .","Warning .",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                Phone_Number1.MemberID=_Member_ID;
                Phone_Number1.PhoneNumber = txtPhoneNumber1.Text.Trim();
                if (string.IsNullOrEmpty(txtPhoneNumber2.Text))
                {
                    if (Phone_Number1.Save())
                    {
                        MessageBox.Show("Phone Number was added successfully . ", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Phone Number was not added . ", "Confirm",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return false;
                    }
                    
                }
                else if (clsPhone_Numbers.DoesPhoneNumberExist(txtPhoneNumber2.Text.Trim()))
                {
                    MessageBox.Show("This phone number already exists .", "Warning .",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    Phone_Number2.MemberID = _Member_ID;
                    Phone_Number2.PhoneNumber = txtPhoneNumber1.Text.Trim();
                    if (Phone_Number2.Save()&& Phone_Number1.Save())
                    {
                        MessageBox.Show("Phone Numbers were added successfully . ", "Confirm",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Phone Numbers were added successfully . ", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            
            }
        }
        private bool SaveMemberPhoneNumberInUpdateMode()
        {

            if (string.IsNullOrEmpty(txtPhoneNumber1.Text.Trim()))
            {
                MessageBox.Show("This phone number field should not be empty .", "Warning .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (clsPhone_Numbers.DoesPhoneNumberExist(txtPhoneNumber1.Text.Trim()))
            {
                MessageBox.Show("This phone number already exists .", "Warning .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                Phone_Number1.MemberID = _Member_ID;
                Phone_Number1.PhoneNumber = txtPhoneNumber1.Text.Trim();
                if (string.IsNullOrEmpty(txtPhoneNumber2.Text))
                {
                    if (Phone_Number1.Save())
                    {
                        MessageBox.Show("Phone Number was Updated successfully . ", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Phone Number was not Updated . ", "Confirm",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return false;
                    }
                }
                else if (clsPhone_Numbers.DoesPhoneNumberExist(txtPhoneNumber2.Text.Trim()))
                {
                    MessageBox.Show("This phone number already exists .", "Warning .",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    Phone_Number2.MemberID = _Member_ID;
                    Phone_Number2.PhoneNumber = txtPhoneNumber1.Text.Trim();
                    if (Phone_Number2.Save() && Phone_Number1.Save())
                    {
                        MessageBox.Show("Phone Numbers were Updated successfully . ", "Confirm",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Phone Numbers were Updated successfully . ", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

            }
        }
        private void Save()
        {
          
           
            _TransferDataFromFormToObject();
            switch (memberFormMode)
                {
                    case enMemberFormMode.Add:
                        {
                        if (clsMember.DoesMemberExist(txtmemberCardID.Text.Trim()))
                        {
                            MessageBox.Show("this card member already exists .", "Warning.");
                            return;
                        }
                        if (Member.Save())
                            {
                              _Member_ID = Member.MemberID;
                            }
                        else
                        {
                            MessageBox.Show("Member was not added .", "Warning.",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (SaveMemberPhoneNumberInAddMode())
                           {
                            MessageBox.Show("Member was added successfully.", "Confirm.",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                            memberFormMode = enMemberFormMode.Update;
                           }
                            else
                            {
                               
                            clsMember.DeleteMember(_Member_ID);
                            Member = new clsMember();
                            MessageBox.Show("Member was not added .", "Warning.",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                            break;
                        }
                    case enMemberFormMode.Update:
                        {
                        if (!btnEditPhoneNumbers.Visible)
                        {
                            if (!SaveMemberPhoneNumberInUpdateMode())
                            {
                                MessageBox.Show("Member was not Updated .", "Warning.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (Member.Save())
                            {
                                MessageBox.Show("Member was Updated successfully.", "Confirm.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Member was not Updated .", "Warning.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                        }
                }
        }

        private void btnSaveMember_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Validate_textBox(object sender, CancelEventArgs e)
        {

        }

        private void btnEditPhoneNumbers_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to change Phone Numbers ", "Question",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                EditPhoneNumbers();

            }
        }

        private void LLBRemoveMemberImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PicPath=String.Empty; 
            Member.PicPath = String.Empty;
            pBMember.Image = Properties.Resources.Person2;
            LLBRemoveMemberImage.Visible = false;
        }
    }
}