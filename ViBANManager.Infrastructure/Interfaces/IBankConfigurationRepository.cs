using System.Threading.Tasks;
using ViBANManager.Infrastructure.Models;

namespace ViBANManager.Infrastructure.Repositories
{
    public interface IBankConfigurationRepository
    {
        Task<BankConfiguration> GetBankConfigurationAsync(string bankName);
    }
}
