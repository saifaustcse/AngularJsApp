
(function () {
    'use strict';

    var controllerId = 'customersController';
    angular
          .module('Demo')
          .controller(controllerId, ['customerService','$location', customersController]);

      //  customersController.$inject = ['$location'];
   
        function customersController(customerService,location) {

        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Customers';
        vm.customerList = {};

        vm.addCustomer = AddCustomer;
        vm.editCustomer = EditCustomer;
        vm.deleteCustomer = DeleteCustomer;
        //vm.searchCustomers = SearchCustomers;
        vm.searchText = '';
        vm.customer = {};


        GetCustomers();
        function GetCustomers() {
            customerService.getCustomers().then(function (data) {
                vm.customerList = data.result.customers;
                vm.total = data.total;

            },
            function (errorMessage) {
                alert("customer not saved");
                //notificationService.displayError(errorMessage.message);
            });
        }

        //function DeleteCustomer(customer) {
        //    customerService.deleteCustomer(customer.id).then(function (data) {
        //        notificationService.displayInfo('Customer deleted!');
        //        GetCustomers();
        //    });
        //}

        function DeleteCustomer() {        
           var id = 101;
            customerService.deleteCustomer(id).then(function (data) {
                notificationService.displayInfo('Customer deleted!');
                GetCustomers();
            });
        }

        function AddCustomer() {
            var url = '/customer-create';
            location.path(url);
        }

        //function EditCustomer(customer) {
        //    var url = '/customer-create';
        //    location.path(url).search({ 'customerId': customer.id });
        //}

        function EditCustomer() {
            var id = 101;
            var url = '/customer-create';
            location.path(url).search({ 'customerId': id });
        }

    }
})();
