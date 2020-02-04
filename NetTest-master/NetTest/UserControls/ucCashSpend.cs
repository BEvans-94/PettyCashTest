using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetTest.Models;
using NetTest.DataSets;
using NetTest.DataSets.sitedbTableAdapters;

namespace NetTest.UserControls
{
    public partial class ucCashSpend : UserControl
    {
        cAccount cAcc = null;

        decimal amount = 0;

        public ucCashSpend()
        {
            InitializeComponent();
        }

        public void Display()
        {
            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.HideAll();

            p_mucs.m_ucCashSpend.Left = p_mucs.m_ucLogin.Left;
            p_mucs.m_ucCashSpend.Top = p_mucs.m_ucLogin.Top;
            p_mucs.m_ucCashSpend.Show();

            cAcc = new cAccount().checkLoggedIn();

            PCScombo.DataSource = spCashSpendCategoryTableAdapter.GetData();
        }



        private void ucCashSpend_Load(object sender, EventArgs e)
        {

        }


        private void PCSamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void PCSamount_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void PCSamount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void PCSspend_Click(object sender, EventArgs e)
        {
            Exception ex = null;
            mUCs p_mucs = mUCs.s_mUCs;
            spCashUpdateTableAdapter ta = new spCashUpdateTableAdapter();
            DataRowView drv = (DataRowView) PCScombo.SelectedItem;
            Guid catid = Guid.Parse(drv.Row["pccId"].ToString());
            //Guid catid = Guid.Parse("1AE2822A-1EC5-4E29-9670-56101BED344C");
            Decimal cash = 0.0M;
            try
            {
                cash = Convert.ToDecimal(PCSamount.Text);
            }
            catch (Exception exc)
            {
                ex = exc;
            }
            if (cAcc != null)
            {
                sitedb.spCashUpdateDataTable dt = ta.GetData(DateTime.Now, cAcc.accId, catid, cash, "Cs");
            }
            p_mucs.m_ucLoggedIn.Display();
        }

        private void butMainMenu_Click(object sender, EventArgs e)
        {
            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.m_ucLoggedIn.Display();
        }
    }
}
