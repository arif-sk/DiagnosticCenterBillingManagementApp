using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementApp.Model;
using DiagnosticCenterBillManagementApp.Model.ViewModels;

namespace DiagnosticCenterBillManagementApp.DAL
{
    public class TestTypeManager
    {
        TestTypeGateway _testTypeGateway=new TestTypeGateway();
        public bool SaveTestType(TestType testType)
        {
            if (IsValidData(testType)&&IsTestTypeAvailable(testType))
            {
                _testTypeGateway.SaveTestType(testType);

                return true;
            }
            return false;
        }

        private bool IsTestTypeAvailable(TestType testType)
        {
            TestType test = _testTypeGateway.GetTestTypeByName(testType);
            if (test==null)
            {
                return true;
            }
            return false;
        }

        private bool IsValidData(TestType testType)
        {
            if (!string.IsNullOrEmpty(testType.Name))
            {
                return true;
            }
            return false;
        }

        public List<TestType> GetAllTesType()
        {
            return _testTypeGateway.GetAllTesType();
        }

        public List<TestTypeReportViewModel> GetTypeWiseReport(string fromDate, string toDate)
        {
            return _testTypeGateway.GetTypeWiseReport(fromDate, toDate);
        }
    }
}