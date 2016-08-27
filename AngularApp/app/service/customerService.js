
(function () {
    'use strict';
    angular.module('Demo').service('customerService', ['$http', 'dataConstants', '$q', customerService]);

    function customerService($http, dataConstants, $q) {

        var service = {
            getCustomers: GetCustomers,
            saveCustomer: saveCustomer,
            deleteCustomer: DeleteCustomer,
            showCustomer: ShowCustomer,
            updateCustomer: updateCustomer
         
        };

        return service;

        //insert a new customer
        function saveCustomer(data) {
            alert("Inside save customer" + JSON.stringify(data));

            var url = dataConstants.CUSTOMER_URL + 'save-customer';
            var deferred = $q.defer();

            $http.put(url, data).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }
       
        //Get All Customers
        function GetCustomers() {
            var url = dataConstants.CUSTOMER_URL + 'get-customers';
            alert("Inside save customer" + JSON.stringify(url));
            var deferred = $q.defer();

            $http.get(url).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }
      
        //Get a Customer by id
        function ShowCustomer(customerId) {
            
            var url = dataConstants.CUSTOMER_URL + 'show-customer/' + customerId;
            alert("Inside save customer" + JSON.stringify(url));
            var deferred = $q.defer();

            $http.get(url).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }


        //Delete a Customer by id
        function DeleteCustomer(customerId) {
            var url = dataConstants.CUSTOMER_URL + 'delete-customer/' + customerId;
            alert("Inside save customer" + JSON.stringify(url));
            var deferred = $q.defer();
            $http.delete(url).success(function (data) {
                deferred.resolve(data);
            }).error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        //edit customer by id
        function updateCustomer(id, data) {
            var url = dataConstants.CUSTOMER_URL + 'update-customer/' + id;
            alert("Inside save customer" + JSON.stringify(url));
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
