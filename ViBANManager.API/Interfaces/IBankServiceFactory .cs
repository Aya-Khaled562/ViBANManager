using ViBANManager.API.Services;

namespace ViBANManager.API.Interfaces
{
    public interface IBankServiceFactory
    {
        ViBANService GetViBANService(string bankName);
    }
}
