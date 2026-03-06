namespace Library_Management_System_2
{
    partial class FrmAddMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddMember));
            this.LBmemberMode = new System.Windows.Forms.Label();
            this.mtbBirthdate = new System.Windows.Forms.MaskedTextBox();
            this.LLBRemoveMemberImage = new System.Windows.Forms.LinkLabel();
            this.LLBSetMemberImage = new System.Windows.Forms.LinkLabel();
            this.txtmemberCardID = new System.Windows.Forms.TextBox();
            this.txtOccupation = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LbMemberID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveMember = new System.Windows.Forms.Button();
            this.pBMember = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.MemberserrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPhoneNumber1 = new System.Windows.Forms.TextBox();
            this.Ph1 = new System.Windows.Forms.Label();
            this.txtPhoneNumber2 = new System.Windows.Forms.TextBox();
            this.Ph2 = new System.Windows.Forms.Label();
            this.btnEditPhoneNumbers = new System.Windows.Forms.Button();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberserrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // LBmemberMode
            // 
            this.LBmemberMode.AutoSize = true;
            this.LBmemberMode.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBmemberMode.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LBmemberMode.Location = new System.Drawing.Point(309, 9);
            this.LBmemberMode.Name = "LBmemberMode";
            this.LBmemberMode.Size = new System.Drawing.Size(237, 36);
            this.LBmemberMode.TabIndex = 21;
            this.LBmemberMode.Text = "\"Add Member\"";
            // 
            // mtbBirthdate
            // 
            this.mtbBirthdate.Location = new System.Drawing.Point(269, 295);
            this.mtbBirthdate.Mask = "00 /00 /0000";
            this.mtbBirthdate.Name = "mtbBirthdate";
            this.mtbBirthdate.Size = new System.Drawing.Size(238, 24);
            this.mtbBirthdate.TabIndex = 25;
            this.mtbBirthdate.ValidatingType = typeof(System.DateTime);
            // 
            // LLBRemoveMemberImage
            // 
            this.LLBRemoveMemberImage.AutoSize = true;
            this.LLBRemoveMemberImage.Location = new System.Drawing.Point(745, 134);
            this.LLBRemoveMemberImage.Name = "LLBRemoveMemberImage";
            this.LLBRemoveMemberImage.Size = new System.Drawing.Size(110, 17);
            this.LLBRemoveMemberImage.TabIndex = 40;
            this.LLBRemoveMemberImage.TabStop = true;
            this.LLBRemoveMemberImage.Text = "Remove Image :";
            this.LLBRemoveMemberImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLBRemoveMemberImage_LinkClicked);
            // 
            // LLBSetMemberImage
            // 
            this.LLBSetMemberImage.AutoSize = true;
            this.LLBSetMemberImage.Location = new System.Drawing.Point(637, 134);
            this.LLBSetMemberImage.Name = "LLBSetMemberImage";
            this.LLBSetMemberImage.Size = new System.Drawing.Size(79, 17);
            this.LLBSetMemberImage.TabIndex = 30;
            this.LLBSetMemberImage.TabStop = true;
            this.LLBSetMemberImage.Text = "Set Image :";
            this.LLBSetMemberImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLBSetMemberImage_LinkClicked);
            // 
            // txtmemberCardID
            // 
            this.txtmemberCardID.Location = new System.Drawing.Point(269, 396);
            this.txtmemberCardID.Name = "txtmemberCardID";
            this.txtmemberCardID.Size = new System.Drawing.Size(238, 24);
            this.txtmemberCardID.TabIndex = 27;
            this.txtmemberCardID.Validating += new System.ComponentModel.CancelEventHandler(this.Validate_TextBox);
            // 
            // txtOccupation
            // 
            this.txtOccupation.Location = new System.Drawing.Point(269, 345);
            this.txtOccupation.Name = "txtOccupation";
            this.txtOccupation.Size = new System.Drawing.Size(238, 24);
            this.txtOccupation.TabIndex = 26;
            this.txtOccupation.Validating += new System.ComponentModel.CancelEventHandler(this.Validate_TextBox);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(269, 159);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(238, 24);
            this.txtEmail.TabIndex = 23;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.Validate_TextBox);
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(269, 113);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(238, 24);
            this.txtMemberName.TabIndex = 22;
            this.txtMemberName.Validating += new System.ComponentModel.CancelEventHandler(this.Validate_TextBox);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(45, 392);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 24);
            this.label7.TabIndex = 37;
            this.label7.Text = "Member Card ID : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 24);
            this.label6.TabIndex = 35;
            this.label6.Text = "Occupation :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 24);
            this.label5.TabIndex = 33;
            this.label5.Text = "Birth Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 24);
            this.label3.TabIndex = 29;
            this.label3.Text = "Email :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 24);
            this.label2.TabIndex = 27;
            this.label2.Text = " Name : ";
            // 
            // LbMemberID
            // 
            this.LbMemberID.AutoSize = true;
            this.LbMemberID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbMemberID.Location = new System.Drawing.Point(265, 68);
            this.LbMemberID.Name = "LbMemberID";
            this.LbMemberID.Size = new System.Drawing.Size(28, 24);
            this.LbMemberID.TabIndex = 25;
            this.LbMemberID.Text = "??";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 24);
            this.label1.TabIndex = 23;
            this.label1.Text = "Member ID : ";
            // 
            // btnSaveMember
            // 
            this.btnSaveMember.BackColor = System.Drawing.Color.DarkGray;
            this.btnSaveMember.BackgroundImage = global::Library_Management_System_2.Properties.Resources.Button;
            this.btnSaveMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveMember.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSaveMember.FlatAppearance.BorderSize = 4;
            this.btnSaveMember.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveMember.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMember.Location = new System.Drawing.Point(269, 558);
            this.btnSaveMember.Name = "btnSaveMember";
            this.btnSaveMember.Size = new System.Drawing.Size(162, 60);
            this.btnSaveMember.TabIndex = 41;
            this.btnSaveMember.Text = "Save.";
            this.btnSaveMember.UseVisualStyleBackColor = false;
            this.btnSaveMember.Click += new System.EventHandler(this.btnSaveMember_Click);
            // 
            // pBMember
            // 
            this.pBMember.Image = global::Library_Management_System_2.Properties.Resources.Person2;
            this.pBMember.Location = new System.Drawing.Point(640, 180);
            this.pBMember.Name = "pBMember";
            this.pBMember.Size = new System.Drawing.Size(215, 199);
            this.pBMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBMember.TabIndex = 39;
            this.pBMember.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(16, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 24);
            this.label4.TabIndex = 42;
            this.label4.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightGray;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(16, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 24);
            this.label8.TabIndex = 43;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightGray;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(16, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 24);
            this.label9.TabIndex = 44;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightGray;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(16, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 24);
            this.label10.TabIndex = 45;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.LightGray;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(16, 396);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 24);
            this.label11.TabIndex = 46;
            this.label11.Text = "*";
            // 
            // MemberserrorProvider
            // 
            this.MemberserrorProvider.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(45, 245);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 24);
            this.label14.TabIndex = 52;
            this.label14.Text = "Country :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.LightGray;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(16, 245);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 24);
            this.label15.TabIndex = 53;
            this.label15.Text = "*";
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(269, 245);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 24);
            this.comboBox1.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.LightGray;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(16, 438);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 24);
            this.label12.TabIndex = 57;
            this.label12.Text = "*";
            // 
            // txtPhoneNumber1
            // 
            this.txtPhoneNumber1.Location = new System.Drawing.Point(269, 442);
            this.txtPhoneNumber1.Name = "txtPhoneNumber1";
            this.txtPhoneNumber1.Size = new System.Drawing.Size(238, 24);
            this.txtPhoneNumber1.TabIndex = 28;
            this.txtPhoneNumber1.Validating += new System.ComponentModel.CancelEventHandler(this.Validate_TextBox);
            // 
            // Ph1
            // 
            this.Ph1.AutoSize = true;
            this.Ph1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ph1.Location = new System.Drawing.Point(45, 438);
            this.Ph1.Name = "Ph1";
            this.Ph1.Size = new System.Drawing.Size(198, 24);
            this.Ph1.TabIndex = 56;
            this.Ph1.Text = "Phone Number 1 : ";
            // 
            // txtPhoneNumber2
            // 
            this.txtPhoneNumber2.Location = new System.Drawing.Point(358, 483);
            this.txtPhoneNumber2.Name = "txtPhoneNumber2";
            this.txtPhoneNumber2.Size = new System.Drawing.Size(238, 24);
            this.txtPhoneNumber2.TabIndex = 29;
            // 
            // Ph2
            // 
            this.Ph2.AutoSize = true;
            this.Ph2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ph2.Location = new System.Drawing.Point(45, 483);
            this.Ph2.Name = "Ph2";
            this.Ph2.Size = new System.Drawing.Size(307, 24);
            this.Ph2.TabIndex = 59;
            this.Ph2.Text = "Phone Number 2 (Optional) : ";
            // 
            // btnEditPhoneNumbers
            // 
            this.btnEditPhoneNumbers.BackColor = System.Drawing.Color.DarkGray;
            this.btnEditPhoneNumbers.BackgroundImage = global::Library_Management_System_2.Properties.Resources.Button;
            this.btnEditPhoneNumbers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditPhoneNumbers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEditPhoneNumbers.FlatAppearance.BorderSize = 4;
            this.btnEditPhoneNumbers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditPhoneNumbers.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPhoneNumbers.Location = new System.Drawing.Point(461, 558);
            this.btnEditPhoneNumbers.Name = "btnEditPhoneNumbers";
            this.btnEditPhoneNumbers.Size = new System.Drawing.Size(162, 60);
            this.btnEditPhoneNumbers.TabIndex = 60;
            this.btnEditPhoneNumbers.Text = "Edit Phones.";
            this.btnEditPhoneNumbers.UseVisualStyleBackColor = false;
            this.btnEditPhoneNumbers.Click += new System.EventHandler(this.btnEditPhoneNumbers_Click);
            // 
            // cbGender
            // 
            this.cbGender.AllowDrop = true;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cbGender.Location = new System.Drawing.Point(269, 201);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(238, 24);
            this.cbGender.TabIndex = 61;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.LightGray;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(16, 201);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 24);
            this.label13.TabIndex = 63;
            this.label13.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(45, 201);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 24);
            this.label16.TabIndex = 62;
            this.label16.Text = "Gender :";
            // 
            // FrmAddMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(885, 662);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnEditPhoneNumbers);
            this.Controls.Add(this.txtPhoneNumber2);
            this.Controls.Add(this.Ph2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPhoneNumber1);
            this.Controls.Add(this.Ph1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSaveMember);
            this.Controls.Add(this.mtbBirthdate);
            this.Controls.Add(this.LLBRemoveMemberImage);
            this.Controls.Add(this.LLBSetMemberImage);
            this.Controls.Add(this.txtmemberCardID);
            this.Controls.Add(this.txtOccupation);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtMemberName);
            this.Controls.Add(this.pBMember);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LbMemberID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBmemberMode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAddMember";
            this.Text = "Add Member :";
            this.Load += new System.EventHandler(this.FrmAddMember_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberserrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBmemberMode;
        private System.Windows.Forms.Button btnSaveMember;
        private System.Windows.Forms.MaskedTextBox mtbBirthdate;
        private System.Windows.Forms.LinkLabel LLBRemoveMemberImage;
        private System.Windows.Forms.LinkLabel LLBSetMemberImage;
        private System.Windows.Forms.TextBox txtmemberCardID;
        private System.Windows.Forms.TextBox txtOccupation;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.PictureBox pBMember;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LbMemberID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ErrorProvider MemberserrorProvider;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPhoneNumber2;
        private System.Windows.Forms.Label Ph2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPhoneNumber1;
        private System.Windows.Forms.Label Ph1;
        private System.Windows.Forms.Button btnEditPhoneNumbers;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
    }
}