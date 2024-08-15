using System;

namespace ViBANManager.API.Dto.AlinmaBank
{
    public class AlinmaReqHeader
    {
        public string RequestId { get; set; }
        public string ChannelId { get; set; }
        public string FunctionId { get; set; }
        public string RequestDateTime { get; set; }
        public string PartnerId { get; set; }
    }
}