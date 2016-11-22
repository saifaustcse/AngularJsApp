
(function () {
    'use strict';

    var controllerId = 'studentAddUdateController';
    angular
          .module('Demo')
          .controller(controllerId, ['addressService', 'studentService', 'notificationService', '$location', studentAddUdateController]);

    function studentAddUdateController(addressService, studentService, notificationService, location) {

        /* jshint validthis:true */
        var vm = this;
        vm.addStudent = addStudent;
        vm.updateStudent = updateStudent;
        vm.backToStudents = backToStudents;
        vm.save = save;
        vm.saveButtonText = 'Save Student';
        vm.Text = 'ADD STUDENT';
        vm.loadStudentAddress = loadStudentAddress;
        //vm.studentId = 0;//No student
        //vm.addressTypeId = 1;//Default
        vm.addressTypes = {};
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
            vm.addressTypes = data.result.address.addressTypes;
            },
           function (errorMessage) {
               notificationService.displayError(errorMessage.message);
           });
        }

        function getStudent() {

            studentService.show(vm.studentId).then(function (data) {
                vm.student = data.result;
                vm.addressTypes = data.result.student.address.addressTypes;
            },

            function (errorMessage) {
            notificationService.displayError(errorMessage.message);
        });
        }

        function loadStudentAddress() {
            if (vm.student.student.id != undefined && vm.student.student.id != null && vm.student.student.id != '') {
                addressService.loadStudentAddress(vm.student.student.id, vm.student.student.address.addressTypeId).then(function (data) {
                    vm.student.student.address = data.result.address;
                },
               function (errorMessage) {
                   notificationService.displayError(errorMessage.message);
               });
            }
            else {
                notificationService.displayError("Student not found");

            }
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
            vm.student = data.result;

            var url = '/studentDetails';
            location.path(url).search({ 'studentId': vm.student.student.id });
            notificationService.displaySuccess('Student saved');
            },

            function (errorMessage) {
                notificationService.displayError(errorMessage.message);
            });
        }

        function updateStudent() {
             studentService.update(vm.studentId, vm.student).then(function (data) {
             vm.student = data.result;

             var url = '/studentDetails';
             location.path(url).search({ 'studentId': vm.student.student.id });
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