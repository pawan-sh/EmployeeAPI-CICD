using AutoMapper;
using EmployeeAPI.Dtos;
using EmployeeAPI.Models;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
        CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
    }
}
