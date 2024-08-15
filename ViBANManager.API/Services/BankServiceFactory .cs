using AutoMapper;
using System;
using System.Net.Http;
using ViBANManager.API.Interfaces;
using ViBANManager.API.Services.Alinma;
using ViBANManager.Infrastructure.Repositories;

namespace ViBANManager.API.Services
{
    public class BankServiceFactory : IBankServiceFactory
    {
        private readonly HttpClient _httpClient;
        private readonly IBankConfigurationRepository _bankConfigRepo;
        private readonly IMapper _mapper;

        public BankServiceFactory(HttpClient httpClient, IBankConfigurationRepository bankConfigRepo, IMapper mapper)
        {
            _httpClient = httpClient;
            _bankConfigRepo = bankConfigRepo;
            _mapper = mapper;
        }
        public ViBANService GetViBANService(string bankName)
        {
            var bankAuthService = GetAuthenticationService(bankName);
            switch (bankName)
            {
                case "Alinma":
                    return new BankAlinmaService(_httpClient, _bankConfigRepo, bankAuthService, _mapper);
                default:
                    throw new ArgumentException($"Unsupported bank: {bankName}");
            }
        }

        public IAuthenticationService GetAuthenticationService(string bankName)
        {
            switch (bankName)
            {
                case "Alinma":
                    return new BankAlinmaAuthService(_httpClient);
                default:
                    throw new ArgumentException($"Unsupported bank: {bankName}");
            }
        }
    }
}