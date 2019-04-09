using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementApp.Model;
using DiagnosticCenterBillManagementApp.Model.ViewModels;

namespace DiagnosticCenterBillManagementApp.DAL
{
    public class TestTypeGateway : CommonGateway
    {
        public bool SaveTestType(TestType testType)
        {


            string query = "INSERT INTO TestType VALUES('" + testType.Name + "');";
            Command.CommandText = query;

            Connection.Open();
            bool rowAffected = Command.ExecuteNonQuery() > 0;

            Connection.Close();
            return rowAffected;

        }

        public List<TestType> GetAllTesType()
        {
            string query = "select * from TestType";

            List<TestType> testTypeList = new List<TestType>();

            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestType type = new TestType();
                    type.Id = Convert.ToInt32(reader["Id"]);
                    type.Name = reader["Name"].ToString();

                    testTypeList.Add(type);
                }

            }
            reader.Close();
            Connection.Close();

            return testTypeList;
        }

        public TestType GetTestTypeByName(TestType testType)
        {
            string query = "select * from TestType where Name='" + testType.Name + "';";

            TestType test = null;
            Command.CommandText = query;
            Connection.Open();

            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                test = new TestType();
                test.Name = reader["Name"].ToString();
            }
            reader.Close();
            Connection.Close();
            return test;
        }

        public List<TestTypeReportViewModel> GetTypeWiseReport(string fromDate,string toDate)
        {
            string query = "select tt.Name,COUNT(ti.Name) as TotalNumberOfaTest,SUM(ti.Fee) as TotalAmount  from TestType tt left join TestInfo ti on tt.Id = ti.TestTypeId left join TestRequest tr on ti.Id =tr.TestInfoId where tr.Date between '" + fromDate + "' and '" + toDate + "' group by tt.Name order by tt.Name";

            List<TestTypeReportViewModel> testTypeList = new List<TestTypeReportViewModel>();

            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestTypeReportViewModel tv = new TestTypeReportViewModel();

                    tv.Name = reader["Name"].ToString();
                    tv.TotalTest = Convert.ToInt32(reader["TotalNumberOfaTest"]);
                    tv.TotalAmount = Convert.ToDouble(reader["TotalAmount"]);

                    testTypeList.Add(tv);
                }

            }
            reader.Close();
            Connection.Close();

            return testTypeList;   
        }
    }
}