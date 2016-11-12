using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAppEF.Models
{
    public class Student
    {
        public Student()
        {
            AddressList = new HashSet<Address>();          
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Organization { get; set; }


        public virtual ICollection<Address> AddressList { get; set; }

    }
}
