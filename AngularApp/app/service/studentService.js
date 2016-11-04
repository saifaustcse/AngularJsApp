
(function () {
    'use strict';
    angular.module('Demo').service('studentService', ['$http', 'dataConstants', '$q', studentService]);

    function studentService($http, dataConstants, $q) {
        var URL = dataConstants.STUDENT_URL;
        var service = {
            save: save,
            get: get,
            show: show,
            remove: remove,
            update: update,
            GetCourseList: getCourseList,       
        };
        return service;
        
        //Get Course List
        function getCourseList() {
            var coursesList = ["C#", "VB.NET", "ASP.NET", "SQL Server"];
            return coursesList;
        }

        //save a new student
        function save(data) {
            var url = URL + 'save';
            var deferred = $q.defer();

            $http.put(url, data).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        //Get Stuents
        function get(searchText, itemsPerPage, pageNumber) {
            alert('get');
            var url = URL + 'get/' + itemsPerPage + '/' + pageNumber + '?q=' + searchText;
            var deferred = $q.defer();

            $http.get(url).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        //Get a student by id for details or edit
        function show(id) {
            var url = URL + 'show/' + id;
            var deferred = $q.defer();

            $http.get(url).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }


        //Delete a student by id
        function remove(id) {
            var url = URL + 'delete/' + id;
            var deferred = $q.defer();
            $http.delete(url).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        //Update student by id
        function update(id, data) {
            var url = URL + 'update/' + id;
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
