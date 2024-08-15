namespace ViBANManager.API.Dto.AlinmaBank.Activate
{
    public class AlinmaActivateReqDto
    {
        public AlinmaReqHeader RequestHeader { get; set; }
        public ActivateVirtualAccountRq ActivateVirtualAccountRq { get; set; }
    }
}