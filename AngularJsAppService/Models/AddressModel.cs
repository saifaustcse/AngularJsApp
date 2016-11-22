using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAppService.Models
{
   public class AddressModel
    {
        public AddressModel()
        {
          AddressTypes = new List<SelectModel>();
        }
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int AddressTypeId { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string PoBox { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public List<SelectModel> AddressTypes { get; set; }
    }
}
