namespace Library_Management_System_2
{
    partial class ReserveBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReserveBook));
            this.GBReserveMember = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchMemberForReserve = new System.Windows.Forms.Button();
            this.txtSearchMemberForReserve = new System.Windows.Forms.TextBox();
            this.GBBookInfo = new System.Windows.Forms.GroupBox();
            this.ShowLendBookID = new System.Windows.Forms.Label();
            this.LbReserveBookID = new System.Windows.Forms.Label();
            this.ShowLbLendArabicName = new System.Windows.Forms.Label();
            this.LbReserveArabicName = new System.Windows.Forms.Label();
            this.ShowLBLendEnglishName = new System.Windows.Forms.Label();
            this.LBReserveEnglishName = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnConfirmReserve = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GBReserveMember.SuspendLayout();
            this.GBBookInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GBReserveMember
            // 
            this.GBReserveMember.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.GBReserveMember.Controls.Add(this.label2);
            this.GBReserveMember.Controls.Add(this.btnSearchMemberForReserve);
            this.GBReserveMember.Controls.Add(this.txtSearchMemberForReserve);
            this.GBReserveMember.Controls.Add(this.pictureBox1);
            this.GBReserveMember.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBReserveMember.Location = new System.Drawing.Point(25, 287);
            this.GBReserveMember.Name = "GBReserveMember";
            this.GBReserveMember.Size = new System.Drawing.Size(1031, 142);
            this.GBReserveMember.TabIndex = 21;
            this.GBReserveMember.TabStop = false;
            this.GBReserveMember.Text = "Member :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(134, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Search by Card ID :";
            // 
            // btnSearchMemberForReserve
            // 
            this.btnSearchMemberForReserve.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearchMemberForReserve.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchMemberForReserve.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchMemberForReserve.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchMemberForReserve.Location = new System.Drawing.Point(659, 68);
            this.btnSearchMemberForReserve.Name = "btnSearchMemberForReserve";
            this.btnSearchMemberForReserve.Size = new System.Drawing.Size(116, 35);
            this.btnSearchMemberForReserve.TabIndex = 16;
            this.btnSearchMemberForReserve.Text = "Search .";
            this.btnSearchMemberForReserve.UseVisualStyleBackColor = false;
            this.btnSearchMemberForReserve.Click += new System.EventHandler(this.btnSearchMemberForReserve_Click);
            this.btnSearchMemberForReserve.Validating += new System.ComponentModel.CancelEventHandler(this.btnSearchMemberForReserve_Validating);
            // 
            // txtSearchMemberForReserve
            // 
            this.txtSearchMemberForReserve.Location = new System.Drawing.Point(332, 68);
            this.txtSearchMemberForReserve.Name = "txtSearchMemberForReserve";
            this.txtSearchMemberForReserve.Size = new System.Drawing.Size(214, 28);
            this.txtSearchMemberForReserve.TabIndex = 12;
            // 
            // GBBookInfo
            // 
            this.GBBookInfo.Controls.Add(this.ShowLendBookID);
            this.GBBookInfo.Controls.Add(this.LbReserveBookID);
            this.GBBookInfo.Controls.Add(this.ShowLbLendArabicName);
            this.GBBookInfo.Controls.Add(this.LbReserveArabicName);
            this.GBBookInfo.Controls.Add(this.ShowLBLendEnglishName);
            this.GBBookInfo.Controls.Add(this.LBReserveEnglishName);
            this.GBBookInfo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBBookInfo.Location = new System.Drawing.Point(25, 22);
            this.GBBookInfo.Name = "GBBookInfo";
            this.GBBookInfo.Size = new System.Drawing.Size(1053, 259);
            this.GBBookInfo.TabIndex = 20;
            this.GBBookInfo.TabStop = false;
            this.GBBookInfo.Text = "Book Info :";
            this.GBBookInfo.Enter += new System.EventHandler(this.GBBookInfo_Enter);
            // 
            // ShowLendBookID
            // 
            this.ShowLendBookID.AutoSize = true;
            this.ShowLendBookID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowLendBookID.Location = new System.Drawing.Point(55, 41);
            this.ShowLendBookID.Name = "ShowLendBookID";
            this.ShowLendBookID.Size = new System.Drawing.Size(110, 24);
            this.ShowLendBookID.TabIndex = 5;
            this.ShowLendBookID.Text = "Book ID : ";
            // 
            // LbReserveBookID
            // 
            this.LbReserveBookID.AutoSize = true;
            this.LbReserveBookID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbReserveBookID.Location = new System.Drawing.Point(137, 85);
            this.LbReserveBookID.Name = "LbReserveBookID";
            this.LbReserveBookID.Size = new System.Drawing.Size(28, 24);
            this.LbReserveBookID.TabIndex = 7;
            this.LbReserveBookID.Text = "??";
            // 
            // ShowLbLendArabicName
            // 
            this.ShowLbLendArabicName.AutoSize = true;
            this.ShowLbLendArabicName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowLbLendArabicName.Location = new System.Drawing.Point(273, 41);
            this.ShowLbLendArabicName.Name = "ShowLbLendArabicName";
            this.ShowLbLendArabicName.Size = new System.Drawing.Size(158, 24);
            this.ShowLbLendArabicName.TabIndex = 8;
            this.ShowLbLendArabicName.Text = "Arabic Name : ";
            // 
            // LbReserveArabicName
            // 
            this.LbReserveArabicName.AutoSize = true;
            this.LbReserveArabicName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbReserveArabicName.Location = new System.Drawing.Point(378, 85);
            this.LbReserveArabicName.Name = "LbReserveArabicName";
            this.LbReserveArabicName.Size = new System.Drawing.Size(28, 24);
            this.LbReserveArabicName.TabIndex = 10;
            this.LbReserveArabicName.Text = "??";
            // 
            // ShowLBLendEnglishName
            // 
            this.ShowLBLendEnglishName.AutoSize = true;
            this.ShowLBLendEnglishName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowLBLendEnglishName.Location = new System.Drawing.Point(273, 143);
            this.ShowLBLendEnglishName.Name = "ShowLBLendEnglishName";
            this.ShowLBLendEnglishName.Size = new System.Drawing.Size(166, 24);
            this.ShowLBLendEnglishName.TabIndex = 9;
            this.ShowLBLendEnglishName.Text = "English Name : ";
            // 
            // LBReserveEnglishName
            // 
            this.LBReserveEnglishName.AutoSize = true;
            this.LBReserveEnglishName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBReserveEnglishName.Location = new System.Drawing.Point(378, 195);
            this.LBReserveEnglishName.Name = "LBReserveEnglishName";
            this.LBReserveEnglishName.Size = new System.Drawing.Size(28, 24);
            this.LBReserveEnglishName.TabIndex = 11;
            this.LBReserveEnglishName.Text = "??";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnConfirmReserve
            // 
            this.btnConfirmReserve.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmReserve.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmReserve.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmReserve.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfirmReserve.Location = new System.Drawing.Point(455, 458);
            this.btnConfirmReserve.Name = "btnConfirmReserve";
            this.btnConfirmReserve.Size = new System.Drawing.Size(116, 35);
            this.btnConfirmReserve.TabIndex = 17;
            this.btnConfirmReserve.Text = "Confirm .";
            this.btnConfirmReserve.UseVisualStyleBackColor = false;
            this.btnConfirmReserve.Click += new System.EventHandler(this.btnConfirmReserve_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_Management_System_2.Properties.Resources.Search;
            this.pictureBox1.Location = new System.Drawing.Point(75, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // ReserveBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1106, 580);
            this.Controls.Add(this.btnConfirmReserve);
            this.Controls.Add(this.GBReserveMember);
            this.Controls.Add(this.GBBookInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReserveBook";
            this.Text = "Reserve Book";
            this.Load += new System.EventHandler(this.ReserveBook_Load);
            this.GBReserveMember.ResumeLayout(false);
            this.GBReserveMember.PerformLayout();
            this.GBBookInfo.ResumeLayout(false);
            this.GBBookInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GBReserveMember;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchMemberForReserve;
        private System.Windows.Forms.TextBox txtSearchMemberForReserve;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox GBBookInfo;
        private System.Windows.Forms.Label ShowLendBookID;
        private System.Windows.Forms.Label LbReserveBookID;
        private System.Windows.Forms.Label ShowLbLendArabicName;
        private System.Windows.Forms.Label LbReserveArabicName;
        private System.Windows.Forms.Label ShowLBLendEnglishName;
        private System.Windows.Forms.Label LBReserveEnglishName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnConfirmReserve;
    }
}