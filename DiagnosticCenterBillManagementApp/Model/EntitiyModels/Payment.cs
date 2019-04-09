using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementApp.Model
{
    public class Payment
    {
        public int Id { get; set; }
        private string billNumber;
        public bool Status { get; set; }
        private double totalAmount;
        public DateTime Created_at { get; set; }
        public int PatientId { get; set; }


        public string BillNumber
        {
            get { return billNumber; }
            set { billNumber = value; }
        }


        public double TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }

    }
}