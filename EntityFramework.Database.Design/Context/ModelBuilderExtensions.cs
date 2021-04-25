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
              Code = "CSE",
              Name = "Computer Science And Engineering",
              IsActive = true,
              CreatedDate = DateTime.UtcNow
          },
         new Department
         {
             DepartmentId = 2,
             Code = "EEE",
             Name = "Electrical and Electronics Engineering",
             IsActive = true,
             CreatedDate = DateTime.UtcNow
         },
          new Department
          {
              DepartmentId = 3,
              Code = "IPE",
              Name = "Industrial and production engineering",
              IsActive = true,
              CreatedDate = DateTime.UtcNow
          }
      );

        modelBuilder.Entity<Course>().HasData(
           new Course
           {
               CourseId = 1,
               Code = "CSE 111",
               Name = "Programming Language I",
               Credit = 3,
               IsActive = true,
               CreatedDate = DateTime.UtcNow
           },
            new Course
            {
                CourseId = 2,
                Code = "CSE 110",
                Name = "Programming Language-II",
                Credit = 3,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            },
            new Course
            {
                CourseId = 3,
                Code = "CSE 220",
                Name = "Data Structures",
                Credit = 3,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            }
       );

        modelBuilder.Entity<AddressType>().HasData(
           new AddressType
           {
               AddressTypeId = 1,
               Value = 1,
               Text = "Presnt",
               IsActive = true,
               CreatedDate = DateTime.UtcNow
           },
           new AddressType
           {
               AddressTypeId = 2,
               Value = 2,
               Text = "Permanent",
               IsActive = true,
               CreatedDate = DateTime.UtcNow
           }
       );

        //modelBuilder.Entity<Book>().HasData(
        //    new Book { BookId = 1, AuthorId = 1, Title = "Hamlet" },
        //    new Book { BookId = 2, AuthorId = 1, Title = "King Lear" },
        //    new Book { BookId = 3, AuthorId = 1, Title = "Othello" }
        //);
    }
}