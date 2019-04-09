using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementApp.Model;
using DiagnosticCenterBillManagementApp.Model.ViewModels;

namespace DiagnosticCenterBillManagementApp.DAL
{
    public class PaymentManager
    {
        PaymentGateway paymentGateway=new PaymentGateway();
        PatientGateway patientGateway=new PatientGateway();
        public bool Save(Payment payment)
        {
            bool rowAffected = paymentGateway.Save(payment);
            if (rowAffected)
            {
                return true;
            }
            return false;
        }

        public Payment GetTotalBill(string billNumber)
        {
            if (IsBillNumberAvailable(billNumber))
            {
                return paymentGateway.GetTotalBill(billNumber);
            }
            return null;

        }

        private bool IsBillNumberAvailable(string billNumber)
        {
            Payment pay = paymentGateway.GetByBillNumber(billNumber);
            if (pay==null)
            {
                return false;
            }
            return true;
        }

        public Payment GetTotalBillByMobileNumber(string mobileNumber)
        {
            if (IsMobileNumberAvailable(mobileNumber))
            {
                return paymentGateway.GetTotalBillByMobileNumber(mobileNumber);
            }
            return null;
        }

        private bool IsMobileNumberAvailable(string mobileNumber)
        {
            Patient p = paymentGateway.GetPatientByMobileNumber(mobileNumber);
            if (p==null)
            {
                return false;
            }
            return true;
        }

        public bool Pay(string s, string value)
        {
            return paymentGateway.Pay(s,value);
        }

        public bool PayByBillNumber(string billNumber,string payDate)
        {
            return paymentGateway.PayByBillNumber(billNumber,payDate);
        }

        public List<UnpaidPatientViewModel> GetAllUnpaidPatientRecord(string text, string s)
        {
          return  paymentGateway.GetAllUnpaidPatientRecord(text, s);
        }
    }
}