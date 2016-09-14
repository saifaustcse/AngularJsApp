using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJsAppEF.Concrete;
using AngularJsAppModel;
using AngularJsAppService.Models;

namespace AngularJsAppService
{
    public class StudentService
    {
        private readonly Repository repository = new Repository();

        public StudentModel Save(StudentModel studentModel)
        {
            if (studentModel == null)
            {
                throw new Exception("Student data missing");
            }

            if (string.IsNullOrWhiteSpace(studentModel.Name) || string.IsNullOrWhiteSpace(studentModel.Phone))
            {
                throw new Exception("All required field must be entered");
            }

            var student = new Student
            {
                Name = studentModel.Name,
                Phone = studentModel.Phone,
                Email= studentModel.Email,
                Organization = studentModel.Organization
            };

            Address address = new Address();
            address.Street = studentModel.Address.Street;
            address.House= studentModel.Address.House;
            address.PoBox= studentModel.Address.PoBox;
            address.ZipCode = studentModel.Address.ZipCode;
            address.City = studentModel.Address.City;
          
            //studentId will auto take from student which is auto generate after insert student 
            //address.StudentId = student.StudentId; 
            student.Addresses.Add(address);

            int id = repository.SaveStudent(student);
            return Show(id);

        }
        public List<StudentModel> Get(string searchText, int itemsPerPage, int pageNumber, out int total)
        {
            List<Student> studentQuery = new List<Student>();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                studentQuery = repository.GetStudents().Where(x => x.StudentId.ToString() == searchText || x.Name.ToString().Equals(searchText) || x.Name.Contains(searchText)).ToList();
            }
            else
            {
                studentQuery = repository.GetStudents().ToList();
            }

            total = studentQuery.Count();
            List<Student> students = studentQuery.OrderByDescending(x => x.StudentId).Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToList();

            List<StudentModel> studentModel = students.Select(x => new StudentModel
            {
                Id = x.StudentId,
                Name = x.Name,
                Phone = x.Phone,
                Email = x.Email,
                Organization = x.Organization,
                Address = GetPrimaryAddess(x.StudentId)

            }).ToList();

            return studentModel;
        }

        public StudentModel Show(int studentId)
        {
            if (studentId < 1)
            {
                throw new Exception("Student id not valid");
            }

            var studentModel = new StudentModel();

            Student student = repository.ShowStudent(studentId);
            if (student != null)
            {
                studentModel.Id = student.StudentId;
                studentModel.Name = student.Name;
                studentModel.Phone = student.Phone;
                studentModel.Email = student.Email;
                studentModel.Organization = student.Organization;
                studentModel.Address = GetPrimaryAddess(student.StudentId);
            }

            return studentModel;
        }


        public bool Delete(int studentId)
        {
            if (studentId < 1)
            {
                throw new Exception("Student id not valid");
            }

            repository.DeleteStudent(studentId);
            return true;
        }

        
        public StudentModel Update(int studentId, StudentModel studentModel)
        {
            if (studentId < 1 || studentModel == null)
            {
                throw new Exception("Student data missing");
            }

            //server side validation
            if (string.IsNullOrWhiteSpace(studentModel.Name) || string.IsNullOrWhiteSpace(studentModel.Phone))
            {
                throw new Exception("All required field must be entered");
            }

            Student student = repository.ShowStudent(studentId);
            if (student == null)
            {
                throw new Exception("student not found");
            }

            student.StudentId = studentModel.Id;
            student.Name = studentModel.Name;
            student.Phone = studentModel.Phone;
            student.Organization = studentModel.Organization;
            repository.UpdateStudent(student);


            //Address address = new Address();
            //address.Street = studentModel.Address.Street;
            //address.House = studentModel.Address.House;
            //address.PoBox = studentModel.Address.PoBox;
            //address.ZipCode = studentModel.Address.ZipCode;
            //address.City = studentModel.Address.City;
            //address.StudentId = student.StudentId; //in time of update StudentId have to given 
            
            //repository.UpdateAddress(address);


            return Show(studentId);
        }

        public AddressModel GetPrimaryAddess(int StudentId)
        {       
            var addressModel = new AddressModel();

            Address address = repository.ShowAddress(StudentId);
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

    }
}