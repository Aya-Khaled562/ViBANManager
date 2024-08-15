using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ViBANManager.API.Dto;
using ViBANManager.API.Interfaces;

namespace ViBANManager.API.Services.Alinma
{
    public class BankAlinmaAuthService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private string _token;
        public BankAlinmaAuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddAuthenticationHeaders(BankConfigDto bankConfigDto)
        {
            if (string.IsNullOrEmpty(_token))
            {
                await RefreshToken(bankConfigDto);
            }

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            _httpClient.DefaultRequestHeaders.Add("ApiKey", bankConfigDto.ApiKey);
            _httpClient.DefaultRequestHeaders.Add("ApiSecret", bankConfigDto.ApiSecret);
            _httpClient.DefaultRequestHeaders.Add("Scope", "B2BScope");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        private async Task RefreshToken(BankConfigDto bankConfigDto)
        {
            try
            {
                string tokenEndpoint = bankConfigDto.ApiBaseUrl + "/alinma-native-oauth-provider/oauth2/token";

                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{bankConfigDto.ApiKey}:{bankConfigDto.ApiSecret}"));

                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                var requestBody = new StringContent("grant_type=client_credentials&scope=B2BScope", Encoding.UTF8, "application/x-www-form-urlencoded");

                var response = await _httpClient.PostAsync(tokenEndpoint, requestBody);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<JObject>(responseContent);

                _token = tokenResponse["access_token"].ToString();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while refreshing the token", ex);
            }
        }

    }
}