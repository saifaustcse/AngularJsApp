using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Core.Data.Models
{
    //[Table("EmployeeSalary")]
    public class EmployeeSalary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeSalaryId { get; set; }

        public float SalaryAmount { set; get; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }

        // One to One relationship
        // One Employee has only one EmployeeSalary
        // One EmployeeSalary has only one Employee
        // So we need to add reference in both (EmployeeSalary and Employee) table

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

    }
}