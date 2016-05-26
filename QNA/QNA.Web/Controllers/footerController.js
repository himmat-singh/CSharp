(function(){
    'use strict';
    
    var app = angular.module('app');
    
    app.controller('FooterController',function($scope){
        $scope.mesg="This is footer controller called by footer directive";
    });
}());