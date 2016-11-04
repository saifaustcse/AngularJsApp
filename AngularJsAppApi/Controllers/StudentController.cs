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

namespace AngularJsAppApi.Controllers
{
    [RoutePrefix("api/students")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    // [EnableCors(origins: "http://www.example.com", headers: "*", methods: "*")]
    // [EnableCors(origins: "http://localhost:3480/", headers: "*", methods: "*")]
    public class StudentController : ApiController
    {
       
        private readonly StudentService studentService=new StudentService();

        //public StudentController(ICampaignService campaignService)
        //{
        //    this.campaignService = campaignService;
        //}

        [HttpPut]
        [Route("save")]
        public IHttpActionResult Save([FromBody] StudentViewModel studentViewModel)
        {
            //StudentViewModel stdViewModel = new StudentViewModel();
            //stdViewModel.Student = studentService.Save(studentViewModel.Student);

            var stdViewModel = new StudentViewModel { Student = studentService.Save(studentViewModel.Student) };

            //ResponseMessage<StudentViewModel> responseMessage = new ResponseMessage<StudentViewModel>();
            //responseMessage.Result = stdViewModel;

            var responseMessage = new ResponseMessage<StudentViewModel> { Result = stdViewModel };
            return Ok(responseMessage);
        }

        [HttpGet]
        [Route("get/{itemsPerPage:int=20}/{pageNumber:int=1}")]
        public IHttpActionResult Get(int itemsPerPage, int pageNumber, [FromUri] string q)
        {
            int total = 0;

            //StudentViewModel studentViewModel = new StudentViewModel();
            //studentViewModel.Students = studentService.GetStudents(q, pageSize, pageNumber, out total);

            var studentViewModel = new StudentViewModel { Students = studentService.Get(q, itemsPerPage, pageNumber, out total) };

            //ResponseMessage<StudentViewModel> responseMessage = new ResponseMessage<StudentViewModel>();
            //responseMessage.Result = studentViewModel;

            var responseMessage = new ResponseMessage<StudentViewModel> { Result = studentViewModel, Total = total };
            return Ok(responseMessage);
        }

        [HttpGet]
        [Route("show/{id}")]
        public IHttpActionResult Show(int id)
        {
            //StudentViewModel studentViewModel = new StudentViewModel();
            //studentViewModel.Student = studentService.Show(studentId); 

            var studentViewModel = new StudentViewModel { Student = studentService.Show(id) };

            //ResponseMessage<StudentViewModel> responseMessage = new ResponseMessage<StudentViewModel>();
            //responseMessage.Result = studentViewModel;

            var responseMessage = new ResponseMessage<StudentViewModel> { Result = studentViewModel };
            return Ok(responseMessage);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            // ResponseMessage<bool> responseMessage = new ResponseMessage<bool>();
            // responseMessage.Result = studentService.Delete(studentId);

            var responseMessage = new ResponseMessage<bool> { Result = studentService.Delete(id) };
            return Ok(responseMessage);
        }

        [HttpPost]
        [Route("update/{id}")]
        public IHttpActionResult Update([Range(1, int.MaxValue)]int id, [FromBody]StudentViewModel studentViewModel)
        {
            //StudentViewModel stdViewModel = new StudentViewModel();
            //stdViewModel.Student = studentService.Update(id, studentViewModel.Student);

            var stdViewModel = new StudentViewModel { Student = studentService.Update(id, studentViewModel.Student) };

            //ResponseMessage<StudentViewModel> responseMessage = new ResponseMessage<StudentViewModel>();
            //responseMessage.Result = stdViewModel;

            var responseMessage = new ResponseMessage<StudentViewModel> { Result = stdViewModel };
            return Ok(responseMessage);
        }
    }
}
