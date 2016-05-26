(function(){
    'use strict';
    
    var app = angular.module('app');
    
    app.controller('appMain',function($scope){
        $scope.currentTab = 'Home';
        $scope.mesg ="This is sample text";
    });
}());