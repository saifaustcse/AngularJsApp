
(function () {
    'use strict';
    
    var controllerId = 'coursesController';
    angular
       .module('Demo')
       .controller('coursesController', coursesController);

    coursesController.$inject = ['studentService'];

    function coursesController(studentService) {

        var coursesCtr = this;
        //coursesCtr.coursesList = ["C#", "VB.NET", "ASP.NET", "SQL Server"];

        getCourseList();
        function getCourseList() {
            coursesCtr.coursesList = studentService.GetCourseList();
        }

    }
})();

   