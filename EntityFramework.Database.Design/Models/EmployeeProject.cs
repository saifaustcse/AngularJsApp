using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Core.Data.Models
{
    //[Table("User")]

    public class EmployeeProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }

        // Many to Many relationship
        // One Employee can be associated many projects
        // One Project can be can be associated many Employees
        // So we have created this new table EmployeeProject
        // We also need to add reference of both (project and Employee) table

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

    }
}
