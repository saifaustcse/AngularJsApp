using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAppService.Models
{
   public class StudentModel
    {
        public StudentModel()
        {
            Address = new AddressModel();
           // Addresses = new List<SelectModel>();
            AddressTypes = new List<SelectModel>();
          //  Courses = new List<SelectModel>();
        }
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }

        public int AddressTypeId { get; set; }
        public AddressModel Address { get; set; }
        
        // public List<SelectModel> Addresses { get; set; }
        // public List<SelectModel> Courses { get; set; }
        public List<SelectModel> AddressTypes { get; set; }



    }
}
