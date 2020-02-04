namespace NetTest.UserControls
{
    partial class ucUserProfile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butMainMenu = new System.Windows.Forms.Button();
            this.lblUserProfile = new System.Windows.Forms.Label();
            this.dgLoginAudit = new System.Windows.Forms.DataGridView();
            this.lblFName = new System.Windows.Forms.Label();
            this.lblSName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRoles = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgLoginAudit)).BeginInit();
            this.SuspendLayout();
            // 
            // butMainMenu
            // 
            this.butMainMenu.Location = new System.Drawing.Point(3, 287);
            this.butMainMenu.Name = "butMainMenu";
            this.butMainMenu.Size = new System.Drawing.Size(75, 23);
            this.butMainMenu.TabIndex = 14;
            this.butMainMenu.Text = "Main Menu";
            this.butMainMenu.UseVisualStyleBackColor = true;
            this.butMainMenu.Click += new System.EventHandler(this.ButMainMenu_Click);
            // 
            // lblUserProfile
            // 
            this.lblUserProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserProfile.Location = new System.Drawing.Point(160, 12);
            this.lblUserProfile.Name = "lblUserProfile";
            this.lblUserProfile.Size = new System.Drawing.Size(185, 25);
            this.lblUserProfile.TabIndex = 13;
            this.lblUserProfile.Text = "User Profile";
            this.lblUserProfile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgLoginAudit
            // 
            this.dgLoginAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLoginAudit.Location = new System.Drawing.Point(20, 172);
            this.dgLoginAudit.Name = "dgLoginAudit";
            this.dgLoginAudit.Size = new System.Drawing.Size(462, 109);
            this.dgLoginAudit.TabIndex = 15;
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Location = new System.Drawing.Point(127, 64);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(41, 13);
            this.lblFName.TabIndex = 16;
            this.lblFName.Text = "FName";
            // 
            // lblSName
            // 
            this.lblSName.AutoSize = true;
            this.lblSName.Location = new System.Drawing.Point(127, 87);
            this.lblSName.Name = "lblSName";
            this.lblSName.Size = new System.Drawing.Size(42, 13);
            this.lblSName.TabIndex = 17;
            this.lblSName.Text = "SName";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(127, 109);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 18;
            this.lblUsername.Text = "Username";
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Location = new System.Drawing.Point(127, 132);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(34, 13);
            this.lblRoles.TabIndex = 19;
            this.lblRoles.Text = "Roles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Roles:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Surname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "First Name:";
            // 
            // ucUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRoles);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblSName);
            this.Controls.Add(this.lblFName);
            this.Controls.Add(this.dgLoginAudit);
            this.Controls.Add(this.butMainMenu);
            this.Controls.Add(this.lblUserProfile);
            this.Name = "ucUserProfile";
            this.Size = new System.Drawing.Size(505, 313);
            ((System.ComponentModel.ISupportInitialize)(this.dgLoginAudit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butMainMenu;
        private System.Windows.Forms.Label lblUserProfile;
        private System.Windows.Forms.DataGridView dgLoginAudit;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Label lblSName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
