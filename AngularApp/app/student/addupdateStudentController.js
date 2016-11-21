
(function () {
    'use strict';

    var controllerId = 'addupdateStudentController';
    angular
          .module('Demo')
          .controller(controllerId, ['addressService', 'studentService', 'notificationService', '$location', addupdateStudentController]);

    function addupdateStudentController(addressService, studentService, notificationService, location) {

        /* jshint validthis:true */
        var vm = this;
        vm.addStudent = addStudent;
        vm.updateStudent = updateStudent;
        vm.backToStudents = backToStudents;
        vm.save = save;
        vm.saveButtonText = 'Save Student';
        vm.Text = 'ADD STUDENT';
        vm.studentId = 0;
        vm.student = {};

        if (location.search().studentId != undefined && location.search().studentId != null && location.search().studentId != '') {
            vm.studentId = location.search().studentId;
            vm.saveButtonText = 'Update Student';
            vm.Text = 'UPDATE STUDENT';
            getStudent();
        }
        else {
            getAddressType();
        }



        function getAddressType() {
            addressService.getAddressType().then(function (data) {
                vm.student.addressTypes = data.result;
            },
           function (errorMessage) {
               vm.displayError(errorMessage.message);
           });
        }

        function getStudent() {
            studentService.show(vm.studentId).then(function (data) {
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
            studentService.save(vm.student).then(function (data) {
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
            studentService.update(vm.studentId, vm.student).then(function (data) {
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