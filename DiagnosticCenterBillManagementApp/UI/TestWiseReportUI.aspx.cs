using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementApp.DAL;
using DiagnosticCenterBillManagementApp.Model.ViewModels;

namespace DiagnosticCenterBillManagementApp.UI
{
    public partial class TestWiseReportUI : System.Web.UI.Page
    {
        TestManager testManager = new TestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime date = DateTime.Now;
                testWiseFormDateTextBox.Text = date.ToShortDateString();
                testWiseToDateTextBox.Text = date.ToShortDateString();
                testWiseTotalTextBox.ReadOnly = true;
            }

        }

        protected void testWiseShowButton_Click(object sender, EventArgs e)
        {

            List<TestInfoReportViewModel> list = testManager.GetTestWiseReport(testWiseFormDateTextBox.Text, testWiseToDateTextBox.Text);
            testWiseReportGridView.DataSource = list;
            testWiseReportGridView.DataBind();

            double totalAmount = 0;

            foreach (var l in list)
            {
                totalAmount += l.TotalFee;
            }
            testWiseTotalTextBox.Text = totalAmount.ToString();

        }
    }
}