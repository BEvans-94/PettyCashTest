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
    public partial class ucCashAdd : UserControl
    {
        cAccount cAcc = null;
        public ucCashAdd()
        {
            InitializeComponent();
        }

        public void Display()
        {
            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.HideAll();

            p_mucs.m_ucCashAdd.Left = p_mucs.m_ucLogin.Left;
            p_mucs.m_ucCashAdd.Top = p_mucs.m_ucLogin.Top;
            p_mucs.m_ucCashAdd.Show();

            cAcc = new cAccount().checkLoggedIn();

        }

        private void butMainMenu_Click(object sender, EventArgs e)
        {
            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.m_ucLoggedIn.Display();
        }

        private void PCSAdd_Click(object sender, EventArgs e)
        {
            Exception ex = null;
            mUCs p_mucs = mUCs.s_mUCs;
            spCashUpdateTableAdapter ta = new spCashUpdateTableAdapter();
            Guid catid = Guid.Empty;
            Decimal cash = 0.0M;
            try
            {
                cash = Convert.ToDecimal(PCAamount.Text);
            }
            catch (Exception exc)
            {
                ex = exc;
            }
            if (cAcc != null)
            {
                sitedb.spCashUpdateDataTable dt = ta.GetData(DateTime.Now, cAcc.accId, catid, cash, "Ca");
            }
            p_mucs.m_ucLoggedIn.Display();
        }
    }
}
