using AutoMapper;
using SalonSystem.DTOs;
using SalonSystem.Models.Technicians;
using SalonSystem.Models.Salons;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapping definitions for AutoMapper
        CreateMap<Salon, SalonDto>();
        CreateMap<SalonDto, Salon>();
        
        CreateMap<Technician, TechnicianDto>();
        CreateMap<TechnicianDto, Technician>();

        CreateMap<UpdateTechnicianDto, Technician>();

        CreateMap<Technician, SimpleTechnicianDto>();
        CreateMap<SimpleTechnicianDto, Technician>();

    }
}