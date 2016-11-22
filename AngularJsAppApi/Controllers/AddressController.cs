using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AngularJsAppApi.Models;
using AngularJsAppService;

namespace AngularJsAppApi.Controllers
{
    [RoutePrefix("api/address")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    //[EnableCors(origins: "http://www.example.com", headers: "*", methods: "*")]
    //[EnableCors(origins: "http://localhost:3480/", headers: "*", methods: "*")]
    public class AddressController : ApiController
    {

        private readonly AddessService addessService = new AddessService();

        [HttpGet]
        [Route("getAddressTypes")]
        public IHttpActionResult GetAddressTypes()
        {
            //StudentViewModel studentViewModel = new StudentViewModel();
            //studentViewModel.Student = studentService.Show(studentId); 

            var addressViewModel = new AddressViewModel { Address = addessService.GetAddressTypes() };

            //ResponseMessage<StudentViewModel> responseMessage = new ResponseMessage<StudentViewModel>();
            //responseMessage.Result = studentViewModel;

            var responseMessage = new ResponseMessage<AddressViewModel> { Result = addressViewModel };
            return Ok(responseMessage);
        }

        [HttpGet]
        [Route("loadStudentAddress/{studentId}/{addressTypeId}")]
        public IHttpActionResult loadStudentAddress(int studentId, int addressTypeId)
        {
            //StudentViewModel studentViewModel = new StudentViewModel();
            //studentViewModel.Student = studentService.Show(studentId); 

            var addressViewModel = new AddressViewModel { Address = addessService.loadStudentAddress(studentId,addressTypeId) };

            //ResponseMessage<StudentViewModel> responseMessage = new ResponseMessage<StudentViewModel>();
            //responseMessage.Result = studentViewModel;

            var responseMessage = new ResponseMessage<AddressViewModel> { Result = addressViewModel };
            return Ok(responseMessage);
        }
        
    }
}
