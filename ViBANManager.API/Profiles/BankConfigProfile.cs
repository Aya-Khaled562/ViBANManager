using AutoMapper;
using ViBANManager.API.Dto;
using ViBANManager.Infrastructure.Models;

namespace ViBANManager.API.Profiles
{
    public class BankConfigProfile: Profile
    {
        public BankConfigProfile() 
        {
            CreateMap<BankConfiguration, BankConfigDto>()
                .AfterMap((src, des, context) =>
                {
                    if (context.Items.ContainsKey("ServiceUrl"))
                    {
                        var serviceKey = context.Items["ServiceUrl"] as string;
                        des.EndPointUrl = src.ApiBaseUrl + serviceKey;
                    }
                });
        }
    }
}