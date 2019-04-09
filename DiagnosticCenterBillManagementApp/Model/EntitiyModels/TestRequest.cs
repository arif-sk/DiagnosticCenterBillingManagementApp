using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementApp.Model.EntitiyModels
{
    [Serializable]
    public class TestRequest
    {
        
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int TestInfoId { get; set; }
        public DateTime Created_at { get; set; }

    }
}