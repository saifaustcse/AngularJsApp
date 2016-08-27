
(function () {
    'use strict';

    var controllerId = 'studentsController';
    angular
          .module('Demo')
          .controller(controllerId, ['studentService', 'notificationService','$location',studentsController]);

    function studentsController(studentService,notificationService, location) {

        /* jshint validthis:true */
        var studentsCtr = this;
        studentsCtr.studentDetails = studentDetails;
        studentsCtr.studentCreate = studentCreate;
        studentsCtr.Students = {};
      
        getStudents();
        function getStudents() {
            studentService.GetAllStudent().then(function (data) {
                studentsCtr.studentList = data.result.students;
                studentsCtr.total = data.total;
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

       

    }
})();
