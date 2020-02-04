using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTest.UserControls;
namespace NetTest.Models
{
    public class mUCs
    {
        public mUCs(ucLogin login, ucLoggedIn loggedin, ucCashSpend cashSpend, ucCashAdd cashAdd, ucTransactions trans, ucUserProfile userProf)
        {
            m_ucLogin = login;
            m_ucLoggedIn = loggedin;
            m_ucCashSpend = cashSpend;
            m_ucCashAdd = cashAdd;
            m_ucTransactions = trans;
            m_ucUserProfile = userProf;
        }

        public void HideAll()
        {
            m_ucLogin.Hide();
            m_ucLoggedIn.Hide();
            m_ucCashAdd.Hide();
            m_ucCashSpend.Hide();
            m_ucTransactions.Hide();
            m_ucUserProfile.Hide();
        }

        public static mUCs s_mUCs;

        public ucTransactions m_ucTransactions;
        public ucCashSpend m_ucCashSpend;
        public ucCashAdd m_ucCashAdd;
        public ucLogin m_ucLogin;
        public ucLoggedIn m_ucLoggedIn;
        public ucUserProfile m_ucUserProfile;
    }
}
