using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementApp.DAL;
using DiagnosticCenterBillManagementApp.Model;
using DiagnosticCenterBillManagementApp.Model.EntitiyModels;
using DiagnosticCenterBillManagementApp.Model.ViewModels;

namespace DiagnosticCenterBillManagementApp.UI
{
    public partial class TestUI : System.Web.UI.Page
    {
        private TestManager testManager = new TestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropdownTestType();

                LoadTestGridView();
            }

        }

        private void LoadTestGridView()
        {
            List<TestTestTypeViewModel> testList = testManager.GetAllTestTestInformation();
            testGridView.DataSource = testList;
            testGridView.DataBind();
        }

        private void LoadDropdownTestType()
        {
            List<TestType> testTypes = testManager.GetAllTestType();
            testTypeDropDownList.DataSource = testTypes;
            testTypeDropDownList.DataValueField = "Id";
            testTypeDropDownList.DataTextField = "Name";
            testTypeDropDownList.DataBind();
        }

        protected void testSaveButton_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            double fee;


            if (testNameTextBox.Text.Contains("%"))
            {
                messageLabel.Text = "Invalid Input!!";
            }

            else
            {



                if (double.TryParse(feeTextBox.Text, out fee))
                {
                    test.Fee = fee;
                }
                else
                {
                    test.Message = "Fee type miss match";
                    messageLabel.Text = test.Message;
                    return;
                }
                test.TestTypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);

                bool rowAffected = testManager.SaveTestData(test);
                if (rowAffected)
                {
                    messageLabel.Text = test.Message;
                }
                else
                {
                    messageLabel.Text = test.Message;
                }
                LoadTestGridView();
            }


        }
    }
}