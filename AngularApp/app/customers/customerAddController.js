
(function () {
    'use strict';

    var controllerId = 'customerAddController';
    angular
          .module('Demo')
          .controller(controllerId, ['customerService', '$location',customerAddController]);

    function customerAddController(customerService, location) {

        var vm = this;
        vm.title = 'Add Customer';
        vm.customer = {};

        vm.insertCustomer = insertCustomer;
        vm.updateCustomer = updateCustomer;
        vm.close = close;
        vm.save = save;
        vm.saveButtonText = 'SAVE';

        vm.customerId = 0;
        vm.phoneNumberTypeId = 0;
        vm.addressTypeId = 0;
        vm.emails = [];
        vm.customerForm = {};
        vm.noteForm = {}; 

        if (location.search().customerId != undefined && location.search().customerId != null && location.search().customerId != '') {
            vm.customerId = location.search().customerId;
            vm.saveButtonText = 'UPDATE';
        }
        
        //EditCustomer();
        //function EditCustomer() {
        //    customerService.showCustomer(vm.customerId).then(function (data) {
        //        vm.customer = data.result;
        //        //formateDate();
        //    },
        //   function (errorMessage) {
        //      // notificationService.displayError(errorMessage.message);
        //   });
        //}

        function save() {
             if (vm.customerId > 0) {
                updateCustomer();
            }
            else {
                insertCustomer();
            }
        }

        function insertCustomer() {
            alert("Inside save customer" + JSON.stringify(vm.customer));

            customerService.saveCustomer(vm.customer).then(function (data) {
                vm.customer = data.result;
               
                var url = '/customer-create';

                location.path(url).search({ 'customerId': vm.customer.customer.id });
                alert("customer  saved");
                //notificationService.displaySuccess('Customer saved');
            },
           function (errorMessage) {
               // notificationService.displayError(errorMessage.message);
               alert("customer not saved");
           });
        }

        function updateCustomer() {
            customerService.updateCustomer(vm.customerId, vm.customer).then(function (data) {
                vm.customer = data.result;
               // formateDate();
               // notificationService.displaySuccess('Customer updated');
            },
            function (errorMessage) {
              //s  notificationService.displayError(errorMessage.message);
            });
        }

        function close() {
            var url = '/customers';
            location.path(url);
        }
    }
})();
