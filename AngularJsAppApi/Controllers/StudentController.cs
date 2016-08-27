using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AngularJsAppApi.Models;
using AngularJsAppService;
using AngularJsAppService.Models;


namespace AngularJsAppApi.Controllers
{
    [RoutePrefix("api/students")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    // [EnableCors(origins: "http://www.example.com", headers: "*", methods: "*")]
    // [EnableCors(origins: "http://localhost:3480/", headers: "*", methods: "*")]
    public class StudentController : ApiController
    {
        readonly StudentService studentService = new StudentService();

        [HttpGet]
        [Route("get-students")]
        public IHttpActionResult GetStudent()
        {
          
            //StudentViewModel studentViewModel = new StudentViewModel();
            //studentViewModel.Students = studentService.GetAll();

            var studentViewModel = new StudentViewModel {Students = studentService.GetAll()};

            //ResponseMessage<StudentViewModel> responseMessage = new ResponseMessage<StudentViewModel>();
            // responseMessage.Total = total;
            //responseMessage.Result = studentViewModel;

            var responseMessage = new ResponseMessage<StudentViewModel> {Result = studentViewModel};
            // responseMessage.Total = total;

            return Ok(responseMessage);
        }

        [HttpPut]
        [Route("save-student")]
        public IHttpActionResult SaveStudent([FromBody] StudentViewModel studentViewModel)
        {
            //stdViewModel studentViewModel = new StudentViewModel();
            //stdViewModel.Student = studentService.Save(studentViewModel.Student);
            var studentResponseViewModel = new StudentViewModel { Student = studentService.Save(studentViewModel.Student) };

            //ResponseMessage<StudentViewModel> message = new ResponseMessage<StudentViewModel>();
            //message.Result = studentViewModel;
            var message = new ResponseMessage<StudentViewModel> { Result = studentResponseViewModel };
            return Ok(message);
        }

        [HttpPost]
        [Route("update-student/{id}")]
        public IHttpActionResult UpdateStudent([Range(1, int.MaxValue)]int id, [FromBody]StudentViewModel studentViewModel)
        {
            //stdViewModel studentViewModel = new StudentViewModel();
            //stdViewModel.Student = studentService.Update(id, studentViewModel.Student);

            var studentResponseViewModel = new StudentViewModel { Student = studentService.Update(id, studentViewModel.Student) };

            //ResponseMessage<StudentViewModel> message = new ResponseMessage<StudentViewModel>();
            //message.Result = studentViewModel;
            var message = new ResponseMessage<StudentViewModel> { Result = studentResponseViewModel };
            return Ok(message);
        }

        [HttpGet]
        [Route("show-student/{studentId}")]
        public IHttpActionResult ShowStudent(int studentId)
        {
            StudentModel studentModel = studentService.Show(studentId);

            //StudentViewModel studentViewModel = new StudentViewModel();
            //studentViewModel.Student = studentModel;

            var studentViewModel = new StudentViewModel {Student = studentModel};

            //ResponseMessage<StudentViewModel> responseMessage = new ResponseMessage<StudentViewModel>();
            //responseMessage.Result = studentViewModel;

            var responseMessage = new ResponseMessage<StudentViewModel> { Result = studentViewModel };
            return Ok(responseMessage);
        }

        [HttpDelete]
        [Route("delete-student/{studentId}")]
        public IHttpActionResult DeleteStudent(int studentId)
        {
            // ResponseMessage<bool> message = new ResponseMessage<bool>();
            // message.Result = studentService.Delete(studentId);
            var message = new ResponseMessage<bool> {Result = studentService.Delete(studentId)};
            return Ok(message);
        }
    }
}
