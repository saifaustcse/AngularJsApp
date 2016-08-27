/// <reference path="~/Scripts/angular.js" />

(function () {
    'use strict';

    var app = angular.module('Demo');

    app.constant('routes', getRoutes());

    app.config(['$routeProvider', 'routes', routeConfigurator]);

    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            setRoute(r.url, r.config);
        });

        $routeProvider.otherwise({ redirectTo: '/home' });

        function setRoute(url, definition) {
            definition.resolve = angular.extend(definition.resolve || {});
            $routeProvider.when(url, definition);
        }
    }
    function getRoutes() {

        return [
            {
                url: '/home',
                config: {
                    templateUrl: 'app/student/home.html',
                    controller: 'homeController',
                    controllerAs: 'homeCtr',
                    title: 'home'

                }
            }, {
                url: '/courses',
                config: {
                    templateUrl: 'app/student/courses.html',
                    controller: 'coursesController',
                    controllerAs: 'coursesCtr',
                    title: 'courses'
                }
            },
             {
                 url: '/students',
                 config: {
                     templateUrl: 'app/student/students.html',
                     controller: 'studentsController',
                     controllerAs: 'studentsCtr',
                     title: 'students'
                 }
             },
             {
                 url: '/student-create',
                 config: {
                     templateUrl: 'app/student/addupdateStudent.html',
                     controller: 'addupdateStudentController',
                     controllerAs: 'addupdateStudentCtr',
                     title: 'studentAddUpdate'
                 }
             },
             {
                 url: '/studentDetails',
                 config: {
                     templateUrl: 'app/student/studentDetails.html',
                     controller: 'studentDetailsController',
                     controllerAs: 'studentDetailsCtr',
                     title: 'studentDetail'
                 }
             },
             {
                 url: '/studentSearch',
                 config: {
                     templateUrl: 'app/student/searchStudent.html',
                     controller: 'searchStudentController',
                     controllerAs: 'searchStudentCtr',
                     title: 'studentSearch'
                 }
             },
             {
                 url: '/customers',
                 config: {
                     templateUrl: 'app/customers/customers.html',
                     controller: 'customersController',
                     controllerAs: 'vm',
                     title: 'Customer'
                 }
             },
             {
                 url: '/customer-create',
                 config: {
                     templateUrl: 'app/customers/customerAdd.html',
                     controller: 'customerAddController',
                     controllerAs: 'vm',
                     title: 'Customer'
                 }
             }
        ];
    }
})();