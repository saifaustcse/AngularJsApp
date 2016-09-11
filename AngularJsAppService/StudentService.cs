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

        public List<StudentModel> GetAll()
        {
            List<Student> students = repository.GetStudents().ToList();

            List<StudentModel> studentModel = students.Select(x => new StudentModel
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Organization = x.Organization,

            }).ToList();

            return studentModel;
        }

        public List<StudentModel> GetStudents(string searchText, int pageSize, int pageNumber, out int total)
        {

            List<Student> studentQuery = new List<Student>();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                studentQuery = repository.GetStudents().Where(x => x.Id.ToString() == searchText || x.Name.ToString().Equals(searchText) || x.Name.Contains(searchText)).ToList();
            }
            else
            {
                studentQuery = repository.GetStudents().ToList();

            }

            total = studentQuery.Count();
            List<Student> students = studentQuery.OrderByDescending(x => x.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            List<StudentModel> studentModel = students.Select(x => new StudentModel
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Organization = x.Organization,

            }).ToList();

            return studentModel;
        }

        

        public StudentModel  Save( StudentModel studentModel)
        {
            if (studentModel == null)
            {
                throw new Exception("Student data missing");
            }

            //server side validation rule1
            //if (studentModel.Name == null || studentModel.Name == "" || studentModel.Phone == "" || studentModel.Phone == null)
            //{
            //    throw new Exception("All required field must be entered");
            //}

            //server side validation rule2
            //if (string.IsNullOrEmpty(studentModel.Name) || string.IsNullOrEmpty(studentModel.Phone))
            //{
            //    throw new Exception("All required field must be entered");
            //}

            if (string.IsNullOrWhiteSpace(studentModel.Name) || string.IsNullOrWhiteSpace(studentModel.Phone))
            {
                throw new Exception("All required field must be entered");
            }

            var students = new Student
            {
                Name = studentModel.Name,
                Phone = studentModel.Phone,
                Organization = studentModel.Organization
            };

            int id=  repository.SaveStudent(students);
            return Show(id);

        }

        public bool Delete(int studentId)
        {
            if (studentId == 0 || studentId<1)
            {
                throw new Exception("Student id not valid");
            }

            repository.DeleteStudent(studentId);
            return true;
        }

        public StudentModel Show(int studentId)
        {
            var studentModel = new StudentModel();
            if (studentId > 0)
            {
                Student student = repository.ShowStudent(studentId);
                if (student != null)
                {
                    studentModel.Id = student.Id;
                    studentModel.Name = student.Name;
                    studentModel.Phone = student.Phone;
                    studentModel.Organization = student.Organization;
                }
            }
            return studentModel;
        }

        public StudentModel Update(int id, StudentModel studentModel)
        {
            if (id == 0 || studentModel == null)
            {
                throw new Exception("Student data missing");
            }

            //server side validation rule latest
            if (string.IsNullOrWhiteSpace(studentModel.Name) || string.IsNullOrWhiteSpace(studentModel.Phone))
            {
                throw new Exception("All required field must be entered");
            }

            Student student = repository.ShowStudent(id);

            if (student == null)
            {
                throw new Exception("student not found");
            }

            student.Id = studentModel.Id;
            student.Name = studentModel.Name;
            student.Phone = studentModel.Phone;
            student.Organization = studentModel.Organization;

            repository.Update(student);
            return Show(id);
        }

    }
}