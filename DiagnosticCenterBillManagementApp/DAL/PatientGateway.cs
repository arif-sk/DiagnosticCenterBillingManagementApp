using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementApp.Model;
using DiagnosticCenterBillManagementApp.Model.EntitiyModels;

namespace DiagnosticCenterBillManagementApp.DAL
{
    public class PatientGateway:CommonGateway
    {
        public Patient GetByMobileNumber(Patient patient)
        {
            string query = "select * from Patient where Mobile = '" + patient.MobileNumber + "';";

            Patient pt = null;
            Command.CommandText = query;
            Connection.Open();

            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                pt = new Patient();
                pt.Id = Convert.ToInt32(reader["Id"]);
                pt.Name = reader["Name"].ToString();
                pt.DOB = Convert.ToDateTime(reader["DOB"]);
                pt.MobileNumber = reader["Mobile"].ToString();
            }
            reader.Close();
            Connection.Close();
            return pt;
        }

        public bool SaveTestData(Patient patient)
        {
            string query = "INSERT INTO Patient VALUES('" + patient.Name + "','" + patient.DOB + "','" + patient.MobileNumber + "');";
            Command.CommandText = query;

            Connection.Open();
            bool rowAffected = Command.ExecuteNonQuery() > 0;

            Connection.Close();



            return rowAffected;
        }

        public int GetPatientByMobileNumber(string mobileNumber)
        {
            string query = "select * from Patient where Mobile = '" + mobileNumber + "';";

            Patient pt = null;
            Command.CommandText = query;
            Connection.Open();

            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                pt = new Patient();
                pt.Id = Convert.ToInt32(reader["Id"]);
                //pt.Name = reader["Name"].ToString();
                //pt.DOB = Convert.ToDateTime(reader["DOB"]);
                //pt.MobileNumber = reader["Mobile"].ToString();
            }
            reader.Close();
            Connection.Close();
            return pt.Id;
        }
    }
}