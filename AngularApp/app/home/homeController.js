
(function () {
    'use strict';
    
    var controllerId = 'homeController';
    angular
       .module('Demo')
       .controller('homeController', homeController);

    homeController.$inject = ['studentService'];

    function homeController(studentService) {

        var vm = this;
      

    }
})();

   