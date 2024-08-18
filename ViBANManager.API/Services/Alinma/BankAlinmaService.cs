using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ViBANManager.API.Dto;
using ViBANManager.API.Dto.AlinmaBank;
using ViBANManager.API.Dto.AlinmaBank.Activate;
using ViBANManager.API.Dto.AlinmaBank.Deactivate;
using ViBANManager.API.Interfaces;
using ViBANManager.Infrastructure.Repositories;

namespace ViBANManager.API.Services.Alinma
{
    public class BankAlinmaService : ViBANService
    {
        private readonly IBankConfigurationRepository _bankConfigRepo;
        private readonly IMapper _mapper;
        private readonly string _bankName;
        public BankAlinmaService(
            HttpClient httpClient,
            IBankConfigurationRepository bankConfigRepo,
            IAuthenticationService authService,
            IMapper mapper) 
            : base(httpClient, authService)
        {
            _bankConfigRepo = bankConfigRepo;
            _mapper = mapper;
            _bankName = "Alinma";
        }

        public override async Task<object> CreateViBANAsync(object request)
        {
            try
            {
                var bankConfig = await _bankConfigRepo.GetBankConfigurationAsync(_bankName);
                var bankConfigDto = _mapper.Map<BankConfigDto>(bankConfig, opt =>
                {
                    opt.Items["ServiceUrl"] = "/REST/VirtualAccount/v1/Management/Create";
                });

                var reqAsString = request.ToString();

                var requestDto = JsonConvert.DeserializeObject<AlinmaCreateReqDto>(reqAsString);

                if (requestDto == null)
                {
                    throw new ArgumentException("Invalid request format for ViBAN creation");
                }

                 return await SendRequestAsync<AlinmaCreateReqDto, AlinmaCreateResDto>(requestDto, bankConfigDto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while creating ViBAN", ex);
            }
            
        }

        public override async Task<object> ActivateViBANAsync(object request)
        {
            var bankConfig = await _bankConfigRepo.GetBankConfigurationAsync(_bankName);
            var bankConfigDto = _mapper.Map<BankConfigDto>(bankConfig, opt =>
            {
                opt.Items["ServiceUrl"] = "/REST/VirtualAccount/v1/Management/Activate";
            });

            var requestDto = request as AlinmaActivateReqDto;
            
            if (requestDto == null)
            {
                throw new ArgumentException("Invalid request format for ViBAN activation");
            }

            string endPointUrl = "";
            try
            {
                return await SendRequestAsync<AlinmaActivateReqDto, AlinmaActivateResDto>(requestDto, bankConfigDto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while activating ViBAN", ex);
            }
            
        }

        public override async Task<object> DeactivateViBANAsync(object request)
        {
            var bankConfig = await _bankConfigRepo.GetBankConfigurationAsync(_bankName);
            var bankConfigDto = _mapper.Map<BankConfigDto>(bankConfig, opt =>
            {
                opt.Items["ServiceUrl"] = "/REST/VirtualAccount/v1/Management/Deactivate";
            });

            var requestDto = request as AlinmaDeactivateReqDto;
            
            if (requestDto == null)
            {
                throw new ArgumentException("Invalid request format for ViBAN deactivation");
            }

            string endPointUrl = "";
            try
            {
                return await SendRequestAsync<AlinmaDeactivateReqDto, AlinmaDeactivateResDto>(requestDto, bankConfigDto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deactivating ViBAN", ex);
            }
        }

        public override async Task<object> AccountInquiryViBANsAsync(object request)
        {
            var bankConfig = await _bankConfigRepo.GetBankConfigurationAsync(_bankName);
            var bankConfigDto = _mapper.Map<BankConfigDto>(bankConfig, opt => { 
                opt.Items["ServiceUrl"] = "/REST/VirtualAccount/v1/Inquiry"; 
            });

            var requestDto = request as AlinmaActivateReqDto;
            if (requestDto == null)
            {
                throw new ArgumentException("Invalid request format for ViBAN inquiry");
            }

            string endPointUrl = "";
            try
            {
                return await SendRequestAsync<AlinmaActivateReqDto, AlinmaActivateResDto>(requestDto, bankConfigDto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while inquiry ViBANs", ex);
            }
        }
    }
}