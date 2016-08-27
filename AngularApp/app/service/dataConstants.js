
(function () {
    "use strict";
     window.baseAPIUrl = 'http://localhost:3480/';

     angular.module("Demo").constant("dataConstants", {
         STUDENT_URL: "http://localhost:3480/api/students/"
      
        //DOCUMENT_URL: baseAPIUrl + "/api/documents/",
        //CUSTOMER_URL: "http://www.example.com/api/customers/"
    });
})();