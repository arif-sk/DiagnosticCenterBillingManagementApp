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
    public class PaymentGateway:CommonGateway
    {
        public bool Save(Payment payment)
        {
            string query = "INSERT INTO Payment VALUES('" + payment.BillNumber + "','" + payment.TotalAmount + "','" + payment.Created_at + "','"+payment.Status+"','"+payment.PatientId+"');";
            Command.CommandText = query;

            Connection.Open();
            bool rowAffected = Command.ExecuteNonQuery() > 0;

            Connection.Close();



            return rowAffected;
        }

        public Payment GetTotalBill(string billNumber)
        {
            string query = "select * from Payment where BillNumber='" + billNumber + "';";

            Payment p = null;
            Command.CommandText = query;
            Connection.Open();

            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                p = new Payment();
                p.PatientId = Convert.ToInt32(reader["PatientId"]);
                p.TotalAmount = Convert.ToDouble(reader["TotalBill"]);
            }
            reader.Close();
            Connection.Close();
            return p;
        }

        public Payment GetByBillNumber(string billNumber)
        {
            string query = "select * from Payment where BillNumber='" + billNumber + "';";

            Payment pt = null;
            Command.CommandText = query;
            Connection.Open();

            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                pt = new Payment();
                pt.BillNumber = reader["BillNumber"].ToString();
                pt.TotalAmount = Convert.ToDouble(reader["TotalBill"]);
            }
            reader.Close();
            Connection.Close();
            return pt;
        }

        public Patient GetPatientByMobileNumber(string mobileNumber)
        {
            string query = "select * from Patient where Mobile='" + mobileNumber + "';";

            Patient p = null;
            Command.CommandText = query;
            Connection.Open();

            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                p = new Patient();
                p.Id = Convert.ToInt32(reader["Id"]);
                p.MobileNumber = reader["Mobile"].ToString();
            }
            reader.Close();
            Connection.Close();
            return p;
        }

        public Payment GetTotalBillByMobileNumber(string mobileNumber)
        {
            string query = "select pay.PatientId,pay.TotalBill from Patient p inner join Payment pay on p.Id=pay.PatientId where p.Mobile='"+mobileNumber+"' and pay.Status='false'; ";

            Payment p = null;
            Command.CommandText = query;
            Connection.Open();

            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                p = new Payment();
                while (reader.Read())
                {
                    p.PatientId = Convert.ToInt32(reader["PatientId"]);
                    p.TotalAmount += Convert.ToDouble(reader["TotalBill"]);
                }
                
              
            }
            reader.Close();
            Connection.Close();
            return p;
        }

        public bool Pay(string s, string value)
        {
           
            string query = "update Payment set Date='"+value+"', Status='True' where PatientId='"+s+"' ";
            Command.CommandText = query;

            Connection.Open();
            bool rowAffected = Command.ExecuteNonQuery() > 0;

            Connection.Close();



            return rowAffected;
        }

        public bool PayByBillNumber(string billNumber,string payDate)
        {
            string query = "update Payment set Date='" + payDate + "', Status='True' where BillNumber='" + billNumber + "' ";
            Command.CommandText = query;

            Connection.Open();
            bool rowAffected = Command.ExecuteNonQuery() > 0;

            Connection.Close();



            return rowAffected;
        }

        public List<UnpaidPatientViewModel> GetAllUnpaidPatientRecord(string text, string s)
        {


            string query = "SELECT * FROM Patient pt inner join Payment py on pt.Id=py.PatientId where Status='False' and Date between '"+text+"' AND  '"+s+"'  ";

            List<UnpaidPatientViewModel> unpaidPatientViewManagers = new List<UnpaidPatientViewModel>();

            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UnpaidPatientViewModel tv = new UnpaidPatientViewModel();

                    tv.BillNumber = reader["BillNumber"].ToString();
                    tv.ContactNo = reader["Mobile"].ToString();
                    tv.BillAmount = Convert.ToDouble(reader["TotalBill"]);
                    tv.PatientName= reader["Name"].ToString();


                    unpaidPatientViewManagers.Add(tv);
                }

            }
            reader.Close();
            Connection.Close();

            return unpaidPatientViewManagers;



        }
    }
}