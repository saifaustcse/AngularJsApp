using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Data.Models
{
    //[Table("Address")]
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

        public int AddressTypeId { get; set; }

        public int StudentId { get; set; }

        public virtual AddressType AddressType { get; set; }

        public virtual Student Student { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }

    }
}