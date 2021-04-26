using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demo.Core.Data.Models
{
    //[Table("Employee")]

    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public string Gender { get; set; }

        // public string CountryCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }

        // One to Many relationship
        // One Employee is associated only one department
        // One Department has many Employees
        // So we need to add reference in Employees (many) table

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        // One to One relationship
        // One Employee has only one Salary
        // One Salary has only one Employee
        // So we need to add reference in both (Salary and Employee) table

        public virtual EmployeeSalary EmployeeSalary { get; set; }


    }
}
