//vm
(function () {
    'use strict';

    var controllerId = 'studentDetailsController';
    angular
          .module('Demo')
          .controller(controllerId, ['studentService', 'notificationService', '$location', studentDetailsController]);

    function studentDetailsController(studentService, notificationService, location) {

        /* jshint validthis:true */
        var vm = this;
        vm.studentId = 0;
        vm.student = {};
        vm.backToStudents = backToStudents;
        vm.deleteStudent = deleteStudent;
        vm.editStudent = editStudent;

        if (location.search().studentId != undefined && location.search().studentId != null && location.search().studentId != '') {
            vm.studentId = location.search().studentId;
        }

        getStudent();
        function getStudent() {
            studentService.show(vm.studentId).then(function (data) {
                vm.student = data.result;
            },
           function (errorMessage) {
               notificationService.displayError(errorMessage.message);
           });
        }

        function deleteStudent() {
            studentService.remove(vm.studentId).then(function (data) {
                notificationService.displayInfo('student deleted!');

                var url = '/students';
                location.path(url).search({});
            },
            function (errorMessage) {
                notificationService.displayError(errorMessage.message);
            });
        }

        function editStudent() {
            var url = '/student-create';
            location.path(url).search({ 'studentId': vm.studentId });
        }


        function backToStudents() {
            var url = '/students';
            location.path(url).search({});

        }
    }
})();
