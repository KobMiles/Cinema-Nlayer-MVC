using AutoMapper;
using Cinema.BLL.DTOs.Payments;
using Cinema.DAL.Entities;

namespace Cinema.BLL.Helpers;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Payment, PaymentDto>();
        CreateMap<Payment, PaymentDetailsDto>();

        CreateMap<PaymentCreateDto, Payment>();
        CreateMap<PaymentUpdateDto, Payment>();
    }
}