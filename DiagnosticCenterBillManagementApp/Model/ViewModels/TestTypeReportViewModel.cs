using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace DiagnosticCenterBillManagementApp.Model.ViewModels
{
    public class TestTypeReportViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalTest { get; set; }

        public double TotalAmount { get; set; }
        
    }
}