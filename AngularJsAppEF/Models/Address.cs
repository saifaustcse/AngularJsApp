using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAppEF.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string PoBox { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        //[ForeignKey("AddressTypeId")]
        public int AddressTypeId { get; set; }

        //[ForeignKey("StudentId")]
        public int StudentId { get; set; }

        public virtual AddressType AddressType { get; set; }
        
        public virtual Student Student { get; set; }

    }
}
