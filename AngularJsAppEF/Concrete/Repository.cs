using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;
using AngularJsAppEntityFramework;
using AngularJsAppModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace AngularJsAppEF.Concrete
{
    public class Repository
    {
        //  readonly AngularJsDbContext angularJsDbContext = new AngularJsDbContext();
        // AngularJsDbContext context = new AngularJsDbContext();

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
            return student.Id;
        }

        public Student ShowStudent(int studentId)
        {
            Student student;
            try
            {
                using (var context = new AngularJsDbContext())
                {
                    student = context.Students.First(c => c.Id == studentId);
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
                    Student student = context.Students.FirstOrDefault(c => c.Id == studentId);
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
        public void Update(Student student)
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
    }
}