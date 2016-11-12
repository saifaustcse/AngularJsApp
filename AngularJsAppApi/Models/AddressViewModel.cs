using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJsAppService.Models;


namespace AngularJsAppApi.Models
{
    public class AddressViewModel
    {
        public AddressModel Address { get; set; }
        public List<AddressModel> Addresses { get; set; }
    }
}