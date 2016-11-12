
(function () {
    'use strict';
    angular.module('Demo').service('addressService', ['$http', 'dataConstants', '$q', addressService]);

    function addressService($http, dataConstants, $q) {
        var URL = dataConstants.ADDRESS_URL;
        var service = {
            
            getAddressType: getAddressType
        };
        return service;


        //Get Stuents
        function getAddressType() {
            alert("getAddressType");
            var url = URL + 'getAddressType';
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
