using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJsAppService.Models;

namespace AngularJsAppApi.Models
{
    public class StudentViewModel
    {
        public StudentModel Student { get; set; }
        public List<StudentModel> Students { get; set; }

    }
}