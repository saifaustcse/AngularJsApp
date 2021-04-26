using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Core.Data.Models
{
    //[Table("AddressType")]
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
        // One Employee has only one Salary
        // One Salary has only one Employee
        // So we need to add reference in both (Salary and Employee) table

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

    }
}