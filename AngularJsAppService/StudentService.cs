using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJsAppEF;
using AngularJsAppEF.Models;
using AngularJsAppService.Models;

namespace AngularJsAppService
{
    public class StudentService
    {
        private readonly GenericRepository<Student> studentRepository = new GenericRepository<Student>();
        private readonly GenericRepository<AddressType> addressTypeRepository = new GenericRepository<AddressType>();

        private readonly AddessService addessService = new AddessService();
      
        // private readonly IRepository<Student> studentRepository;
        // private readonly IRepository<Address> addessRepository;

        // private readonly IEmailService emailService;

        //public StudentService()
        //{

        //}
        //public StudentService(IRepository<Student> studentRepository, IRepository<Address> addessRepository):this()
        //{
        //    this.studentRepository = studentRepository;
        //    this.addessRepository = addessRepository;

        //  //  this.emailService = emailService;
        //}

        //   private readonly AddessService addessService = new AddessService(); 

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
                Email = studentModel.Email,
                Organization = studentModel.Organization
            };

            Address address = new Address();
            if (studentModel.Address != null)
            {
                //studentId will auto take from student which will auto generate after insert student 
                //address.StudentId = student.StudentId; 
                address.Street = studentModel.Address.Street;
                address.House = studentModel.Address.House;
                address.PoBox = studentModel.Address.PoBox;
                address.ZipCode = studentModel.Address.ZipCode;
                address.City = studentModel.Address.City;
                address.AddressTypeId = 1;
            }

            student.Addresses.Add(address);

            try
            {
                int result = studentRepository.Save(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Student not saved succssfully" + ex);
            }

            return Show(student.StudentId);
        }

        public List<StudentModel> Get(string searchText, int itemsPerPage, int pageNumber, out int total)
        {

            List<Student> studentQuery = new List<Student>();

            //server side validation
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                studentQuery = studentRepository.AsQueryable().Where(x => x.StudentId.ToString() == searchText || x.Name.ToString().Equals(searchText) || x.Name.Contains(searchText)).ToList();
            }
            else
            {
                studentQuery = studentRepository.AsQueryable().ToList();
            }

            total = studentQuery.Count();
            List<Student> students = studentQuery.OrderByDescending(x => x.StudentId).Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            //List<AddressType> addressTypes = addressTypeRepository.All().ToList();

            List<StudentModel> studentModel = students.Select(x => new StudentModel
            {
                Id = x.StudentId,
                Name = x.Name,
                Phone = x.Phone,
                Email = x.Email,
                Organization = x.Organization,
                Address = addessService.Show(x.StudentId),
                //AddressTypes = addressTypes.Select(a => new SelectModel { Value = a.AddressTypeId, Text = a.Value }).ToList()

            }).ToList();
          
            return studentModel;
        }

        public StudentModel Show(int studentId)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(studentId)) || studentId < 1)
            {
                throw new Exception("Student id not valid");
            }

            var studentModel = new StudentModel();

            Student student = studentRepository.FindOne(x => x.StudentId == studentId);
            if (student != null)
            {
                studentModel.Id = student.StudentId;
                studentModel.Name = student.Name;
                studentModel.Phone = student.Phone;
                studentModel.Email = student.Email;
                studentModel.Organization = student.Organization;
                studentModel.Address = addessService.Show(studentId);
            }
            List<AddressType> addressTypes = addressTypeRepository.All().ToList();
            studentModel.Address.AddressTypes = addressTypes.Select(a => new SelectModel { Value = a.AddressTypeId, Text = a.Value }).ToList();

            return studentModel;
        }


        public bool Delete(int studentId)
        {
            //server side validation
            if (string.IsNullOrWhiteSpace(Convert.ToString(studentId)) || studentId < 1)
            {
                throw new Exception("Student id not valid");
            }

            try
            {
                studentRepository.Delete(x => x.StudentId == studentId);
            }
            catch (Exception ex)
            {
                throw new Exception("Student not deleted succssfully" + ex);
            }

            return true;
        }


        public StudentModel Update(int studentId, StudentModel studentModel)
        {
            //server side validation
            if (string.IsNullOrWhiteSpace(Convert.ToString(studentId)) || studentId < 1)
            {
                throw new Exception("Student id not valid");
            }

            //server side validation
            if (string.IsNullOrWhiteSpace(studentModel.Name) || string.IsNullOrWhiteSpace(studentModel.Phone))
            {
                throw new Exception("All required field must be entered");
            }

            Student student = studentRepository.FindOne(x => x.StudentId == studentId);

            //server side validation
            if (student == null)
            {
                throw new Exception("student not found");
            }

            student.StudentId = studentModel.Id;
            student.Name = studentModel.Name;
            student.Phone = studentModel.Phone;
            student.Organization = studentModel.Organization;

            Address address = new Address();
            if (studentModel.Address != null)
            {
                //studentId will auto take from student which will auto generate after insert student 
                //address.StudentId = student.StudentId; 
                address.Street = studentModel.Address.Street;
                address.House = studentModel.Address.House;
                address.PoBox = studentModel.Address.PoBox;
                address.ZipCode = studentModel.Address.ZipCode;
                address.City = studentModel.Address.City;
            }

            try
            {
                studentRepository.Save(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Student not updated succssfully" + ex);
            }

            //addessService.Update(student.StudentId, studentModel);
            return Show(studentId);
        }
    }
}