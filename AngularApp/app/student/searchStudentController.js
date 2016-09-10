
(function () {
    'use strict';

    var controllerId = 'searchStudentController';
    angular
          .module('Demo')
          .controller(controllerId, ['studentService', '$location', searchStudentController]);

    function searchStudentController(studentService, location) {

        /* jshint validthis:true */
        var vm = this;
        vm.studentDetails = studentDetails;
        vm.studentCreate = studentCreate;
        vm.studentSearch = studentSearch;
        vm.backToStudents = backToStudents;
        vm.Students = {};

        getStudents();
        function getStudents() {
            alert("ffff");
            vm.Students = studentService.GetAllStudent();
        }

        function studentDetails(data) {
            var url = '/studentDetails';
            //location.path(url);
            location.path(url).search({ 'student': data });
        }

        function studentCreate() {
            var url = '/student-create';
            location.path(url);
        }
        function studentSearch() {
            //var url = '/student-create';
            //location.path(url);
        }

        function backToStudents() {
            var url = '/students';
            location.path(url).search({});

        }
    }
})();
