using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ViBANManager.API.Dto;
using ViBANManager.API.Interfaces;


namespace ViBANManager.API.Services
{
    public abstract class ViBANService 
    {
        protected readonly HttpClient _httpClient;
        private readonly IAuthenticationService _authService;

        public ViBANService(HttpClient httpClient, IAuthenticationService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }


        private async Task SetAuthenticationHeaders(BankConfigDto bankConfigDto)
        {
            await _authService.AddAuthenticationHeaders(bankConfigDto);
        }

        protected async Task<TResponse> SendRequestAsync<TRequest, TResponse>(TRequest request, BankConfigDto bankConfigDto)
        {
            await SetAuthenticationHeaders(bankConfigDto);

            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(bankConfigDto.EndPointUrl, content);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }

        public abstract Task<object> CreateViBANAsync(object request);
        public abstract Task<object> AccountInquiryViBANsAsync(object request);
        public abstract Task<object> ActivateViBANAsync(object request);
        public abstract Task<object> DeactivateViBANAsync(object request);

    }
}