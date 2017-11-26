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
    public partial class ReportParamPeriodUI : Form
    {
        public ReportParamPeriodUI()
        {
            InitializeComponent();
        }

        public int PeriodMonth
        {
            get { return Store.GetMonthCode(cboMonth.Text); }
        }

        public int PeriodYear
        {
            get { return Convert.ToInt32(nudYear.Value); }
        }

        private void FillMonth()
        {

            cboMonth.Items.Add("Januari");
            cboMonth.Items.Add("Februari");
            cboMonth.Items.Add("Maret");
            cboMonth.Items.Add("April");
            cboMonth.Items.Add("Mei");
            cboMonth.Items.Add("Juni");
            cboMonth.Items.Add("Juli");
            cboMonth.Items.Add("Agustus");
            cboMonth.Items.Add("September");
            cboMonth.Items.Add("Oktober");
            cboMonth.Items.Add("November");
            cboMonth.Items.Add("Desember");


        }

        private void ReportParamPeriodUI_Load(object sender, EventArgs e)
        {
            FillMonth();

            nudYear.Value = Store.ActiveYear;
            cboMonth.SelectedIndex = Store.ActiveMonth - 1;

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
    }
}
