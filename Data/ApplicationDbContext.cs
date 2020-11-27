﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using covid19.Models;

namespace covid19.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        //public DbSet<LeaveRequest> LeaveRequests { get; set; }
        //public DbSet<LeaveType> LeaveTypes { get; set; }
        //public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<Case> Cases { get; set; }
    }
}
