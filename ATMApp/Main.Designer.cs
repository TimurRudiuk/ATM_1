namespace ATMApp
{
    partial class Main
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WithdrawMoney = new System.Windows.Forms.Button();
            this.DepositMoney = new System.Windows.Forms.Button();
            this.TransferMoney = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BalanceLabel = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox3.Location = new System.Drawing.Point(-6, 578);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(386, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox4.Location = new System.Drawing.Point(-6, 578);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(386, 75);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox2.Location = new System.Drawing.Point(-6, 66);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(386, 15);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox1.Location = new System.Drawing.Point(-6, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Баланс:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(133, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 31);
            this.label2.TabIndex = 9;
            // 
            // WithdrawMoney
            // 
            this.WithdrawMoney.BackColor = System.Drawing.Color.Transparent;
            this.WithdrawMoney.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.WithdrawMoney.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WithdrawMoney.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.WithdrawMoney.Location = new System.Drawing.Point(18, 186);
            this.WithdrawMoney.Name = "WithdrawMoney";
            this.WithdrawMoney.Size = new System.Drawing.Size(344, 40);
            this.WithdrawMoney.TabIndex = 10;
            this.WithdrawMoney.Text = "Зняти кошти";
            this.WithdrawMoney.UseVisualStyleBackColor = false;
            this.WithdrawMoney.Click += new System.EventHandler(this.WithdrawButton_Click);
            // 
            // DepositMoney
            // 
            this.DepositMoney.BackColor = System.Drawing.Color.Transparent;
            this.DepositMoney.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DepositMoney.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DepositMoney.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DepositMoney.Location = new System.Drawing.Point(18, 242);
            this.DepositMoney.Name = "DepositMoney";
            this.DepositMoney.Size = new System.Drawing.Size(344, 40);
            this.DepositMoney.TabIndex = 11;
            this.DepositMoney.Text = "Зарахувати кошти";
            this.DepositMoney.UseVisualStyleBackColor = false;
            this.DepositMoney.Click += new System.EventHandler(this.DepositButton_Click);
            // 
            // TransferMoney
            // 
            this.TransferMoney.BackColor = System.Drawing.Color.Transparent;
            this.TransferMoney.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TransferMoney.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TransferMoney.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TransferMoney.Location = new System.Drawing.Point(18, 297);
            this.TransferMoney.Name = "TransferMoney";
            this.TransferMoney.Size = new System.Drawing.Size(344, 40);
            this.TransferMoney.TabIndex = 12;
            this.TransferMoney.Text = "Перерахування коштів";
            this.TransferMoney.UseVisualStyleBackColor = false;
            this.TransferMoney.Click += new System.EventHandler(this.TransferButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 31);
            this.label3.TabIndex = 13;
            // 
            // BalanceLabel
            // 
            this.BalanceLabel.AutoSize = true;
            this.BalanceLabel.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.BalanceLabel.Location = new System.Drawing.Point(133, 118);
            this.BalanceLabel.Name = "BalanceLabel";
            this.BalanceLabel.Size = new System.Drawing.Size(78, 31);
            this.BalanceLabel.TabIndex = 14;
            this.BalanceLabel.Text = "0 грн";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.BackColor = System.Drawing.Color.DarkGray;
            this.UserNameLabel.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.UserNameLabel.Location = new System.Drawing.Point(18, 18);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(70, 31);
            this.UserNameLabel.TabIndex = 15;
            this.UserNameLabel.Text = "User";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.DarkGray;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ExitButton.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ExitButton.Location = new System.Drawing.Point(252, 13);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(110, 40);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Вийти >";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 649);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.BalanceLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TransferMoney);
            this.Controls.Add(this.DepositMoney);
            this.Controls.Add(this.WithdrawMoney);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(390, 688);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button WithdrawMoney;
        private System.Windows.Forms.Button DepositMoney;
        private System.Windows.Forms.Button TransferMoney;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label BalanceLabel;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Button ExitButton;
    }
}