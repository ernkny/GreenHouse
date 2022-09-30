namespace YesilEv.UI
{
    partial class SubstanceRiskDetectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubstanceRiskDetectionForm));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.düsükRadioButton = new System.Windows.Forms.RadioButton();
            this.ortaRadioButton = new System.Windows.Forms.RadioButton();
            this.yüksekRadioButton = new System.Windows.Forms.RadioButton();
            this.btnAramaGecmisi = new System.Windows.Forms.Button();
            this.btnUserList = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(152, 113);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(293, 37);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // düsükRadioButton
            // 
            this.düsükRadioButton.AutoSize = true;
            this.düsükRadioButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F);
            this.düsükRadioButton.Location = new System.Drawing.Point(90, 185);
            this.düsükRadioButton.Name = "düsükRadioButton";
            this.düsükRadioButton.Size = new System.Drawing.Size(136, 33);
            this.düsükRadioButton.TabIndex = 1;
            this.düsükRadioButton.TabStop = true;
            this.düsükRadioButton.Text = "Düşük Risk";
            this.düsükRadioButton.UseVisualStyleBackColor = true;
            // 
            // ortaRadioButton
            // 
            this.ortaRadioButton.AutoSize = true;
            this.ortaRadioButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F);
            this.ortaRadioButton.Location = new System.Drawing.Point(232, 185);
            this.ortaRadioButton.Name = "ortaRadioButton";
            this.ortaRadioButton.Size = new System.Drawing.Size(117, 33);
            this.ortaRadioButton.TabIndex = 2;
            this.ortaRadioButton.TabStop = true;
            this.ortaRadioButton.Text = "Orta Risk";
            this.ortaRadioButton.UseVisualStyleBackColor = true;
            // 
            // yüksekRadioButton
            // 
            this.yüksekRadioButton.AutoSize = true;
            this.yüksekRadioButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F);
            this.yüksekRadioButton.Location = new System.Drawing.Point(355, 185);
            this.yüksekRadioButton.Name = "yüksekRadioButton";
            this.yüksekRadioButton.Size = new System.Drawing.Size(142, 33);
            this.yüksekRadioButton.TabIndex = 3;
            this.yüksekRadioButton.TabStop = true;
            this.yüksekRadioButton.Text = "Yüksek Risk";
            this.yüksekRadioButton.UseVisualStyleBackColor = true;
            // 
            // btnAramaGecmisi
            // 
            this.btnAramaGecmisi.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAramaGecmisi.FlatAppearance.BorderSize = 0;
            this.btnAramaGecmisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAramaGecmisi.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F);
            this.btnAramaGecmisi.ForeColor = System.Drawing.Color.White;
            this.btnAramaGecmisi.Location = new System.Drawing.Point(123, 261);
            this.btnAramaGecmisi.Name = "btnAramaGecmisi";
            this.btnAramaGecmisi.Size = new System.Drawing.Size(351, 53);
            this.btnAramaGecmisi.TabIndex = 42;
            this.btnAramaGecmisi.Text = "Onayla";
            this.btnAramaGecmisi.UseVisualStyleBackColor = false;
            this.btnAramaGecmisi.Click += new System.EventHandler(this.btnAramaGecmisi_Click);
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
            this.btnUserList.Location = new System.Drawing.Point(520, 12);
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.Size = new System.Drawing.Size(55, 73);
            this.btnUserList.TabIndex = 43;
            this.btnUserList.UseVisualStyleBackColor = false;
            this.btnUserList.Click += new System.EventHandler(this.btnUserList_Click);
            // 
            // button5
            // 
            this.button5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button5.BackColor = System.Drawing.Color.SeaGreen;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(12, 348);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 49);
            this.button5.TabIndex = 82;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // SubstanceRiskDetectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 415);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnUserList);
            this.Controls.Add(this.btnAramaGecmisi);
            this.Controls.Add(this.yüksekRadioButton);
            this.Controls.Add(this.ortaRadioButton);
            this.Controls.Add(this.düsükRadioButton);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SubstanceRiskDetectionForm";
            this.Text = "SubstanceRiskDetectionForm";
            this.Load += new System.EventHandler(this.SubstanceRiskDetectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton düsükRadioButton;
        private System.Windows.Forms.RadioButton ortaRadioButton;
        private System.Windows.Forms.RadioButton yüksekRadioButton;
        private System.Windows.Forms.Button btnAramaGecmisi;
        private System.Windows.Forms.Button btnUserList;
        private System.Windows.Forms.Button button5;
    }
}