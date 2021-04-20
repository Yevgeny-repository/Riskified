using PaymentGatewaySimulation.Shared;

namespace PaymentGatewaySimulation.API.Profiles
{
    public class ChargeCardProfile : AutoMapper.Profile
    {
        public ChargeCardProfile()
        {
            CreateMap<ChargeCardRequest, VisaChargeModel>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FullName)
                )
                .ForMember(
                    dest => dest.Number,
                    opt => opt.MapFrom(src => src.CreditCardNumber)
                )
                .ForMember(
                    dest => dest.Cvv,
                    opt => opt.MapFrom(src => src.Cvv)
                )
                .ForMember(
                    dest => dest.Expiration,
                    opt => opt.MapFrom(src => src.ExpirationDate)
                )
                .ForMember(
                    dest => dest.TotalAmount,
                    opt => opt.MapFrom(src => src.Amount)
                ).ReverseMap().PreserveReferences();
            CreateMap<ChargeCardRequest, MasterCardChargeModel>()
                .ForMember(
                    dest => dest.First_Name,
                    opt => opt.MapFrom(src => src.FullName)
                )
                .ForMember(
                    dest => dest.Last_Name,
                    opt => opt.MapFrom(src => src.FullName)
                )
                .ForMember(
                    dest => dest.Card_Number,
                    opt => opt.MapFrom(src => src.CreditCardNumber)
                )
                .ForMember(
                    dest => dest.Cvv,
                    opt => opt.MapFrom(src => src.Cvv)
                )
                .ForMember(
                    dest => dest.Expiration,
                    opt => opt.MapFrom(src => src.ExpirationDate.Replace("/", "-"))
                )
                .ForMember(
                    dest => dest.Charge_Amount,
                    opt => opt.MapFrom(src => src.Amount)
                ).ReverseMap().PreserveReferences();
        }
    }
}