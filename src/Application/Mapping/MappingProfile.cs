using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Customer;
using Application.DTOs.Department;
using Application.DTOs.Ticket;
using Application.DTOs.User;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // ===== CUSTOMER MAPPINGS =====
            CreateMap<CreateCustomerDto, Customer>()
                .ConstructUsing(src => new Customer())
                .ForMember(dest => dest.Tier, opt => opt.MapFrom(src =>
                    Enum.TryParse<CustomerTier>(src.Tier, out var tier) ? tier : CustomerTier.Standard))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());

            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Tier, opt => opt.MapFrom(src => src.Tier.ToString()))
                .ForMember(dest => dest.TicketCount, opt => opt.MapFrom(src => src.Tickets.Count(t => !t.IsDeleted)));

            // ===== USER MAPPINGS =====
            CreateMap<CreateUserDto, User>()
                .ConstructUsing(src => new User(
                    src.FullName,
                    src.Email,
                    Enum.TryParse<UserRole>(src.Role, out var role) ? role : UserRole.Agent))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.LastLoginDate, opt => opt.Ignore())
                .ForMember(dest => dest.TicketsCreated, opt => opt.Ignore())
                .ForMember(dest => dest.TicketsAssigned, opt => opt.Ignore())
                .AfterMap((src, dest) => dest.UpdateProfile(src.PhoneNumber, src.Department));

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
                .ForMember(dest => dest.CreatedTicketsCount, opt => opt.MapFrom(src => src.TicketsCreated.Count(t => !t.IsDeleted)))
                .ForMember(dest => dest.AssignedTicketsCount, opt => opt.MapFrom(src => src.TicketsAssigned.Count(t => !t.IsDeleted)));

            // ===== TICKET MAPPINGS =====
            CreateMap<CreateTicketDto, Ticket>()
                .ConstructUsing(src => new Ticket(src.Title, src.Description, src.CreatedById))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
                

            CreateMap<Ticket, TicketDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.ToString()))
                .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.FullName : ""))
                .ForMember(dest => dest.AssignedToName, opt => opt.MapFrom(src => src.AssignedTo != null ? src.AssignedTo.FullName : null));

            // ===== DEPARTMENT MAPPINGS =====
            CreateMap<CreateDepartmentDto, Department>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Manager, opt => opt.Ignore())
                .ForMember(dest => dest.Users, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore());

            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.FullName : null))
                .ForMember(dest => dest.UserCount, opt => opt.MapFrom(src => src.Users.Count(u => !u.IsDeleted)))
                .ForMember(dest => dest.CategoryCount, opt => opt.MapFrom(src => src.Categories.Count(c => !c.IsDeleted)));
        }
    }
}
