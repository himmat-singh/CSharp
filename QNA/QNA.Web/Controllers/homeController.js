(function(){
    'use strict';
    
    var app = angular.module('app');
    
    app.controller('HomeController',function($scope){
        $scope.mesg = 'You are visiting home view...';
    });
}());