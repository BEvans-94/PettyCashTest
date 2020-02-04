namespace NetTest
{
    partial class PettyCash
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
            this.ucCashSpendF = new NetTest.UserControls.ucCashSpend();
            this.ucLoggedInF = new NetTest.UserControls.ucLoggedIn();
            this.ucLoginF = new NetTest.UserControls.ucLogin();
            this.ucTransactionsF = new NetTest.UserControls.ucTransactions();
            this.ucCashAddF = new NetTest.UserControls.ucCashAdd();
            this.ucUserProfileF = new NetTest.UserControls.ucUserProfile();
            this.SuspendLayout();
            // 
            // ucCashSpendF
            // 
            this.ucCashSpendF.Location = new System.Drawing.Point(25, 183);
            this.ucCashSpendF.Name = "ucCashSpendF";
            this.ucCashSpendF.Size = new System.Drawing.Size(428, 165);
            this.ucCashSpendF.TabIndex = 2;
            // 
            // ucLoggedInF
            // 
            this.ucLoggedInF.Location = new System.Drawing.Point(549, 257);
            this.ucLoggedInF.Name = "ucLoggedInF";
            this.ucLoggedInF.Size = new System.Drawing.Size(433, 163);
            this.ucLoggedInF.TabIndex = 1;
            // 
            // ucLoginF
            // 
            this.ucLoginF.Location = new System.Drawing.Point(12, 12);
            this.ucLoginF.Name = "ucLoginF";
            this.ucLoginF.Size = new System.Drawing.Size(430, 165);
            this.ucLoginF.TabIndex = 0;
            // 
            // ucTransactionsF
            // 
            this.ucTransactionsF.Location = new System.Drawing.Point(407, 12);
            this.ucTransactionsF.Name = "ucTransactionsF";
            this.ucTransactionsF.Size = new System.Drawing.Size(506, 295);
            this.ucTransactionsF.TabIndex = 3;
            // 
            // ucCashAddF
            // 
            this.ucCashAddF.Location = new System.Drawing.Point(25, 354);
            this.ucCashAddF.Name = "ucCashAddF";
            this.ucCashAddF.Size = new System.Drawing.Size(428, 165);
            this.ucCashAddF.TabIndex = 4;
            // 
            // ucUserProfileF
            // 
            this.ucUserProfileF.Location = new System.Drawing.Point(438, 426);
            this.ucUserProfileF.Name = "ucUserProfileF";
            this.ucUserProfileF.Size = new System.Drawing.Size(505, 313);
            this.ucUserProfileF.TabIndex = 5;
            // 
            // PettyCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 894);
            this.Controls.Add(this.ucUserProfileF);
            this.Controls.Add(this.ucCashAddF);
            this.Controls.Add(this.ucTransactionsF);
            this.Controls.Add(this.ucCashSpendF);
            this.Controls.Add(this.ucLoggedInF);
            this.Controls.Add(this.ucLoginF);
            this.Name = "PettyCash";
            this.Text = "PettyCash";
            this.Load += new System.EventHandler(this.PettyCash_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucLogin ucLoginF;
        private UserControls.ucLoggedIn ucLoggedInF;
        private UserControls.ucCashSpend ucCashSpendF;
        private UserControls.ucTransactions ucTransactionsF;
        private UserControls.ucCashAdd ucCashAddF;
        private UserControls.ucUserProfile ucUserProfileF;
    }
}