using System.Net.Http;
using System.Threading.Tasks;
using ViBANManager.API.Dto;

namespace ViBANManager.API.Interfaces
{
    public interface IAuthenticationService
    {
        Task AddAuthenticationHeaders(BankConfigDto bankConfigDto);
    }
}
