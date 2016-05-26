(function(){
    'use strict';
    
    var app = angular.module('app');
    
    app.directive('appHeader',function(){
        return {
            restrict:'E',
            templateUrl:'Templates/header.html',
            controller:'headerController'
        };
    });
    
    app.directive('appFooter',function(){
        return {
          restrict:'EA',
            templateUrl:'Templates/footer.html',
            controller:'FooterController'
        };
    });
}());