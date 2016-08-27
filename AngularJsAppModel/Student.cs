using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAppModel
{
    public class Student
    {
       public Student()
            {
                Addresses = new HashSet<Address>();
                Courses = new HashSet<Course>();
            }

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Organization { get; set; }        
            public virtual ICollection<Address> Addresses { get; set; }
            public virtual ICollection<Course> Courses { get; set; }
      
    }
}
