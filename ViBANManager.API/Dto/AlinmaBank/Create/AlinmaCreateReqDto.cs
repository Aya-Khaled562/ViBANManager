using ViBANManager.API.Dto.AlinmaBank;
using ViBANManager.API.Dto.AlinmaBank.Create;

namespace ViBANManager.API.Dto
{
    public class AlinmaCreateReqDto
    {
        public AlinmaReqHeader RequestHeader { get; set; }
        public CreateVirtualAccountRq CreateVirtualAccountRq { get; set; }
    }
}