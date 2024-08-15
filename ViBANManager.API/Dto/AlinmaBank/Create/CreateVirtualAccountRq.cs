using System;

namespace ViBANManager.API.Dto.AlinmaBank.Create
{
    public class CreateVirtualAccountRq
    {
        public string MrchntId { get; set; }
        public string SvcId { get; set; }
        public string MrchntBillNum { get; set; }
        public double DueAmt { get; set; }
        public DateTime DueDt { get; set; }
        public string BillDesc { get; set; }
        public string OfficialId { get; set; }
        public string CustName { get; set; }
        
    }
}