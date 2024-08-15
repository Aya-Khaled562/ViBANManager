using ViBANManager.API.Dto.AlinmaBank.Create;

namespace ViBANManager.API.Dto.AlinmaBank
{
    public class AlinmaCreateResDto
    {
        public AlinmaResHeader ResponseHeader { get; set; }
        public AlinmaResponse CreateVirtualAccountRs { get; set; }
    }
}