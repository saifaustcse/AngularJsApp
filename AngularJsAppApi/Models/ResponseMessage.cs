using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsAppApi.Models
{
    public class ResponseMessage<T> : ErrorMessage
    {
        public int Total { get; set; }
        public T Result { get; set; }
    }
}