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
        private readonly GenericRepository<AddressType> addressTypeRepository = new GenericRepository<AddressType>();


        public AddressModel GetAddressTypes()
        {

            AddressModel addressModel = new AddressModel();
           
            List<AddressType> addressTypes = addressTypeRepository.All().ToList();
            addressModel.AddressTypes = addressTypes.Select(a => new SelectModel { Value = a.AddressTypeId, Text = a.Value }).ToList();

            return addressModel;
        }

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
                addressModel.AddressTypeId = address.AddressTypeId;
                addressModel.StudentId = address.StudentId;
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
            address.AddressTypeId = studentModel.Address.AddressTypeId;
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

        public AddressModel loadStudentAddress(int studentId,int addressTypeId)
        {
            var addressModel = new AddressModel();
            Address address = addressRepository.FindOne(x => x.StudentId == studentId && x.AddressTypeId== addressTypeId);

            if (address != null)
            {
                addressModel.Street = address.Street;
                addressModel.House = address.House;
                addressModel.PoBox = address.PoBox;
                addressModel.City = address.City;
                addressModel.ZipCode = address.ZipCode;
                addressModel.AddressTypeId = address.AddressTypeId;
                addressModel.StudentId = address.StudentId;
            }
            else
            {
                addressModel.StudentId = studentId;
                addressModel.AddressTypeId = addressTypeId;
            }

            List<AddressType> addressTypes = addressTypeRepository.All().ToList();
            addressModel.AddressTypes = addressTypes.Select(a => new SelectModel { Value = a.AddressTypeId, Text = a.Value }).ToList();

            return addressModel;
        }
        

    }
}
