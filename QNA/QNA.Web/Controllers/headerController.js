(function(){
    'use strict';
    
    var app = angular.module('app');
    
    app.controller('headerController',function($scope){
       $scope.mesg="This is header directive calling from header controller" ;
    });
    
}());