using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BizCare.Report;
using BizCare.Repository;

namespace BizCare.View
{
    public partial class ReportParamDateUI : Form
    {
        public ReportParamDateUI()
        {
            InitializeComponent();
        }


        public DateTime BeginDate
        {
            get { return dtpDateBegin.Value; }
        }

        public DateTime EndDate
        {
            get { return dtpDateEnd.Value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var frmReport = new ReportUI(this);
            frmReport.Show();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportParamDateUI_Load(object sender, EventArgs e)
        {
            int month = Store.ActiveMonth;
            int year = Store.ActiveYear;

            DateTime dtBegin=new DateTime(year,month,1);
            dtpDateBegin.Value = dtBegin;

            DateTime dtEnd = new DateTime(year,month,DateTime.DaysInMonth(year,month));
            dtpDateEnd.Value = dtEnd;


        }
    }
}
