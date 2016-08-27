
(function () {
    'use strict';

    var controllerId = 'addupdateStudentController';
    angular
          .module('Demo')
          .controller(controllerId, ['studentService','notificationService', '$location', addupdateStudentController]);

    function addupdateStudentController(studentService,notificationService, location) {

        /* jshint validthis:true */
        var addupdateStudentCtr = this;
        addupdateStudentCtr.backToStudents = backToStudents;
        addupdateStudentCtr.addStudent = addStudent;
        addupdateStudentCtr.updateStudent = updateStudent;
        addupdateStudentCtr.save = save;
        addupdateStudentCtr.saveButtonText = 'Save Student';
        addupdateStudentCtr.studentId = 0;
        addupdateStudentCtr.student = {};
       
        if (location.search().studentId != undefined && location.search().studentId != null && location.search().studentId != '') {
            addupdateStudentCtr.studentId = location.search().studentId;
            addupdateStudentCtr.saveButtonText = 'Update Student';
        }

        getStudent();
        function getStudent() {
            studentService.GetStudent(addupdateStudentCtr.studentId).then(function (data) {
                addupdateStudentCtr.student = data.result;
            },
           function (errorMessage) {
               addupdateStudentCtr.displayError(errorMessage.message);
           });
        }

        function save() {
           if (addupdateStudentCtr.studentId > 0) {
                updateStudent();
            }
            else {
                addStudent();
            }
        }

        function addStudent() {
            studentService.SaveStudent(addupdateStudentCtr.student).then(function (data) {
                addupdateStudentCtr.student = data.result;
               
                var url = '/student-create';
                location.path(url).search({ 'studentId': addupdateStudentCtr.student.id });
                notificationService.displaySuccess('Student saved');
            },
            function (errorMessage) {
                notificationService.displayError(errorMessage.message);
            });
        }

        function updateStudent() {
            studentService.UpdateStudent(addupdateStudentCtr.studentId, addupdateStudentCtr.student).then(function (data) {
                addupdateStudentCtr.student = data.result;
                notificationService.displaySuccess('Student updated');
            },
             function (errorMessage) {
                 notificationService.displayError(errorMessage.message);
             });
        }
    
        
        function backToStudents() {
            var url = '/students';
            location.path(url);

        }


    }
})();
