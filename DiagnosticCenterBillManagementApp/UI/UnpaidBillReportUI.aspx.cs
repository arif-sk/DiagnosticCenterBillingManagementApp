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
    public partial class UnpaidBillReportUI : System.Web.UI.Page
    {

        private  PaymentManager _paymentManager=new PaymentManager();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime date = DateTime.Now;
                unpaidBillFormDateTextBox.Text = date.ToShortDateString();
                unpaidBillToDateTextBox.Text = date.ToShortDateString();
            }
            unpaidBillTotalTextBox.ReadOnly = true;
        }

        protected void unpaidBillShowButton_Click(object sender, EventArgs e)
        {


            //SELECT * FROM Patient pt inner join Payment py on pt.Id=py.PatientId where Status='False' and Date between '2017-09-23' AND  '2017-09-23'  


             List<UnpaidPatientViewModel>  list= _paymentManager.GetAllUnpaidPatientRecord(unpaidBillFormDateTextBox.Text,unpaidBillToDateTextBox.Text);
            unpaidBillReportGridView.DataSource = list;
            unpaidBillReportGridView.DataBind();

            double totalUnpaidAmount = 0;

            foreach (var l in list)
            {
                totalUnpaidAmount += l.BillAmount;
            }


            unpaidBillTotalTextBox.Text = totalUnpaidAmount.ToString();
        }



    }
}