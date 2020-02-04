using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetTest.Models;

namespace NetTest
{
    public partial class PettyCash : Form
    {
        
        public PettyCash()
        {
            InitializeComponent();
            mUCs.s_mUCs = new mUCs(ucLoginF, ucLoggedInF, ucCashSpendF, ucCashAddF, ucTransactionsF, ucUserProfileF);
        }

        private void PettyCash_Load(object sender, EventArgs e)
        {
            mUCs.s_mUCs.HideAll();

            mAccount acc = new mAccount();

            Guid? acnt = acc.accountLoggedIn();
            //acnt = null; //Had to run this when swapping users as it was keeping me logged in...

            if (acnt == null)
            {
                mUCs.s_mUCs.m_ucLogin.Show();
            }
            else
            {
                mUCs.s_mUCs.m_ucLoggedIn.Display();
            }

        }

    }
}
