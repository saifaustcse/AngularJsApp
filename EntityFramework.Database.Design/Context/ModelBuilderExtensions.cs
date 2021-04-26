using Demo.Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(
          new Department
          {
              DepartmentId = 1,
              Code = "IT",
              Name = "Information Technology",
              IsActive = true,
              CreatedDate = DateTime.UtcNow
          },
         new Department
         {
             DepartmentId = 2,
             Code = "Accounting",
             Name = "Accounts",
             IsActive = true,
             CreatedDate = DateTime.UtcNow
         },
          new Department
          {
              DepartmentId = 3,
              Code = "Admin",
              Name = "Administration",
              IsActive = true,
              CreatedDate = DateTime.UtcNow
          }
      );

        modelBuilder.Entity<Project>().HasData(
           new Project
           {
               ProjectId = 1,
               Name = "ERP",
               IsActive = true,
               CreatedDate = DateTime.UtcNow
           },
            new Project
            {
                ProjectId = 2,
                Name = "HRM",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            }
       );

         modelBuilder.Entity<Employee>().HasData(
           new Employee
           {
               EmployeeId = 1,
               DepartmentId=1,
               FirstName = "Saiful",
               LastName = "Islam",
               Birthday = "1991/10/27",
               Gender = "Male",
               PhoneNumber = "880191",
               Email = "s@mail.com",
               IsActive = true,
               CreatedDate = DateTime.UtcNow
           },
           new Employee
           {
               EmployeeId = 2,
               DepartmentId=1,
               FirstName = "ALex",
               LastName = "Islam",
               Birthday = "1991/10/27",
               Gender = "Male",
               PhoneNumber = "880171",
               Email = "a@mail.com",
               IsActive = true,
               CreatedDate = DateTime.UtcNow
           }
       );

    }
}