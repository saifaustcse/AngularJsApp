using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAppModel
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string PoBox { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
