
(function () {
    'use strict';

    var controllerId = 'studentsController';
    angular
          .module('Demo')
          .controller(controllerId, ['studentService', 'notificationService', '$location', studentsController]);

    function studentsController(studentService, notificationService, location) {

        /* jshint validthis:true */
        var vm = this;
        vm.studentDetails = studentDetails;
        vm.studentCreate = studentCreate;
        vm.backToStudents = backToStudents;
        vm.Students = {};

        getStudents();
        function getStudents() {
            studentService.GetAllStudent().then(function (data) {
                vm.studentList = data.result.students;
                vm.total = data.total;
            },
            function (errorMessage) {
                notificationService.displayError(errorMessage.message);
            });
        }

        function studentDetails(studentId) {
            var url = '/studentDetails';
            location.path(url).search({ 'studentId': studentId });
        }

        function studentCreate() {
            var url = '/student-create';
            location.path(url);
        }

        function backToStudents() {
            var url = '/students';
            location.path(url).search({});

        }
    }
})();
