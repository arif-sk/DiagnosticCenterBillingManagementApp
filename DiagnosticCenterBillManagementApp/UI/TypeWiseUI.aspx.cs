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
    public partial class TypeWiseUI : System.Web.UI.Page
    {
        TestTypeManager testTypeManager = new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime date = DateTime.Now;
                typeWiseFormDateTextBox.Text = date.ToShortDateString();
                typeWiseToDateTextBox.Text = date.ToShortDateString();
                typeWiseTotalTextBox.ReadOnly = true;
            }
        }

        protected void typeWiseShowButton_Click(object sender, EventArgs e)
        {


            List<TestTypeReportViewModel> list = testTypeManager.GetTypeWiseReport(typeWiseFormDateTextBox.Text, typeWiseToDateTextBox.Text);

            typeWiseReportGridView.DataSource = list;
            typeWiseReportGridView.DataBind();


            double totalAmount = 0;
            foreach (var l in list)
            {
                totalAmount += l.TotalAmount;
            }

            typeWiseTotalTextBox.Text = totalAmount.ToString();


        }
    }
}