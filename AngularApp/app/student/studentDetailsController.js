//studentDetailsCtr
(function () {
    'use strict';

    var controllerId = 'studentDetailsController';
    angular
          .module('Demo')
          .controller(controllerId, ['studentService', 'notificationService', '$location', studentDetailsController]);

    function studentDetailsController(studentService,notificationService, location) {

        /* jshint validthis:true */
        var studentDetailsCtr = this;
        studentDetailsCtr.studentId = 0;
        studentDetailsCtr.student = {};
        studentDetailsCtr.backToStudents = backToStudents;
        studentDetailsCtr.deleteStudent = deleteStudent;
        studentDetailsCtr.editStudent = editStudent;
       
        if (location.search().studentId != undefined && location.search().studentId != null && location.search().studentId != '') {
            studentDetailsCtr.studentId = location.search().studentId;
        }

       getStudent();
        function getStudent() {
            studentService.GetStudent(studentDetailsCtr.studentId).then(function (data) {
                studentDetailsCtr.student = data.result.student;
            },
           function (errorMessage) {
               notificationService.displayError(errorMessage.message);
           });
        }

        function deleteStudent() {
            studentService.DeleteStudent(studentDetailsCtr.studentId).then(function (data) {
            notificationService.displayInfo('student deleted!');

            var url = '/students';
            location.path(url);        
            },
            function (errorMessage) {
                notificationService.displayError(errorMessage.message);
            });
        }

     function editStudent() {
            var url = '/student-create';
            location.path(url).search({ 'studentId': studentDetailsCtr.studentId });
        }


        function backToStudents() {
            var url = '/students';
            location.path(url);
           
        }


    }
})();
