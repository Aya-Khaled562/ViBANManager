using AutoMapper;
using ViBANManager.API.Dto;
using ViBANManager.API.Dto.AlinmaBank;
using ViBANManager.API.Dto.AlinmaBank.Create;

namespace ViBANManager.API.Profiles
{
    public class AlinmaProfile: Profile
    {
        public AlinmaProfile()
        {
            CreateMap<dynamic, AlinmaCreateReqDto>()
                .ForMember(des => des.RequestHeader, opt => opt.MapFrom(src => src))
                .ForMember(des => des.CreateVirtualAccountRq, opt => opt.MapFrom(src => src));


            CreateMap<dynamic, AlinmaReqHeader>()
                .ConvertUsing((src, des, context) =>
                {
                    if (src.RequestHeader == null) {
                        des = null;
                    }

                    des = new AlinmaReqHeader
                    {
                        RequestId = src.RequestHeader.RequestId,
                        ChannelId = src.RequestHeader.ChannelId,
                        FunctionId = src.RequestHeader.FunctionId,
                        RequestDateTime = src.RequestHeader.RequestDateTime,
                        PartnerId = src.RequestHeader.PartnerId
                    };

                    return des;
                });


            CreateMap<dynamic, CreateVirtualAccountRq>()
                .ConvertUsing((src, des, context) =>
                {
                    if(src.CreateVirtualAccountRq == null)
                    {
                        return null;
                    }

                    des = new CreateVirtualAccountRq
                    {
                        MrchntId = src.CreateVirtualAccountRq.MrchntId,
                        SvcId = src.CreateVirtualAccountRq.SvcId,
                        MrchntBillNum = src.CreateVirtualAccountRq.MrchntBillNum,
                        DueAmt = src.CreateVirtualAccountRq.DueAmt,
                        DueDt = src.CreateVirtualAccountRq.DueDt,
                        BillDesc = src.CreateVirtualAccountRq.BillDesc,
                        OfficialId = src.CreateVirtualAccountRq.OfficialId,
                        CustName = src.CreateVirtualAccountRq.CustName
                    };

                    return des;
                });


        }
    }
}