using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;
using DiagnosticCenterBillManagementApp.BLL;
using DiagnosticCenterBillManagementApp.DAL;
using DiagnosticCenterBillManagementApp.Model;
using DiagnosticCenterBillManagementApp.Model.EntitiyModels;
using System.IO;
using iTextSharp.text;
using  iTextSharp.text.pdf;


namespace DiagnosticCenterBillManagementApp.UI
{   
    public partial class TestRequestEntryUI : System.Web.UI.Page
    {
        private List<Test> tests;
        List<TestRequest> testRequests = null;
        private TestManager testManager = new TestManager();
        private  PatientManager patientManager=new PatientManager();
        private PaymentManager paymentManager=new PaymentManager();
        private TestRequestManager testRequestManager=new TestRequestManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
           // dateOfBirthTextBox.ReadOnly = true;
            if (!IsPostBack)
            {
                dobCalendar.Visible = false;
                LoadDropdownTest();
                LoadAllTestSubmitGridView();
            }
            
        }

        private void LoadAllTestSubmitGridView()
        {
            allTestRequestGridView.DataSource = tests;
            allTestRequestGridView.DataBind();
            double totalAmount = 0;
            if (tests != null)
            {
                foreach (Test t in tests)
                {
                    totalAmount += t.Fee;
                }
            }
            
            totalAmountTextBox.Text = totalAmount.ToString();

        }
        
        protected void testRequestEntryButton_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Name = nameOfThePatientTextBox.Text;
            if (dateOfBirthTextBox.Text!="")
            {
                patient.DOB =Convert.ToDateTime(dateOfBirthTextBox.Text);
            }
            else
            {
                messageLabel.Text = "Please Provide date";
                return;
            }
            patient.MobileNumber = mobileNoTextBox.Text;
            bool rowAffected = false;
            rowAffected = patientManager.Save(patient);
            if (rowAffected)
            {
                messageLabel.Text = "Pateient Saved Successfullty";
            }
            else
            {
                messageLabel.Text = "Already Registered Patient.";
            }
            //Test t = new Test();
            //t.Id = Convert.ToInt32(testDropDownList.SelectedValue);
            //t.Name = testDropDownList.SelectedItem.Text;
            //t.Fee = Convert.ToDouble(feeTextBox.Text);
            //tests.Add(t); 
            if (ViewState["test"] == null)
            {
                tests = new List<Test>();
                Test t = new Test();
                t.Id = Convert.ToInt32(testDropDownList.SelectedItem.Value);
                t.Name = testDropDownList.SelectedItem.Text;
                t.Fee = Convert.ToDouble(feeTextBox.Text);
                tests.Add(t);
                ViewState["test"] = tests;
            }
            else
            {
                tests = (List<Test>)ViewState["test"];
                Test t = new Test();
                t.Id = Convert.ToInt32(testDropDownList.SelectedItem.Value);
                t.Name = testDropDownList.SelectedItem.Text;
                t.Fee = Convert.ToDouble(feeTextBox.Text);
                tests.Add(t);
                ViewState["test"] = tests;
            }
            LoadAllTestSubmitGridView();
            
            
        }
        private void LoadDropdownTest()
        {
            List<Test> testTypes = testManager.GetAllTest();
            testDropDownList.DataSource = testTypes;
            testDropDownList.DataValueField = "Id";
            testDropDownList.DataTextField = "Name";
            testDropDownList.DataBind();


        }

        protected void allTestSubmitButton_Click(object sender, EventArgs e)
        {
            List<Test> tests =(List<Test>) ViewState["test"];
            DateTime date = DateTime.Now;

            //string s = date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            
            //DateTime createdDate = s;
            bool rowAffected = false;
            
            
            if (ViewState["test"]!=null)
            {
                foreach (Test t in tests)
                {
                    if (ViewState["testReq"] == null)
                    {
                        testRequests = new List<TestRequest>();
                        //Test t = new Test();
                        TestRequest testRequest = new TestRequest();
                        testRequest.TestInfoId = t.Id;
                        testRequest.PatientId = patientManager.GetPatientByMobileNumber(mobileNoTextBox.Text);
                        testRequest.Created_at = date;
                        testRequests.Add(testRequest);
                        ViewState["testReq"] = testRequests;
                    }
                    else
                    {
                        testRequests = (List<TestRequest>)ViewState["testReq"];
                        //Test t = new Test();
                        TestRequest testRequest = new TestRequest();
                        testRequest.TestInfoId = t.Id;
                        testRequest.PatientId = patientManager.GetPatientByMobileNumber(mobileNoTextBox.Text);
                        testRequest.Created_at = date;
                        testRequests.Add(testRequest);
                        ViewState["testReq"] = testRequests;
                    }




                    //testRequest.TestInfoId = t.Id;
                    //testRequest.PatientId = patientManager.GetPatientByMobileNumber(mobileNoTextBox.Text);
                    //testRequest.Created_at = createdDate;
                    //testRequests.Add(testRequest);
                }
                rowAffected = testRequestManager.Save(testRequests);
                long ticks = DateTime.Now.Ticks;
                byte[] bytes = BitConverter.GetBytes(ticks);
                string billNumber = Convert.ToBase64String(bytes)
                                        .Replace('+', '_')
                                        .Replace('/', '-')
                                        .TrimEnd('=');
                Payment payment = new Payment();
                payment.BillNumber = billNumber;
                payment.TotalAmount = Convert.ToDouble(totalAmountTextBox.Text);

                payment.PatientId = patientManager.GetPatientByMobileNumber(mobileNoTextBox.Text);
                
                payment.Created_at = date;
                payment.Status = false;
                
                rowAffected = paymentManager.Save(payment);
                if (rowAffected)
                {
                    messageLabel.Text = "Successfully Saved";

                    tests = null;
                    allTestRequestGridView.DataSource = tests;
                    allTestRequestGridView.DataBind();
                    testRequests = null;

                    totalAmountTextBox.Text = "";
                    billNumberLabel.Text = billNumber;

                }
                else
                {
                    messageLabel.Text = "Failed";
                }
            }
            

            

        }

      

        protected void testDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Test tt = new Test();
            
            tt.Id = Convert.ToInt32(testDropDownList.SelectedValue);
            tt.Fee = testManager.GetFeeByTestID(tt.Id);
            feeTextBox.Text = tt.Fee.ToString();

        }

        protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
        {
            if (dobCalendar.Visible)
            {
                dobCalendar.Visible = false;
            }
            else
            {
                dobCalendar.Visible = true;
            }
            
        }

        protected void dobCalendar_SelectionChanged(object sender, EventArgs e)
        {
            dateOfBirthTextBox.Text = dobCalendar.SelectedDate.ToShortDateString();
            //dobCalendar.Visible = false;
        }

    }
}