using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Order_API.DTOs;
using Work_Order_API.Models;

namespace Work_Order_API.Profiles
{
    public class WorkOrderProfile : Profile
    {
        public WorkOrderProfile()
        {
            CreateMap<WorkOrder, WorkOrderReadDto>();
            CreateMap<WorkOrderCreateDto, WorkOrder>();
            CreateMap<WorkOrderUpdateDto, WorkOrder>();
            CreateMap<WorkOrder, WorkOrderUpdateDto>();
        }
    }
}
