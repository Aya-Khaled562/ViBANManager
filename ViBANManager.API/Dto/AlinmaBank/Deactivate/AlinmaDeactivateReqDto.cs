namespace ViBANManager.API.Dto.AlinmaBank.Deactivate
{
    public class AlinmaDeactivateReqDto
    {
        public AlinmaReqHeader RequestHeader { get; set; }
        public DeactivateVirtualAccountRq DeactivateVirtualAccountRs { get; set; }
    }
}