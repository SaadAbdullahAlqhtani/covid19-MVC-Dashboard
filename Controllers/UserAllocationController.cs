using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using covid19.Contracts;
using covid19.Data;
using covid19.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace covid19.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserAllocationController : Controller
    {
       
      //  private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;

        public UserAllocationController(
          //  IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<Employee> userManager
        )
        {
            //_unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: UserAllocation
        /*public async Task<ActionResult> Index()
        {
            var leavetypes = await _unitOfWork.LeaveTypes.FindAll();
            var mappedLeaveTypes = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leavetypes.ToList());
            var model = new CreateLeaveAllocationVM
            {
                LeaveTypes = mappedLeaveTypes,
                NumberUpdated = 0
            };
            return View(model);
        }*/

        /*public async Task<ActionResult> SetLeave(int id)
        {
            var leavetype = await _unitOfWork.LeaveTypes.Find(q => q.Id == id);
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            var period = DateTime.Now.Year;
            foreach (var emp in employees)
            {
                if (await _unitOfWork.LeaveAllocations.isExists(q => q.EmployeeId == emp.Id
                                        && q.LeaveTypeId == id
                                        && q.Period == period))
                    continue;
                var allocation = new LeaveAllocationVM
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = emp.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leavetype.DefaultDays,
                    Period = DateTime.Now.Year
                };
                var leaveallocation = _mapper.Map<LeaveAllocation>(allocation);
                await _unitOfWork.LeaveAllocations.Create(leaveallocation);
                await _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }*/

        public async Task<ActionResult> ListUsers()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            var model = _mapper.Map<List<EmployeeVM>>(employees);
            return View(model);
        }

        // GET: UserAllocation/Details/5
        /*public async Task<ActionResult> Details(string id)
        {
            var employee = _mapper.Map<EmployeeVM>(await _userManager.FindByIdAsync(id));
            var period = DateTime.Now.Year;
            var records = await _unitOfWork.LeaveAllocations.FindAll(
                expression: q => q.EmployeeId == id && q.Period == period,
                includes: new List<string> { "LeaveType" }
            );

            var allocations = _mapper.Map<List<LeaveAllocationVM>>
                    (records);

            var model = new ViewAllocationsVM
            {
                Employee = employee,
                LeaveAllocations = allocations
            };
            return View(model);
        }*/

        // GET: UserAllocation/Edit/5
       /* public async Task<ActionResult> Edit(int id)
        {
            var leaveallocation = await _unitOfWork.LeaveAllocations.Find(q => q.Id == id,
                includes: new List<string> { "Employee", "LeaveType" });
            var model = _mapper.Map<EditLeaveAllocationVM>(leaveallocation);
            return View(model);
        }*/

        // POST: LeaveAllocation/Edit/5
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditLeaveAllocationVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                //var record = await _leaveallocationrepo.FindById(model.Id);
                var record = await _unitOfWork.LeaveAllocations.Find(q => q.Id == model.Id);
                record.NumberOfDays = model.NumberOfDays;
                _unitOfWork.LeaveAllocations.Update(record);
                await _unitOfWork.Save();
                
                return RedirectToAction(nameof(Details), new {id = model.EmployeeId });
            }
            catch 
            {
                return View(model);
            }
        }*/
    }
}