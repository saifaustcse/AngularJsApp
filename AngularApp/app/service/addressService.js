
(function () {
    'use strict';
    angular.module('Demo').service('addressService', ['$http', 'dataConstants', '$q', addressService]);

    function addressService($http, dataConstants, $q) {
        var URL = dataConstants.ADDRESS_URL;
        var service = {     
            getAddressType: getAddressType,
            loadStudentAddress: loadStudentAddress
        };
        return service;

        function getAddressType() {
            var url = URL + 'getAddressTypes';
            var deferred = $q.defer();

            $http.get(url).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        function loadStudentAddress(studentId, addressTypeId) {
            var url = URL + 'loadStudentAddress/' + studentId + '/' + addressTypeId;
            var deferred = $q.defer();

            $http.get(url).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }
    }

})();
