using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJsAppEF;
using AngularJsAppEF.Models;
using AngularJsAppService.Models;

namespace AngularJsAppService
{
    public class AddessService
    {
        private readonly GenericRepository<Address> addressRepository = new GenericRepository<Address>();

        public AddressModel Show(int studentId)
        {
            var addressModel = new AddressModel();
            Address address = addressRepository.FindOne(x => x.StudentId == studentId);
            if (address != null)
            {
                addressModel.Street = address.Street;
                addressModel.House = address.House;
                addressModel.PoBox = address.PoBox;
                addressModel.City = address.City;
                addressModel.ZipCode = address.ZipCode;
            }
            return addressModel;
        }

        public AddressModel Update(int studentId, StudentModel studentModel)
        {
            //server side validation
            if (studentId < 1 || studentModel.Address == null)
            {
                throw new Exception("Address data missing");
            }

            Address address = addressRepository.FindOne(x => x.StudentId == studentId);
            if (address == null)
            {
                throw new Exception("Address not found");
            }

            address.Street = studentModel.Address.Street;
            address.House = studentModel.Address.House;
            address.PoBox = studentModel.Address.PoBox;
            address.ZipCode = studentModel.Address.ZipCode;
            address.City = studentModel.Address.City;
            address.StudentId = studentId; //in time of update StudentId have to given 

            try
            {
               var result= addressRepository.Save(address);
            }
            catch (Exception ex)
            {
                throw new Exception("Address not updated succssfully" + ex);
            }
         
            return Show(studentId);
        }
    }
}
