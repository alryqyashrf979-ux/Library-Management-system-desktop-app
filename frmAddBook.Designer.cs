namespace Library_Management_System_2
{
    partial class frmAddBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddBook));
            this.label1 = new System.Windows.Forms.Label();
            this.LbBookID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtArabicName = new System.Windows.Forms.TextBox();
            this.txtEnglishName = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtDescriptionBox = new System.Windows.Forms.TextBox();
            this.LLBSetImage = new System.Windows.Forms.LinkLabel();
            this.LLBRemoveImage = new System.Windows.Forms.LinkLabel();
            this.LBMode = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book ID : ";
            // 
            // LbBookID
            // 
            this.LbBookID.AutoSize = true;
            this.LbBookID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbBookID.Location = new System.Drawing.Point(245, 81);
            this.LbBookID.Name = "LbBookID";
            this.LbBookID.Size = new System.Drawing.Size(28, 24);
            this.LbBookID.TabIndex = 1;
            this.LbBookID.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Arabic Name : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "English Name : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Category :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "Publication Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "Quantity :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "Author :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 406);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "Description :";
            // 
            // txtArabicName
            // 
            this.txtArabicName.Location = new System.Drawing.Point(249, 130);
            this.txtArabicName.Name = "txtArabicName";
            this.txtArabicName.Size = new System.Drawing.Size(238, 24);
            this.txtArabicName.TabIndex = 0;
            this.txtArabicName.Validating += new System.ComponentModel.CancelEventHandler(this.Validate_TextBox);
            // 
            // txtEnglishName
            // 
            this.txtEnglishName.Location = new System.Drawing.Point(249, 180);
            this.txtEnglishName.Name = "txtEnglishName";
            this.txtEnglishName.Size = new System.Drawing.Size(238, 24);
            this.txtEnglishName.TabIndex = 1;
            this.txtEnglishName.Validating += new System.ComponentModel.CancelEventHandler(this.Validate_TextBox);
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(249, 220);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(238, 24);
            this.txtCategory.TabIndex = 2;
            this.txtCategory.Validating += new System.ComponentModel.CancelEventHandler(this.Validate_TextBox);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(249, 315);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(238, 24);
            this.txtQuantity.TabIndex = 4;
            this.txtQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.Validate_TextBox);
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(249, 366);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(238, 24);
            this.txtAuthor.TabIndex = 5;
            this.txtAuthor.Validating += new System.ComponentModel.CancelEventHandler(this.Validate_TextBox);
            // 
            // txtDescriptionBox
            // 
            this.txtDescriptionBox.Location = new System.Drawing.Point(207, 410);
            this.txtDescriptionBox.Multiline = true;
            this.txtDescriptionBox.Name = "txtDescriptionBox";
            this.txtDescriptionBox.Size = new System.Drawing.Size(759, 202);
            this.txtDescriptionBox.TabIndex = 6;
            this.txtDescriptionBox.Validating += new System.ComponentModel.CancelEventHandler(this.Validate_TextBox);
            // 
            // LLBSetImage
            // 
            this.LLBSetImage.AutoSize = true;
            this.LLBSetImage.Location = new System.Drawing.Point(616, 126);
            this.LLBSetImage.Name = "LLBSetImage";
            this.LLBSetImage.Size = new System.Drawing.Size(79, 17);
            this.LLBSetImage.TabIndex = 7;
            this.LLBSetImage.TabStop = true;
            this.LLBSetImage.Text = "Set Image :";
            this.LLBSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLBSetImage_LinkClicked);
            // 
            // LLBRemoveImage
            // 
            this.LLBRemoveImage.AutoSize = true;
            this.LLBRemoveImage.Location = new System.Drawing.Point(724, 126);
            this.LLBRemoveImage.Name = "LLBRemoveImage";
            this.LLBRemoveImage.Size = new System.Drawing.Size(110, 17);
            this.LLBRemoveImage.TabIndex = 19;
            this.LLBRemoveImage.TabStop = true;
            this.LLBRemoveImage.Text = "Remove Image :";
            this.LLBRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLBRemoveImage_LinkClicked);
            // 
            // LBMode
            // 
            this.LBMode.AutoSize = true;
            this.LBMode.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBMode.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LBMode.Location = new System.Drawing.Point(404, 9);
            this.LBMode.Name = "LBMode";
            this.LBMode.Size = new System.Drawing.Size(190, 36);
            this.LBMode.TabIndex = 20;
            this.LBMode.Text = "\"Add Book\"";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(249, 265);
            this.maskedTextBox1.Mask = "00 /00 /0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(238, 24);
            this.maskedTextBox1.TabIndex = 3;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox1.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBox1_Validating);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnSave.BackgroundImage = global::Library_Management_System_2.Properties.Resources.Button;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSave.FlatAppearance.BorderSize = 4;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(432, 628);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(162, 60);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save.";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_Management_System_2.Properties.Resources.Book;
            this.pictureBox1.Location = new System.Drawing.Point(619, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmAddBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(998, 716);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.LBMode);
            this.Controls.Add(this.LLBRemoveImage);
            this.Controls.Add(this.LLBSetImage);
            this.Controls.Add(this.txtDescriptionBox);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtEnglishName);
            this.Controls.Add(this.txtArabicName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LbBookID);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddBook";
            this.Text = "New Book .";
            this.Load += new System.EventHandler(this.frmAddBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbBookID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtArabicName;
        private System.Windows.Forms.TextBox txtEnglishName;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtDescriptionBox;
        private System.Windows.Forms.LinkLabel LLBSetImage;
        private System.Windows.Forms.LinkLabel LLBRemoveImage;
        private System.Windows.Forms.Label LBMode;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSave;
    }
}