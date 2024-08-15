using System.Data.Entity;
using System.Threading.Tasks;
using ViBANManager.Infrastructure.Context;
using ViBANManager.Infrastructure.Models;

namespace ViBANManager.Infrastructure.Repositories
{
    public class BankConfigurationRepository : IBankConfigurationRepository
    {
        private readonly ViBANDbContext _context;

        public BankConfigurationRepository(ViBANDbContext context)
        {
            _context = context;
        }
        public async Task<BankConfiguration> GetBankConfigurationAsync(string bankName)
        {
            return await _context.BankConfigurations.FirstOrDefaultAsync(bankConfig => bankConfig.BankName.ToLower() == bankName.ToLower());
        }
    }
}
