(function(){
    'use strict';
    
    var app = angular.module('app');
        
   
    
    app.config(function($stateProvider, $urlRouterProvider){
        $urlRouterProvider.otherwise('/');
        
        $stateProvider.state('Home',{
            url:'/',
            templateUrl:'Templates/Home.html',
            controller:'HomeController'
        })
        .state('login',{
            url:'/login',
            templateUrl:'Templates/Login.html',
            controller:'LoginController'
        })
        .state('signup',{
            url:'/signup',
            templateUrl:'Templates/SignUp.html',
            controller:'SignUpController'
        })        
        .state('question-add',{
            url:'/question/add',
            templateUrl:'Templates/Questions/add.html',
            controller:'QuestionController'
        })
        .state('question-edit',{
            url:'/question/edit/{id:int}',
            templateUrl:'Templates/Questions/add.html',
            controller:'QuestionController'
        })
        .state('question',{
            url:'/question',
            templateUrl:'Templates/Questions/index.html',
            controller:'QuestionController'
        })
        .state('answer',{
            url:'/question/{id}/Answer'
        })
        
    });
}());