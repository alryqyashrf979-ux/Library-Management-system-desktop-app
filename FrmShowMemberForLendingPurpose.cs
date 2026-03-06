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
    public partial class FrmShowMemberForLendingPurpose : Form
    {
        clsMember member;
        public FrmShowMemberForLendingPurpose(int MemberID)
        {
            InitializeComponent();
            member = clsMember.Find(MemberID);
        }

        private void FrmShowMemberForLendingPurpose_Load(object sender, EventArgs e)
        {
            ShowLbMemberID.Text = member.MemberID.ToString();
            LbShowName.Text = member.MemberName;
            LbShowEmail.Text = member.Email;
            LbShowOccupation.Text = member.Occupation;
            LBShowBirthDate.Text = member.Birthday.ToString();
            LBShowCountry.Text = clsMember.GetAllCountries().Rows[member.CountryID - 1][0].ToString();
            LBShowMemberCardID.Text = member.MemberCardID;
            DataTable dt = clsPhone_Numbers.GetAllPhoneNumbersForASpecificMember(member.MemberID);
            if (dt.Rows.Count > 1)
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
            if (!string.IsNullOrEmpty(member.PicPath))
            {
                pBShowMember.Load(member.PicPath);
            }

        }

        private void btnCloseShow_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
