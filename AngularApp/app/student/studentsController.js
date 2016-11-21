
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
        vm.searchStudents = searchStudents;
        vm.searchText = '';
        vm.students = {};

        vm.itemsPerPage = 5;
        vm.pageNumber = 1;
        vm.totalItems = 0;
        vm.pageChanged = pageChanged;

        if (location.search().page != undefined && location.search().page != null && location.search().page != '') {
            vm.pageNumber = location.search().page;
        }

        if (location.search().size != undefined && location.search().size != null && location.search().size != '') {
            vm.itemsPerPage = location.search().size;
        }
        if (location.search().searchText != undefined && location.search().searchText != null && location.search().searchText != '') {
            vm.searchText = location.search().searchText;
        }

        getStudents();
        function getStudents() {            
            studentService.get(vm.searchText, vm.itemsPerPage, vm.pageNumber).then(function (data) {
                alert("Students" + JSON.stringify(data));
                 vm.students = data.result.students;
                 vm.totalItems = data.total;
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

        function pageChanged() {
            var url = '/students';
            if (vm.searchText != '') {
                location.path(url).search({ 'page': vm.pageNumber, 'size': vm.itemsPerPage, 'searchText': vm.searchText });
            }
            else {
                location.path(url).search({ 'page': vm.pageNumber, 'size': vm.itemsPerPage });

            }
        }

        function searchStudents() {
            vm.pageNumber = 1;
            var url = '/students';
            location.path(url).search({ 'page': vm.pageNumber, 'size': vm.itemsPerPage, 'searchText': vm.searchText });
        }
    }
})();
