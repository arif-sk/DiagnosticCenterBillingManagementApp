using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementApp.Model.ViewModels
{
    public class UnpaidPatientViewModel
    {


        public string BillNumber { get; set; }
        public string ContactNo { get; set; }
        public string PatientName { get; set; }
        public double BillAmount { get; set; }
    }
}