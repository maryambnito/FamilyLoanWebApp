using AutoMapper;
using FamilyLoan.Core.ApplicaionService.Customers.Commands;
using FamilyLoan.Core.ApplicaionService.Customers.Commands.UpdateCustomers;
using FamilyLoan.Core.Domain.Customers;
using FamilyLoan.Core.Domain.Customers.DTOs;
using FamilyLoan.Endpoints.WebUI.VIewModels.Customers;

namespace FamilyLoan.Services.Service.Customers.AutoMappers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDTO, UpdateCustomerViewModel>();

            CreateMap<UpdateCustomerCommand, Customer>();
            
            CreateMap<AddCustomerCommand, Customer>();
            
            CreateMap<Customer, CustomerDTO>();
            
            CreateMap<Customer, Customer>();
            
            CreateMap<CustomerDTO, Customer>();
            
            CreateMap<CreateCustomerViewModel, AddCustomerCommand>();
            
            CreateMap<UpdateCustomerViewModel, UpdateCustomerCommand>();
            
            CreateMap<CustomerDTO,DeleteCustomerViewModel >();

            CreateMap<CustomerDTO, DetailsCustomerViewModel>();
            
        }
    }
}
