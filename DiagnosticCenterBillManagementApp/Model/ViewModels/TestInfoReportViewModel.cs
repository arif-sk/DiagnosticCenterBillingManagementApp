using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementApp.Model.ViewModels
{
    public class TestInfoReportViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalTest { get; set; }
        public double TotalFee { get; set; }
    }
}