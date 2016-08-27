
(function () {
    'use strict';

    var controllerId = 'searchStudentController';
    angular
          .module('Demo')
          .controller(controllerId, ['studentService', '$location', searchStudentController]);

    function searchStudentController(studentService, location) {

        /* jshint validthis:true */
        var searchStudentCtr = this;
        searchStudentCtr.studentDetails = StudentDetails;
        searchStudentCtr.studentCreate = StudentCreate;
        searchStudentCtr.studentSearch = StudentSearch;
        searchStudentCtr.Students = {};

        getStudents();
        function getStudents() {
            alert("ffff");
            searchStudentCtr.Students = studentService.GetAllStudent();
        }

        function StudentDetails(data) {
            var url = '/studentDetails';
            //location.path(url);
            location.path(url).search({ 'student': data });
        }

        function StudentCreate() {
            var url = '/student-create';
            location.path(url);
        }
        function StudentSearch() {
            //var url = '/student-create';
            //location.path(url);
        }



    }
})();
