using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.App_Start
{
    public class WebAutomapperConfig: Profile
    {
        public WebAutomapperConfig()
        {
            //CreateMap<GroupDTO, StudentListVM>()
            //    .ForMember(d => d.GroupName, opt => opt.MapFrom(s => s.Name))
            //    .ForMember(d => d.FirstName, opt => opt.Ignore())
            //    .ForMember(d => d.LastName, opt => opt.Ignore())
            //    .ForMember(d => d.StudentId, opt => opt.Ignore());
            CreateMap<StudentDTO, StudentListVM>()
                .ForMember(d=>d.StudentId, opt=>opt.MapFrom(s=>s.StudentId))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.GroupName, opt => opt.MapFrom(s=>s.Group.Name));
            CreateMap<BookLeaseDTO, LeaseListVM>()
                .ForMember(d=>d.LeaseId, opt=>opt.MapFrom(s=>s.LeaseId))
                .ForMember(d => d.StudentId, opt => opt.MapFrom(s => s.StudentId))
                .ForMember(d => d.GetTime, opt => opt.MapFrom(s => s.GetTime))
                .ForMember(d => d.ReturnTime, opt => opt.MapFrom(s => s.ReturnTime))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Book.Name))
                .ForMember(d => d.Author, opt => opt.MapFrom(s => s.Book.Author))
                .ForMember(d => d.StudentName, opt => opt.MapFrom(s => s.Student.FirstName + " " + s.Student.LastName))
                .ForSourceMember(s=>s.Book, opt=>opt.Ignore());
        }
    }
}