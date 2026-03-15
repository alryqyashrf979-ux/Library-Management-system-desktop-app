namespace Library_Management_System_2
{
    partial class PaymentForm
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
            this.cbPaymentMethods = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LBMemberName = new System.Windows.Forms.Label();
            this.FineAmount = new System.Windows.Forms.Label();
            this.LbEnglishName = new System.Windows.Forms.Label();
            this.LBLateDays = new System.Windows.Forms.Label();
            this.LbBookArabic = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPaymentMethods
            // 
            this.cbPaymentMethods.FormattingEnabled = true;
            this.cbPaymentMethods.Items.AddRange(new object[] {
            "Cash.",
            "Credit card.",
            "Transaction."});
            this.cbPaymentMethods.Location = new System.Drawing.Point(395, 229);
            this.cbPaymentMethods.Name = "cbPaymentMethods";
            this.cbPaymentMethods.Size = new System.Drawing.Size(165, 24);
            this.cbPaymentMethods.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Payment Method :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LbBookArabic);
            this.groupBox1.Controls.Add(this.LBLateDays);
            this.groupBox1.Controls.Add(this.LbEnglishName);
            this.groupBox1.Controls.Add(this.FineAmount);
            this.groupBox1.Controls.Add(this.LBMemberName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(917, 192);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fine Details :";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Member Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(391, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Book Arabic Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(391, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Book English Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fine Due Amount :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Late Days :";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(227, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pay.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(429, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel.";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // LBMemberName
            // 
            this.LBMemberName.AutoSize = true;
            this.LBMemberName.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBMemberName.Location = new System.Drawing.Point(200, 32);
            this.LBMemberName.Name = "LBMemberName";
            this.LBMemberName.Size = new System.Drawing.Size(0, 21);
            this.LBMemberName.TabIndex = 7;
            // 
            // FineAmount
            // 
            this.FineAmount.AutoSize = true;
            this.FineAmount.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FineAmount.Location = new System.Drawing.Point(223, 90);
            this.FineAmount.Name = "FineAmount";
            this.FineAmount.Size = new System.Drawing.Size(0, 21);
            this.FineAmount.TabIndex = 8;
            // 
            // LbEnglishName
            // 
            this.LbEnglishName.AutoSize = true;
            this.LbEnglishName.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbEnglishName.Location = new System.Drawing.Point(591, 90);
            this.LbEnglishName.Name = "LbEnglishName";
            this.LbEnglishName.Size = new System.Drawing.Size(0, 21);
            this.LbEnglishName.TabIndex = 9;
            // 
            // LBLateDays
            // 
            this.LBLateDays.AutoSize = true;
            this.LBLateDays.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLateDays.Location = new System.Drawing.Point(157, 149);
            this.LBLateDays.Name = "LBLateDays";
            this.LBLateDays.Size = new System.Drawing.Size(0, 21);
            this.LBLateDays.TabIndex = 10;
            // 
            // LbBookArabic
            // 
            this.LbBookArabic.AutoSize = true;
            this.LbBookArabic.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbBookArabic.Location = new System.Drawing.Point(571, 32);
            this.LbBookArabic.Name = "LbBookArabic";
            this.LbBookArabic.Size = new System.Drawing.Size(0, 21);
            this.LbBookArabic.TabIndex = 11;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(919, 488);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPaymentMethods);
            this.Name = "PaymentForm";
            this.Text = "PaymentForm";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPaymentMethods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label FineAmount;
        private System.Windows.Forms.Label LBMemberName;
        private System.Windows.Forms.Label LbBookArabic;
        private System.Windows.Forms.Label LBLateDays;
        private System.Windows.Forms.Label LbEnglishName;
    }
}