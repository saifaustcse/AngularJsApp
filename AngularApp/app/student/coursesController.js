
(function () {
    'use strict';

    var controllerId = 'coursesController';
    angular
       .module('Demo')
       .controller('coursesController', coursesController);

    coursesController.$inject = ['studentService'];

    function coursesController(studentService) {

        var vm = this;
        //vm.coursesList = ["C#", "VB.NET", "ASP.NET", "SQL Server"];

        getCourseList();
        function getCourseList() {
            vm.coursesList = studentService.GetCourseList();
        }

    }
})();

