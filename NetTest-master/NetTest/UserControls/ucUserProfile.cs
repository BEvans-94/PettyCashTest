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
using NetTest.DataSets.sitedbTableAdapters;
using System.Data.SqlClient;

namespace NetTest.UserControls
{
    public partial class ucUserProfile : UserControl
    {
        mAccount acc = null;
        cAccount cAcc = null;

        public ucUserProfile()
        {
            InitializeComponent();
        }

        public void Display()
        {
            //Simlar to the other display methods ----------------------

            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.HideAll();

            p_mucs.m_ucUserProfile.Left = p_mucs.m_ucLogin.Left;
            p_mucs.m_ucUserProfile.Top = p_mucs.m_ucLogin.Top;
            p_mucs.m_ucUserProfile.Show();

            acc = new mAccount();
            Guid? mAccount = acc.accountLoggedIn();

            if (acc == null || mAccount == Guid.Empty)
            {

            }
            else
            {
                cAcc = new cAccount().readById((Guid)mAccount);
                //Check if should log out
                TimeSpan ts = DateTime.Now - cAcc.accDT;
                if (ts.Minutes >= 5)
                {
                    p_mucs.m_ucLogin.Display();
                }
            }
            //-------------------------------------------------------------


            p_mucs.m_ucUserProfile.lblFName.Text = cAcc.accFirstName;
            p_mucs.m_ucUserProfile.lblSName.Text = cAcc.accLastName;
            p_mucs.m_ucUserProfile.lblUsername.Text = cAcc.accUserName;
            p_mucs.m_ucUserProfile.lblRoles.Text = string.Empty;

            if (cAcc.accAccountTypeList != null && cAcc.accAccountTypeList.Count > 0)
            {
                p_mucs.m_ucUserProfile.lblRoles.Text = string.Join(", ", cAcc.accAccountTypeList.Select(x => x.actName));
                //p_mucs.m_ucUserProfile.lblFName.Text.TrimEnd(new char[] { ' ', ',' });
            }

            //Apologies, without spending a fair amount of time looking into your SQL adapter/connection pattern I don't fully understand how it works.
            //Normally I use dapper, however rather than start trying to implement that i'm resulting to a very simplistic way of querying.
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("EventTime");
                dt.Columns.Add("EventType");

                using (var connection = new SqlConnection(global::NetTest.Properties.Settings.Default.sitedbConnectionString))
                {
                    if (connection.State != ConnectionState.Open) connection.Open();

                    var cmd = new SqlCommand("spGetLoginTimesByAccountId", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountId", cAcc.accId.ToString());

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dt.Rows.Add(dr[0], dr[1]);
                        }
                    }
                    p_mucs.m_ucUserProfile.dgLoginAudit.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                //Log error
            }
        }

        private void ButMainMenu_Click(object sender, EventArgs e)
        {
            mUCs p_mucs = mUCs.s_mUCs;
            p_mucs.m_ucLoggedIn.Display();
        }
    }
}
