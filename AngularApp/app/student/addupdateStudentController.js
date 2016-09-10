
(function () {
    'use strict';

    var controllerId = 'addupdateStudentController';
    angular
          .module('Demo')
          .controller(controllerId, ['studentService', 'notificationService', '$location', addupdateStudentController]);

    function addupdateStudentController(studentService, notificationService, location) {

        /* jshint validthis:true */
        var vm = this;
        vm.backToStudents = backToStudents;
        vm.addStudent = addStudent;
        vm.updateStudent = updateStudent;
        vm.save = save;
        vm.saveButtonText = 'Save Student';
        vm.studentId = 0;
        vm.student = {};

        if (location.search().studentId != undefined && location.search().studentId != null && location.search().studentId != '') {
            vm.studentId = location.search().studentId;
            vm.saveButtonText = 'Update Student';
        }

        getStudent();
        function getStudent() {
            studentService.GetStudent(vm.studentId).then(function (data) {
                vm.student = data.result;
            },
           function (errorMessage) {
               vm.displayError(errorMessage.message);
           });
        }

        function save() {
            if (vm.studentId > 0) {
                updateStudent();
            }
            else {
                addStudent();
            }
        }

        function addStudent() {
            studentService.SaveStudent(vm.student).then(function (data) {
                vm.student = data.result.student;

                var url = '/studentDetails';
                location.path(url).search({ 'studentId': vm.student.id });
                notificationService.displaySuccess('Student saved');
            },
            function (errorMessage) {
                notificationService.displayError(errorMessage.message);
            });
        }

        function updateStudent() {
            studentService.UpdateStudent(vm.studentId, vm.student).then(function (data) {
                vm.student = data.result.student;

                var url = '/studentDetails';
                location.path(url).search({ 'studentId': vm.student.id });
                notificationService.displaySuccess('Student updated');
            },
             function (errorMessage) {
                 notificationService.displayError(errorMessage.message);
             });
        }


        function backToStudents() {
            var url = '/students';
            location.path(url).search({});

        }
    }
})();