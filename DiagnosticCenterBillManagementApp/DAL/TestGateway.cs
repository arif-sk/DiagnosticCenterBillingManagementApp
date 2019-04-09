using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementApp.Model;
using DiagnosticCenterBillManagementApp.Model.EntitiyModels;
using DiagnosticCenterBillManagementApp.Model.ViewModels;

namespace DiagnosticCenterBillManagementApp.DAL
{
    public class TestGateway : CommonGateway
    {
        public bool SaveTestData(Test test)
        {

            string query = "INSERT INTO TestInfo VALUES('" + test.Name + "'," + test.Fee + "," + test.TestTypeId + ");";
             Command.CommandText = query;

            Connection.Open();
            bool rowAffected = Command.ExecuteNonQuery() > 0;

            Connection.Close();



            return rowAffected;
        }

        public List<Test> GetAllTest()
        {
            string query = "select * from TestInfo";

            List<Test> testTypeList = new List<Test>();

            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Test type = new Test();
                    type.Id = Convert.ToInt32(reader["Id"]);
                    type.Name = reader["Name"].ToString();
                    type.Fee = Convert.ToDouble(reader["Fee"]);
                    type.TestTypeId = (int)reader["TestTypeId"];

                    testTypeList.Add(type);
                }

            }
            reader.Close();
            Connection.Close();

            return testTypeList;
        }

        public Test GetByTestName(Test test)
        {
            string query = "select * from TestInfo where Name='" + test.Name + "';";

            Test t = null;
            Command.CommandText = query;
            Connection.Open();

            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                t = new Test();
                t.Id = Convert.ToInt32(reader["Id"]);
                t.Name = reader["Name"].ToString();
                t.Fee = Convert.ToDouble(reader["Fee"]);
                t.TestTypeId = Convert.ToInt32(reader["TestTypeId"]);
            }
            reader.Close();
            Connection.Close();
            return t;
        }

        public List<TestTestTypeViewModel> GetAllTestTestInformation()
        {
            string query = "select ti.Id,ti.Name,ti.Fee,tt.Id as TestTypeId,tt.Name as TestTypeName from  TestInfo ti inner join TestType tt on ti.TestTypeId=tt.Id;";

            List<TestTestTypeViewModel> testTestTypeViewModelList = new List<TestTestTypeViewModel>();

            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestTestTypeViewModel testTestTypeViewModel = new TestTestTypeViewModel();
                    testTestTypeViewModel.Id = Convert.ToInt32(reader["Id"]);
                    testTestTypeViewModel.Name = reader["Name"].ToString();
                    testTestTypeViewModel.Fee = Convert.ToDouble(reader["Fee"]);
                    testTestTypeViewModel.TestTypeId = (int)reader["TestTypeId"];
                    testTestTypeViewModel.TestTypeName = reader["TestTypeName"].ToString();

                    testTestTypeViewModelList.Add(testTestTypeViewModel);
                }

            }
            reader.Close();
            Connection.Close();

            return testTestTypeViewModelList;
        }



        public double GetFeeByTestID(int id)
        {
            string query = "select Fee from TestInfo where Id='" + id + "';";

            Command.CommandText = query;
            Connection.Open();

            SqlDataReader reader = Command.ExecuteReader();
            Test ttt = new Test();
            if (reader.HasRows)
            {
                reader.Read();
                
                ttt.Fee = Convert.ToDouble(reader["Fee"]);
            }
            reader.Close();
            Connection.Close();
            return ttt.Fee;
            
        }

        public List<TestInfoReportViewModel> GetTestWiseReport(string fromDate, string toDate)
        {
            string query = "select ti.Name,COUNT(ti.Name) as totalTest,SUM(ti.Fee) as totalFee from TestInfo ti inner join TestRequest tr on ti.Id=tr.TestInfoId where tr.Date between '"+fromDate+"' and '"+toDate+"' group by ti.Name order by ti.Name";

            List<TestInfoReportViewModel> testTypeList = new List<TestInfoReportViewModel>();

            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestInfoReportViewModel tv = new TestInfoReportViewModel();
                    
                    tv.Name = reader["Name"].ToString();
                    tv.TotalTest = Convert.ToInt32(reader["totalTest"]);
                    tv.TotalFee = Convert.ToDouble(reader["totalFee"]);

                    testTypeList.Add(tv);
                }

            }
            reader.Close();
            Connection.Close();

            return testTypeList;
        }
    }
}