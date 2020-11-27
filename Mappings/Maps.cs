using AutoMapper;
using covid19.Data;
using covid19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            //CreateMap<LeaveType, LeaveTypeVM>().ReverseMap(); 
            //CreateMap<LeaveRequest, LeaveRequestVM>().ReverseMap();
            //CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            //reateMap<LeaveAllocation, EditLeaveAllocationVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}
