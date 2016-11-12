using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularJsAppEF.Models
{
    [Table("AddressType")]
    public class AddressType
    {    
        public AddressType()
        {
            AddressList = new HashSet<Address>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressTypeId { get; set; }

        public string Value { set; get; }

        public string Text { set; get; }
     
        public virtual ICollection<Address> AddressList { get; set; }
    }
}
