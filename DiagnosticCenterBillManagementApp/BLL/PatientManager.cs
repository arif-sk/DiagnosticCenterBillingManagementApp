using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementApp.Model;
using DiagnosticCenterBillManagementApp.Model.EntitiyModels;

namespace DiagnosticCenterBillManagementApp.DAL
{
    public class PatientManager
    {
        PatientGateway patientGateway=new PatientGateway();
        public bool Save(Patient patient)
        {
            if (IsValidData(patient) && IsMobileNumberAvailable(patient))
            {
                bool rowAffected = patientGateway.SaveTestData(patient);
                if (rowAffected)
                {
                    return true;
                }

            }
            return false; 
        }

        private bool IsMobileNumberAvailable(Patient patient)
        {
            Patient p = patientGateway.GetByMobileNumber(patient);
            if (p == null)
            {
                return true;
            }
            
            return false;
        }

        private bool IsValidData(Patient patient)
        {
            if (!string.IsNullOrEmpty(patient.Name) &&
                !string.IsNullOrEmpty(patient.MobileNumber)&&
                !string.IsNullOrEmpty(patient.DOB.ToString())
                )
            {
                return true;
            }
            return false;
        }

        public int GetPatientByMobileNumber(string mobileNumber)
        {
            return patientGateway.GetPatientByMobileNumber(mobileNumber);
        }
    }
}