using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementApp.DAL;
using DiagnosticCenterBillManagementApp.Model.EntitiyModels;

namespace DiagnosticCenterBillManagementApp.BLL
{
    public class TestRequestManager
    {
        TestRequestGateway testRequestGateway=new TestRequestGateway();
        public bool Save(List<TestRequest> testRequests)
        {
            bool rowAffected = testRequestGateway.Save(testRequests);
            if (rowAffected)
            {
                return true;
            }
            return false;
        }
    }
}