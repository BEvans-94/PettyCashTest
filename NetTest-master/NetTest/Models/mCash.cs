using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTest.DataSets;
using NetTest.DataSets.sitedbTableAdapters;

namespace NetTest.Models
{
    class mCash
    {
        public mCash()
        {

        }

        public string getBalance()
        {
            decimal retd = 0;
            List<cCash> lCash = cashTransactionList();
            if (lCash != null && lCash.Count >0)
            {
                retd = lCash[0].pcaAmountCurrent;
            }

            string ret = String.Format("£{0:0.00}", retd);
            return ret;

        }

        public List<cCash> cashTransactionList()
        {
            List<cCash> ret = null;

            spCashReadListTableAdapter ta = new spCashReadListTableAdapter();
            sitedb.spCashReadListDataTable dt = ta.GetData();

            if (dt!= null && dt.Rows.Count >0)
            {
                ret = new List<cCash>();

                foreach(sitedb.spCashReadListRow dr in dt)
                {
                    ret.Add(new cCash(dr));
;                }
            }

            return ret;
        }
    }

    class cCash
    {
        public cCash(sitedb.spCashReadListRow dr)
        {
            pcaDT = dr.pcaDT;
            pcaAmount = dr.pcaAmount;
            pcaAmountCurrent = dr.pcaAmountCurrent;
            accUserName = dr.accUserName;
        }

        public DateTime pcaDT;
        public decimal pcaAmount;
        public decimal pcaAmountCurrent;
        public string accUserName;

    }
}
