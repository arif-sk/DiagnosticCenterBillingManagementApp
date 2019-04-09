using System;

namespace DiagnosticCenterBillManagementApp.Model.EntitiyModels
{
    [Serializable]
    public class Test
    {
         
        public int  Id { get; set; }
        public string  Name { get; set; }
        public double Fee { get; set; }

        public int TestTypeId { get; set; }
        public string Message { get; set; }
    }
}