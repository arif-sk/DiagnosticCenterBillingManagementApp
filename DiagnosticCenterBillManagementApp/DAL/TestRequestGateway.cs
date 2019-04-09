using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using DiagnosticCenterBillManagementApp.Model.EntitiyModels;

namespace DiagnosticCenterBillManagementApp.DAL
{
    public class TestRequestGateway:CommonGateway
    {
        TestRequest tr=new TestRequest();
        public bool Save(List<TestRequest> testRequests)
        {
            bool rowAffected = false;
            foreach (TestRequest t in testRequests)
            {
                string query = "INSERT INTO TestRequest VALUES('" + t.PatientId + "','" + t.TestInfoId + "','" + t.Created_at + "');";
                Command.CommandText = query;

                Connection.Open();
                 rowAffected= Command.ExecuteNonQuery() > 0;
                 Connection.Close();
            }
            

            



            return rowAffected;
        }
    }
}