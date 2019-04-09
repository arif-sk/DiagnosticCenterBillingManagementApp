using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementApp.DAL;
using DiagnosticCenterBillManagementApp.Model;

namespace DiagnosticCenterBillManagementApp.UI
{
    public partial class TestTypeUI : System.Web.UI.Page
    {
        private TestTypeManager _testTypeManager = new TestTypeManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                LoadGridView();
            }

            
        }

        private void LoadGridView()
        {
            List<TestType> list = _testTypeManager.GetAllTesType();

            testTypeSetupGridView.DataSource = list;
            testTypeSetupGridView.DataBind();
        }


        protected void typeNameSaveButton_Click(object sender, EventArgs e)
        {
            TestType testType = new TestType();


            testType.Name = typeNameTextBox.Text;
            

            bool rowAffected = _testTypeManager.SaveTestType(testType);
            if (rowAffected)
            {
                messageLabel.Text = "Added Successfully";
            }
            else
            {
                messageLabel.Text = "Save Failed";
            }
            LoadGridView();
        }
    }
}