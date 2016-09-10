
(function () {
    'use strict';
    angular.module('Demo').service('studentService', ['$http', 'dataConstants', '$q', studentService]);

    function studentService($http, dataConstants, $q) {     
        var service = {
            GetStudent: getStudent,
            GetAllStudent: getAllStudent,
            DeleteStudent: deleteStudent,
            UpdateStudent: updateStudent,
            GetCourseList: getCourseList,
            SaveStudent:saveStudent
        };

        return service;
        
        //Get Course List
        function getCourseList() {
            var coursesList = ["C#", "VB.NET", "ASP.NET", "SQL Server"];
            return coursesList;
        }

        //insert a new student
        function saveStudent(data) {
            var url = dataConstants.STUDENT_URL + 'save-student';
            var deferred = $q.defer();

            $http.put(url, data).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        //Get All Stuents
        function getAllStudent() {
            var url = dataConstants.STUDENT_URL + 'get-students';
            var deferred = $q.defer();

            $http.get(url).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        //Get a StudentId by id
        function getStudent(studentId) {
            var url = dataConstants.STUDENT_URL + 'show-student/' + studentId;
            var deferred = $q.defer();

            $http.get(url).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }


        //Delete a student by id
        function deleteStudent(studentId) {
            var url = dataConstants.STUDENT_URL + 'delete-student/' + studentId;
            var deferred = $q.defer();
            $http.delete(url).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        //Edit student by id
        function updateStudent(id, data) {
            var url = dataConstants.STUDENT_URL + 'update-student/' + id;
            var deferred = $q.defer();
            $http.post(url, data).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }       
    }
})();
