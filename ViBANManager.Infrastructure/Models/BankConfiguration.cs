using System;

namespace ViBANManager.Infrastructure.Models
{
    public class BankConfiguration
    {
        public Guid Id { get; set; }
        public string BankName { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string ApiBaseUrl { get; set; }
    }
}
