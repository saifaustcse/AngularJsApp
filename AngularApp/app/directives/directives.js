(function () {
    "use strict";

    var app = angular.module('Demo');

   
    app.directive('menuToggleDirective', function () {
        return {
            link: function ($scope, element, attrs) {
                element.bind('click', function (e) {
                        e.preventDefault();
                        $("#wrapper").toggleClass("toggled");
                    });
                element.bind('mouseenter', function () {
                    element.css('background-color', 'greenyellow');
                });
                element.bind('mouseleave', function () {
                    element.css('background-color', '');
                });
            }
        };
    });

    app.directive('myDomDirective', function () {
        return {
            link: function ($scope, element, attrs) {
                element.bind('click', function () {             
                    element.html('You clicked me!');
                });
                element.bind('mouseenter', function () {
                    element.css('background-color', 'yellow');
                });
                element.bind('mouseleave', function () {
                    element.css('background-color', '');
                });
            }
        };
    });


    app.directive('passwordCheck', function () {
        return {
            require: 'ngModel',
            link: function(scope, elem, attrs, ctrl) {
                var firstPassword = '#' + attrs.passwordCheck;
                elem.add(firstPassword).on('keyup', function() {
                    scope.$apply(function() {
                        ctrl.$setValidity('pwmatch', elem.val() === $(firstPassword).val());
                    });
                });
            }
        };
    });

})();
