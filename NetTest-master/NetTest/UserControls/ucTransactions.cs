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

namespace NetTest.UserControls
{
    public partial class ucTransactions : UserControl
    {
        public ucTransactions()
        {
            InitializeComponent();
        }

        public void Display()
        {
            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.HideAll();

            p_mucs.m_ucTransactions.Left = p_mucs.m_ucLogin.Left;
            p_mucs.m_ucTransactions.Top = p_mucs.m_ucLogin.Top;
            p_mucs.m_ucTransactions.Show();

            p_mucs.m_ucTransactions.dgTransactions.DataSource = spGetTransactionsTableAdapter.GetData();
        }

        private void butMainMain_Click(object sender, EventArgs e)
        {
            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.m_ucLoggedIn.Display();
        }

        private void DgTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
