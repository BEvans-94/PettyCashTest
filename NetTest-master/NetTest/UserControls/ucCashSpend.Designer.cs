namespace NetTest.UserControls
{
    partial class ucCashSpend
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.PCScombo = new System.Windows.Forms.ComboBox();
            this.spCashSpendCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.siteds = new NetTest.DataSets.sitedb();
            this.PCSamount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PCSspend = new System.Windows.Forms.Button();
            this.spCashSpendCategoryTableAdapter = new NetTest.DataSets.sitedbTableAdapters.spCashSpendCategoryTableAdapter();
            this.butMainMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spCashSpendCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteds)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Petty Cash Spend";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PCScombo
            // 
            this.PCScombo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.spCashSpendCategoryBindingSource, "pccId", true));
            this.PCScombo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.spCashSpendCategoryBindingSource, "ppcName", true));
            this.PCScombo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.spCashSpendCategoryBindingSource, "ppcName", true));
            this.PCScombo.DataSource = this.spCashSpendCategoryBindingSource;
            this.PCScombo.DisplayMember = "ppcName";
            this.PCScombo.FormattingEnabled = true;
            this.PCScombo.Location = new System.Drawing.Point(18, 57);
            this.PCScombo.Name = "PCScombo";
            this.PCScombo.Size = new System.Drawing.Size(121, 21);
            this.PCScombo.TabIndex = 7;
            // 
            // spCashSpendCategoryBindingSource
            // 
            this.spCashSpendCategoryBindingSource.DataMember = "spCashSpendCategory";
            this.spCashSpendCategoryBindingSource.DataSource = this.siteds;
            // 
            // siteds
            // 
            this.siteds.DataSetName = "siteds";
            this.siteds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PCSamount
            // 
            this.PCSamount.Location = new System.Drawing.Point(230, 57);
            this.PCSamount.Name = "PCSamount";
            this.PCSamount.Size = new System.Drawing.Size(71, 20);
            this.PCSamount.TabIndex = 8;
            this.PCSamount.TextChanged += new System.EventHandler(this.PCSamount_TextChanged);
            this.PCSamount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PCSamount_KeyPress);
            this.PCSamount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PCSamount_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Amount";
            // 
            // PCSspend
            // 
            this.PCSspend.Location = new System.Drawing.Point(350, 57);
            this.PCSspend.Name = "PCSspend";
            this.PCSspend.Size = new System.Drawing.Size(75, 23);
            this.PCSspend.TabIndex = 10;
            this.PCSspend.Text = "Spend";
            this.PCSspend.UseVisualStyleBackColor = true;
            this.PCSspend.Click += new System.EventHandler(this.PCSspend_Click);
            // 
            // spCashSpendCategoryTableAdapter
            // 
            this.spCashSpendCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // butMainMenu
            // 
            this.butMainMenu.Location = new System.Drawing.Point(18, 131);
            this.butMainMenu.Name = "butMainMenu";
            this.butMainMenu.Size = new System.Drawing.Size(75, 23);
            this.butMainMenu.TabIndex = 11;
            this.butMainMenu.Text = "Main Menu";
            this.butMainMenu.UseVisualStyleBackColor = true;
            this.butMainMenu.Click += new System.EventHandler(this.butMainMenu_Click);
            // 
            // ucCashSpend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.butMainMenu);
            this.Controls.Add(this.PCSspend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PCSamount);
            this.Controls.Add(this.PCScombo);
            this.Controls.Add(this.label3);
            this.Name = "ucCashSpend";
            this.Size = new System.Drawing.Size(428, 165);
            this.Load += new System.EventHandler(this.ucCashSpend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spCashSpendCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox PCScombo;
        private System.Windows.Forms.TextBox PCSamount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PCSspend;
        private System.Windows.Forms.BindingSource spCashSpendCategoryBindingSource;
        private DataSets.sitedb siteds;
        private DataSets.sitedbTableAdapters.spCashSpendCategoryTableAdapter spCashSpendCategoryTableAdapter;
        private System.Windows.Forms.Button butMainMenu;
    }
}
