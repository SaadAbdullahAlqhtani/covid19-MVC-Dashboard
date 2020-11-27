using covid19.Data;
using covid19.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace covid19
{ 
    public static class SeedData 
    {
        public static void Seed(
            UserManager<Employee> userManager,
            RoleManager<IdentityRole> roleManager,
            CaseDBContext caseContext
        )

        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedCases(caseContext);
        } 

        private static void SeedUsers(UserManager<Employee> userManager)
        {
            var users = userManager.GetUsersInRoleAsync("Employee").Result;

            if (userManager.FindByNameAsync("admin@localhost.com").Result == null)
            {
                var user = new Employee
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com"
                };
                var result = userManager.CreateAsync(user, "P@ssword1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
        public static void SeedCases(this CaseDBContext context)
        {
            var data = new List<Case>()
            {
                new Case()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Type = "Cured",
                    Description = "Description"
                },
                new Case()
                {
                    FirstName = "Jill",
                    LastName = "Doe",
                    Type = "Cured",
                    Description = "Description"
                },
                new Case()
                {
                    FirstName = "Amy",
                    LastName = "Doe",
                    Type = "Infected",
                    Description = "Description"
                },
                new Case()
                {
                    FirstName = "Steve",
                    LastName = "Doe",
                    Type = "Cured",
                    Description = "Description"
                },
                new Case()
                {
                    FirstName = "Amy",
                    LastName = "House",
                    Type = "Infected",
                    Description = "Description"
                },
            };

            context.Cases.AddRange(data);
            context.SaveChanges();
        }
    }
}
