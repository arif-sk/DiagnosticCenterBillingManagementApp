using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementApp.DAL;
using DiagnosticCenterBillManagementApp.Model;

namespace DiagnosticCenterBillManagementApp.UI
{
    public partial class PaymentUI : System.Web.UI.Page
    {
        PaymentManager paymentManager=new PaymentManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            payButton.Enabled = false;
        }

        protected void billOrMobileNumberSearchButton_Click(object sender, EventArgs e)
        {
        
            string billNumber = billNumberTextBox.Text;
            string mobileNumber = mobileNumberTextBox.Text;
            double totalBillAmount = 0;
            string date = DateTime.Now.ToShortDateString();
         
            //string s = date.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
            if (billNumberTextBox.Text!="")
            {
                
                Payment p = paymentManager.GetTotalBill(billNumber);
                if (p==null)
                {
                    messageLabel.Text = "No Due  Found";
                    amountTextBox.Text = "";
                }
                else
                {
                    amountTextBox.Text = p.TotalAmount.ToString();
                    dueDateTextBox.Text = date;
                    
                    paymentHiddenField.Value = p.PatientId.ToString();
                    payButton.Enabled = true;
                }

            }
            else
            {

                Payment p = paymentManager.GetTotalBillByMobileNumber(mobileNumber);
                if (p==null)
                {
                    messageLabel.Text = "Not Due Found";
                    amountTextBox.Text = "";
                }
                else
                {
                    amountTextBox.Text = p.TotalAmount.ToString();
                    dueDateTextBox.Text = date; 
                    paymentHiddenField.Value = p.PatientId.ToString();
                    payButton.Enabled = true;
                }
            }
            
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            if (mobileNumberTextBox.Text!="")
            {
                bool rowAffected = paymentManager.Pay(paymentHiddenField.Value, dueDateTextBox.Text);
                if (rowAffected)
                {
                    messageLabel.Text = "Payment Successfull";
                    dueDateTextBox.Text = "";
                    amountTextBox.Text = "";
                    payButton.Enabled = false;

                }
                else
                {
                    messageLabel.Text = "Payment Unsuccessfull";
                    amountTextBox.Text = "";
                    dueDateTextBox.Text = "";
                    payButton.Enabled = false;
                }   
            }
            else
            {
                bool rowAffected = paymentManager.PayByBillNumber(billNumberTextBox.Text,dueDateTextBox.Text);
                if (rowAffected)
                {
                    messageLabel.Text = "Payment Successfull";
                    dueDateTextBox.Text = "";
                    amountTextBox.Text = "";

                }
                else
                {
                    messageLabel.Text = "Payment Unsuccessfull";
                    amountTextBox.Text = "";
                    dueDateTextBox.Text = "";
                }   
            }
         
        }
    }
}