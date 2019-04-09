using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementApp.Model;
using DiagnosticCenterBillManagementApp.Model.EntitiyModels;
using DiagnosticCenterBillManagementApp.Model.ViewModels;

namespace DiagnosticCenterBillManagementApp.DAL
{
   
    public class TestManager
    {
        private TestTypeManager testTypeManager = new TestTypeManager();
        private  TestGateway testGateway = new TestGateway();

        public TestManager()
        {
        }

        public List<TestType> GetAllTestType()
        {
            return testTypeManager.GetAllTesType();
        }

        public bool SaveTestData(Test test)
        {
            if (IsValidData(test) && IsTestNameAvailable(test))
            {
                bool rowAffected = testGateway.SaveTestData(test);
                if (rowAffected)
                {
                    test.Message = "Save Successfully";
                    return true;
                }
                
            }
            return false;
        }

        public bool IsTestNameAvailable(Test test)
        {
            Test t = testGateway.GetByTestName(test);
            if (t==null)
            {
                return true;
            }
            test.Message = "Duplicate Test Name!";
            return false;
        }

        public bool IsValidData(Test test)
        {
            if (!string.IsNullOrEmpty(test.Name)&&
                test.Fee>=0 &&
                test.TestTypeId>=0)
            {
                return true;
            }
            test.Message = "Please provide test name";
            return false;
        }

        public List<TestTestTypeViewModel> GetAllTestTestInformation()
        {
            return testGateway.GetAllTestTestInformation();
        }

        public List<Test> GetAllTest()
        {
            return testGateway.GetAllTest();
        }

        public double GetFeeByTestID(int id)
        {
            Test t=new Test();
            t.Fee = testGateway.GetFeeByTestID(id);
            return t.Fee;
        }

        public List<TestInfoReportViewModel> GetTestWiseReport(string fromDate, string toDate)
        {
            return testGateway.GetTestWiseReport(fromDate, toDate);
        }
    }
}