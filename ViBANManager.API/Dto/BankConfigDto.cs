using System;

namespace ViBANManager.API.Dto
{
    public class BankConfigDto
    {
        public string BankName { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string ApiBaseUrl { get; set; }
        public string EndPointUrl { get; set; }
    }
}