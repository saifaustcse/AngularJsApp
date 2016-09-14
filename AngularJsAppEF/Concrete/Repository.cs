using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;
using AngularJsAppEntityFramework;
using AngularJsAppModel;

namespace AngularJsAppEF.Concrete
{
    public class Repository
    {
       
        public List<Student> GetStudents()
        {
            List<Student> students;
            try
            {
                using (var context = new AngularJsDbContext())
                {
                    students = context.Students.ToList();
                    var res = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting all student ", ex);
            }

            return students;
        }
        public int SaveStudent(Student student)
        {
            try
            {
                using (var context = new AngularJsDbContext())
                {
                    context.Students.Add(student);
                    var res = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Student Not Saved", ex);
            }
            return student.StudentId;
        }

        public Student ShowStudent(int studentId)
        {
            Student student;
            try
            {
                using (var context = new AngularJsDbContext())
                {
                    student = context.Students.First(c => c.StudentId == studentId);
                    var res = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting student ", ex);
            }

            return student;
        }

        public void DeleteStudent(int studentId)
        {
            try
            {
                using (var context = new AngularJsDbContext())
                {
                    Student student = context.Students.FirstOrDefault(c => c.StudentId== studentId);
                    if (student != null)
                    {
                        context.Students.Remove(student);
                        var res = context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Student not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Student Not deleted", ex);
            }
        }
        public void UpdateStudent(Student student)
        {
            try
            {
                using (var context = new AngularJsDbContext())
                {
                    context.Configuration.AutoDetectChangesEnabled = false;
                    context.Configuration.ValidateOnSaveEnabled = false;

                    //save modified entity using new Context
                    using (var transactionScope = new TransactionScope())
                    {
                        context.Entry(student).State = System.Data.Entity.EntityState.Modified;
                        var res = context.SaveChanges();
                        transactionScope.Complete();
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Student not updated", ex);
            }
        }

        public Address ShowAddress(int studentId)
        {
            Address address=new Address();
            try
            {
                using (var context = new AngularJsDbContext())
                {
                    address = context.Addresses.FirstOrDefault(c => c.StudentId == studentId);
                    var res = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting student ", ex);
            }

            return address;
        }

        public void UpdateAddress(Address address)
        {
            try
            {
                using (var context = new AngularJsDbContext())
                {
                    context.Configuration.AutoDetectChangesEnabled = false;
                    context.Configuration.ValidateOnSaveEnabled = false;

                    //save modified entity using new Context
                    using (var transactionScope = new TransactionScope())
                    {
                        context.Entry(address).State = System.Data.Entity.EntityState.Modified;
                        var res = context.SaveChanges();
                        transactionScope.Complete();
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Address not updated", ex);
            }
        }
        
    }
}