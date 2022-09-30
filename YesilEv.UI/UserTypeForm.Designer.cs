namespace YesilEv.UI
{
    partial class UserTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserTypeForm));
            this.btnUserList = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.premiumOrNormalUserComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PremiumradioButton1 = new System.Windows.Forms.RadioButton();
            this.NormalradioButton2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RolcomboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnUserList
            // 
            this.btnUserList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUserList.BackColor = System.Drawing.Color.SeaGreen;
            this.btnUserList.FlatAppearance.BorderSize = 0;
            this.btnUserList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserList.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F);
            this.btnUserList.ForeColor = System.Drawing.Color.White;
            this.btnUserList.Image = ((System.Drawing.Image)(resources.GetObject("btnUserList.Image")));
            this.btnUserList.Location = new System.Drawing.Point(571, 12);
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.Size = new System.Drawing.Size(55, 73);
            this.btnUserList.TabIndex = 100;
            this.btnUserList.UseVisualStyleBackColor = false;
            this.btnUserList.Click += new System.EventHandler(this.btnUserList_Click);
            // 
            // button7
            // 
            this.button7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button7.BackColor = System.Drawing.Color.SeaGreen;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(12, 344);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(39, 47);
            this.button7.TabIndex = 115;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // premiumOrNormalUserComboBox
            // 
            this.premiumOrNormalUserComboBox.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.premiumOrNormalUserComboBox.FormattingEnabled = true;
            this.premiumOrNormalUserComboBox.Location = new System.Drawing.Point(277, 48);
            this.premiumOrNormalUserComboBox.Name = "premiumOrNormalUserComboBox";
            this.premiumOrNormalUserComboBox.Size = new System.Drawing.Size(235, 31);
            this.premiumOrNormalUserComboBox.TabIndex = 116;
            this.premiumOrNormalUserComboBox.SelectedIndexChanged += new System.EventHandler(this.premiumOrNormalUserComboBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(277, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(235, 46);
            this.button1.TabIndex = 117;
            this.button1.Text = "Güncelle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PremiumradioButton1
            // 
            this.PremiumradioButton1.AutoSize = true;
            this.PremiumradioButton1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F);
            this.PremiumradioButton1.Location = new System.Drawing.Point(12, 52);
            this.PremiumradioButton1.Name = "PremiumradioButton1";
            this.PremiumradioButton1.Size = new System.Drawing.Size(183, 27);
            this.PremiumradioButton1.TabIndex = 119;
            this.PremiumradioButton1.TabStop = true;
            this.PremiumradioButton1.Text = "Premium Kullanıcılar";
            this.PremiumradioButton1.UseVisualStyleBackColor = true;
            this.PremiumradioButton1.CheckedChanged += new System.EventHandler(this.PremiumradioButton1_CheckedChanged);
            // 
            // NormalradioButton2
            // 
            this.NormalradioButton2.AutoSize = true;
            this.NormalradioButton2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F);
            this.NormalradioButton2.Location = new System.Drawing.Point(12, 101);
            this.NormalradioButton2.Name = "NormalradioButton2";
            this.NormalradioButton2.Size = new System.Drawing.Size(171, 27);
            this.NormalradioButton2.TabIndex = 120;
            this.NormalradioButton2.TabStop = true;
            this.NormalradioButton2.Text = "Normal Kullanıcılar";
            this.NormalradioButton2.UseVisualStyleBackColor = true;
            this.NormalradioButton2.CheckedChanged += new System.EventHandler(this.NormalradioButton2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F);
            this.label1.Location = new System.Drawing.Point(350, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 121;
            this.label1.Text = "Kullanıcılar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F);
            this.label2.Location = new System.Drawing.Point(362, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 23);
            this.label2.TabIndex = 122;
            this.label2.Text = "Roller";
            // 
            // RolcomboBox1
            // 
            this.RolcomboBox1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RolcomboBox1.FormattingEnabled = true;
            this.RolcomboBox1.Location = new System.Drawing.Point(277, 151);
            this.RolcomboBox1.Name = "RolcomboBox1";
            this.RolcomboBox1.Size = new System.Drawing.Size(235, 31);
            this.RolcomboBox1.TabIndex = 123;
            this.RolcomboBox1.SelectedIndexChanged += new System.EventHandler(this.RolcomboBox1_SelectedIndexChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F);
            this.radioButton1.Location = new System.Drawing.Point(12, 152);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 27);
            this.radioButton1.TabIndex = 124;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Adminler";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // UserTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 400);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.RolcomboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NormalradioButton2);
            this.Controls.Add(this.PremiumradioButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.premiumOrNormalUserComboBox);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnUserList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserTypeForm";
            this.Text = "UserTypeForm";
            this.Load += new System.EventHandler(this.UserTypeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUserList;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox premiumOrNormalUserComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton PremiumradioButton1;
        private System.Windows.Forms.RadioButton NormalradioButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox RolcomboBox1;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}