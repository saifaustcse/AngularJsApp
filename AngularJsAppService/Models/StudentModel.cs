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
            Courses = new List<SelectModel>();
        }
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Organization { get; set; }   

        public AddressModel Address { get; set; }
        public List<SelectModel> Courses { get; set; }
      

        
    }
}
