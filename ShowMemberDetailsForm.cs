using BusinessDataAccessLayer;
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
    public partial class ShowMemberDetailsForm : Form
    {
       

       
        clsMember member = new clsMember();
        public ShowMemberDetailsForm(int MemberID )
        {
            InitializeComponent();
            member = clsMember.Find(MemberID);
        }

        private void ShowMemberDetailsForm_Load(object sender, EventArgs e)
        {
            ShowLbMemberID.Text = member.MemberID.ToString();
            LbShowName.Text = member.MemberName;
            LbShowEmail.Text = member.Email;  
            LbShowOccupation.Text = member.Occupation;
            LBShowBirthDate.Text = member.Birthday.ToString();
            LBShowCountry.Text = clsMember.GetAllCountries().Rows[member.CountryID - 1][0].ToString();
            LBShowMemberCardID.Text = member.MemberCardID;
            DataTable dt = clsPhone_Numbers.GetAllPhoneNumbersForASpecificMember(member.MemberID);
            if(dt.Rows.Count>1)
            {
                LBShowPhoneNumber1.Text = dt.Rows[0][0].ToString();
                LBShowPhoneNumber2.Text = dt.Rows[1][0].ToString();
            }
            else
            {
                LBShowPhoneNumber1.Text = dt.Rows[0][0].ToString();
                LBShowPhoneNumber2.Visible = false;
                ShowPh2.Visible = false;
            }
               if(!string.IsNullOrEmpty(member.PicPath))
            {
                pBShowMember.Load(member.PicPath);
            }
          

        }

        private void btnUpdateMemberFromShow_Click(object sender, EventArgs e)
        {
            FrmAddMember frmAddMember = new FrmAddMember(Convert.ToInt32(member.MemberID));
            frmAddMember.ShowDialog();
           
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Member ? ", " Warning . ", MessageBoxButtons.YesNo
   , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int MemberID = Convert.ToInt32(member.MemberID);
                if (clsPhone_Numbers.DeleteAllPhoneNumbersFormember(MemberID))
                {
                    if (clsMember.DeleteMember(MemberID))
                    {
                        MessageBox.Show("Member has been deleted successfully . ", " Error ");
                    }
                }

                else
                {
                    MessageBox.Show("Member has not been deleted .", "Error");
                }
            }
        }

        private void btnCloseShow_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
